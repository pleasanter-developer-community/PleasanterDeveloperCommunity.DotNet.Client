using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PleasanterDeveloperCommunity.DotNet.Client;

/// <summary>
/// デバッグログを記録するロガー（非同期バックグラウンド処理）
/// </summary>
internal class DebugLogger : IDisposable
{
    private const string MaskedValue = "********";

    private readonly string _logDirectory;
    private readonly Encoding _encoding;
    private readonly bool _maskApiKey;
    private readonly CsvConfiguration _csvConfig;
    private readonly Channel<DebugLogRecord> _channel;
    private readonly Task _writeTask;
    private readonly CancellationTokenSource _cts;
    private bool _disposed;

    /// <summary>
    /// DebugLoggerのコンストラクタ
    /// </summary>
    /// <param name="settings">デバッグ設定</param>
    public DebugLogger(DebugSettings settings)
    {
        if (settings == null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        _logDirectory = settings.LogDirectory;
        _encoding = settings.Encoding ?? Encoding.Default;
        _maskApiKey = settings.MaskApiKey;
        _csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };

        // アンバウンドチャンネルを作成（バックプレッシャーなし）
        _channel = Channel.CreateUnbounded<DebugLogRecord>(new UnboundedChannelOptions
        {
            SingleReader = true,
            SingleWriter = false
        });

        _cts = new CancellationTokenSource();

        // バックグラウンドタスクを開始
        _writeTask = Task.Run(() => ProcessQueueAsync(_cts.Token));
    }

    /// <summary>
    /// リクエストをログに記録します
    /// </summary>
    /// <param name="requestId">リクエストID</param>
    /// <param name="url">リクエストURL</param>
    /// <param name="requestBody">リクエストボディ</param>
    public void LogRequest(string requestId, string url, string requestBody)
    {
        var maskedContent = _maskApiKey ? MaskApiKeyInJson(requestBody) : requestBody;

        var record = new DebugLogRecord
        {
            Timestamp = DateTime.Now,
            RequestId = requestId,
            Type = "Request",
            Url = url,
            StatusCode = null,
            IsJson = null,
            Content = maskedContent
        };

        EnqueueRecord(record);
    }

    /// <summary>
    /// レスポンスをログに記録します
    /// </summary>
    /// <param name="requestId">リクエストID</param>
    /// <param name="url">リクエストURL</param>
    /// <param name="statusCode">HTTPステータスコード</param>
    /// <param name="responseBody">レスポンスボディ</param>
    public void LogResponse(string requestId, string url, HttpStatusCode statusCode, string responseBody)
    {
        var (isJson, formattedContent) = TryFormatJson(responseBody);

        var record = new DebugLogRecord
        {
            Timestamp = DateTime.Now,
            RequestId = requestId,
            Type = "Response",
            Url = url,
            StatusCode = (int)statusCode,
            IsJson = isJson,
            Content = formattedContent
        };

        EnqueueRecord(record);
    }

    /// <summary>
    /// 例外をログに記録します
    /// </summary>
    /// <param name="requestId">リクエストID</param>
    /// <param name="url">リクエストURL</param>
    /// <param name="exception">例外</param>
    public void LogException(string requestId, string url, Exception exception)
    {
        var content = FormatException(exception);

        var record = new DebugLogRecord
        {
            Timestamp = DateTime.Now,
            RequestId = requestId,
            Type = "Exception",
            Url = url,
            StatusCode = null,
            IsJson = false,
            Content = content
        };

        EnqueueRecord(record);
    }

    /// <summary>
    /// 例外を文字列にフォーマットします（InnerExceptionも展開）
    /// </summary>
    /// <param name="exception">例外</param>
    /// <returns>フォーマット済みの例外文字列</returns>
    private static string FormatException(Exception exception)
    {
        if (exception == null)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        FormatExceptionRecursive(exception, sb, 0);
        return sb.ToString();
    }

    /// <summary>
    /// 例外を再帰的にフォーマットします
    /// </summary>
    /// <param name="exception">例外</param>
    /// <param name="sb">StringBuilder</param>
    /// <param name="depth">ネストの深さ</param>
    private static void FormatExceptionRecursive(Exception exception, StringBuilder sb, int depth)
    {
        var indent = new string(' ', depth * 2);
        var prefix = depth == 0 ? "" : "[InnerException] ";

        sb.AppendLine($"{indent}{prefix}{exception.GetType().FullName}: {exception.Message}");

        if (!string.IsNullOrEmpty(exception.StackTrace))
        {
            sb.AppendLine($"{indent}StackTrace:");
            foreach (var line in exception.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                sb.AppendLine($"{indent}  {line}");
            }
        }

        if (exception.InnerException != null)
        {
            sb.AppendLine();
            FormatExceptionRecursive(exception.InnerException, sb, depth + 1);
        }

        // AggregateExceptionの場合は全てのInnerExceptionsを展開
        if (exception is AggregateException aggregateException)
        {
            foreach (var innerException in aggregateException.InnerExceptions)
            {
                // InnerExceptionと重複しないようにチェック
                if (innerException != exception.InnerException)
                {
                    sb.AppendLine();
                    FormatExceptionRecursive(innerException, sb, depth + 1);
                }
            }
        }
    }

