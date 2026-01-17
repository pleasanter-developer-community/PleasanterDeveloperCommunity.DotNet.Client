using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace PleasanterDeveloperCommunity.DotNet.Client;

/// <summary>
/// デバッグログを記録するロガー
/// </summary>
internal class DebugLogger : IDisposable
{
    private readonly string _logDirectory;
    private readonly Encoding _encoding;
    private readonly object _lockObject = new object();
    private readonly CsvConfiguration _csvConfig;
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
        _csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };
    }

    /// <summary>
    /// リクエストをログに記録します
    /// </summary>
    /// <param name="requestId">リクエストID</param>
    /// <param name="url">リクエストURL</param>
    /// <param name="requestBody">リクエストボディ</param>
    public void LogRequest(string requestId, string url, string requestBody)
    {
        var record = new DebugLogRecord
        {
            Timestamp = DateTime.Now,
            RequestId = requestId,
            Type = "Request",
            Url = url,
            StatusCode = null,
            IsJson = null,
            Content = requestBody
        };

        WriteRecord(record);
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

        WriteRecord(record);
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
            var token = JToken.Parse(content);
            var formatted = token.ToString(Formatting.Indented);
            return (true, formatted);
        }
        catch (JsonReaderException)
        {
            return (false, content);
        }
    }

    /// <summary>
    /// レコードをCSVファイルに書き込みます
    /// </summary>
    /// <param name="record">ログレコード</param>
    private void WriteRecord(DebugLogRecord record)
    {
        var fileName = $"{DateTime.Today:yyyy-MM-dd}.csv";
        var filePath = Path.Combine(_logDirectory, fileName);

        lock (_lockObject)
        {
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