    /// <summary>
    /// レコードをキューに追加します
    /// </summary>
    /// <param name="record">ログレコード</param>
    private void EnqueueRecord(DebugLogRecord record)
    {
        // TryWriteは同期的に実行され、アンバウンドチャンネルでは常に成功する
        _channel.Writer.TryWrite(record);
    }

    /// <summary>
    /// キューからレコードを取り出して処理します
    /// </summary>
    /// <param name="cancellationToken">キャンセルトークン</param>
    private async Task ProcessQueueAsync(CancellationToken cancellationToken)
    {
        try
        {
            await foreach (var record in _channel.Reader.ReadAllAsync(cancellationToken))
            {
                try
                {
                    WriteRecordToFile(record);
                }
                catch
                {
                    // ファイル書き込みエラーは無視（ロギングの失敗でアプリケーションを停止させない）
                }
            }
        }
        catch (OperationCanceledException)
        {
            // キャンセルされた場合は正常終了
        }
    }

    /// <summary>
    /// JSONかどうかを確認し、JSONであればフォーマットします
    /// </summary>
    /// <param name="content">コンテンツ</param>
    /// <returns>JSONかどうかとフォーマット済みコンテンツのタプル</returns>
    private static (bool isJson, string content) TryFormatJson(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return (false, content);
        }

        try
        {
            var doc = JsonDocument.Parse(content);
            var formatted = JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
            return (true, formatted);
        }
        catch (JsonException)
        {
            return (false, content);
        }
    }

    /// <summary>
    /// JSON内のApiKeyをマスクします
    /// </summary>
    /// <param name="json">JSON文字列</param>
    /// <returns>ApiKeyがマスクされたJSON文字列</returns>
    private static string MaskApiKeyInJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return json;
        }

        try
        {
            var node = JsonNode.Parse(json);
            if (node != null)
            {
                MaskApiKeyRecursive(node);
                return node.ToJsonString();
            }
            return json;
        }
        catch (JsonException)
        {
            // JSONでない場合はそのまま返す
            return json;
        }
    }

    /// <summary>
    /// JsonNode内のApiKeyを再帰的にマスクします
    /// </summary>
    /// <param name="node">JsonNode</param>
    private static void MaskApiKeyRecursive(JsonNode node)
    {
        switch (node)
        {
            case JsonObject obj:
                foreach (var property in obj.ToArray())
                {
                    if (property.Key.Equals("ApiKey", StringComparison.OrdinalIgnoreCase))
                    {
                        obj[property.Key] = MaskedValue;
                    }
                    else if (property.Value != null)
                    {
                        MaskApiKeyRecursive(property.Value);
                    }
                }
                break;

            case JsonArray array:
                foreach (var item in array)
                {
                    if (item != null)
                    {
                        MaskApiKeyRecursive(item);
                    }
                }
                break;
        }
    }

    /// <summary>
    /// レコードをCSVファイルに書き込みます
    /// </summary>
    /// <param name="record">ログレコード</param>
    private void WriteRecordToFile(DebugLogRecord record)
    {
        var fileName = $"{record.Timestamp:yyyy-MM-dd}.csv";
        var filePath = Path.Combine(_logDirectory, fileName);

        var fileExists = File.Exists(filePath);

        using var stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
        using var writer = new StreamWriter(stream, _encoding);
        using var csv = new CsvWriter(writer, _csvConfig);

        // 新規ファイルの場合はヘッダーを書き込む
        if (!fileExists)
        {
            csv.WriteHeader<DebugLogRecord>();
            csv.NextRecord();
        }

        csv.WriteRecord(record);
        csv.NextRecord();
    }

    /// <summary>
    /// リソースを解放します
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// リソースを解放します
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            // チャンネルを完了としてマーク
            _channel.Writer.Complete();

            // バックグラウンドタスクの完了を待機（タイムアウト付き）
            try
            {
                _writeTask.Wait(TimeSpan.FromSeconds(5));
            }
            catch (AggregateException)
            {
                // タスクの例外は無視
            }

            _cts.Cancel();
            _cts.Dispose();
        }

        _disposed = true;
    }

    /// <summary>
    /// デバッグログレコード
    /// </summary>
    private class DebugLogRecord
    {
        public DateTime Timestamp { get; set; }
        public string RequestId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int? StatusCode { get; set; }
        public bool? IsJson { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
