using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.ExtendedSql;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.ExtendedSql;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PleasanterDeveloperCommunity.DotNet.Client;

/// <summary>
/// プリザンターAPIクライアント
/// </summary>
public class PleasanterClient : IDisposable
{
    private static readonly Lazy<HttpClient> DefaultHttpClient = new(() => CreateHttpClient(ProxySettings.UseSystemDefault));
    private static readonly JsonSerializerSettings JsonSettings = new()
    {
        NullValueHandling = NullValueHandling.Ignore
    };

    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;
    private readonly TimeSpan? _defaultTimeout;
    private readonly bool _ownsHttpClient;
    private bool _disposed;

    /// <summary>
    /// PleasanterClientのコンストラクタ
    /// </summary>
    /// <param name="baseUrl">プリザンターのベースURL（例: https://example.com/pleasanter）</param>
    /// <param name="apiKey">APIキー</param>
    /// <param name="defaultTimeout">デフォルトのリクエストタイムアウト（省略時：HttpClientのデフォルト値を使用）</param>
    /// <param name="proxySettings">プロキシ設定（省略時：OS設定に従う）</param>
    public PleasanterClient(string baseUrl, string apiKey, TimeSpan? defaultTimeout = null, ProxySettings? proxySettings = null)
    {
        _baseUrl = !string.IsNullOrWhiteSpace(baseUrl)
            ? baseUrl.TrimEnd('/')
            : throw new ArgumentNullException(nameof(baseUrl));
        _apiKey = !string.IsNullOrWhiteSpace(apiKey)
            ? apiKey
            : throw new ArgumentNullException(nameof(apiKey));
        _defaultTimeout = defaultTimeout;

        var effectiveProxySettings = proxySettings ?? ProxySettings.UseSystemDefault;
        if (effectiveProxySettings.Mode == ProxyMode.UseSystemDefault)
        {
            _httpClient = DefaultHttpClient.Value;
            _ownsHttpClient = false;
        }
        else
        {
            _httpClient = CreateHttpClient(effectiveProxySettings);
            _ownsHttpClient = true;
        }
    }

    /// <summary>
    /// PleasanterClientのコンストラクタ（HttpClientを外部から渡す場合）
    /// </summary>
    /// <param name="baseUrl">プリザンターのベースURL</param>
    /// <param name="apiKey">APIキー</param>
    /// <param name="httpClient">HttpClientインスタンス</param>
    /// <param name="defaultTimeout">デフォルトのリクエストタイムアウト（省略時：HttpClientのデフォルト値を使用）</param>
    public PleasanterClient(string baseUrl, string apiKey, HttpClient httpClient, TimeSpan? defaultTimeout = null)
    {
        _baseUrl = !string.IsNullOrWhiteSpace(baseUrl)
            ? baseUrl.TrimEnd('/')
            : throw new ArgumentNullException(nameof(baseUrl));
        _apiKey = !string.IsNullOrWhiteSpace(apiKey)
            ? apiKey
            : throw new ArgumentNullException(nameof(apiKey));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _defaultTimeout = defaultTimeout;
        _ownsHttpClient = false;
    }

    /// <summary>
    /// プロキシ設定に応じたHttpClientを作成します
    /// </summary>
    private static HttpClient CreateHttpClient(ProxySettings proxySettings)
    {
        var handler = new HttpClientHandler();

        switch (proxySettings.Mode)
        {
            case ProxyMode.UseSystemDefault:
                handler.UseProxy = true;
                handler.Proxy = WebRequest.GetSystemWebProxy();
                break;

            case ProxyMode.NoProxy:
                handler.UseProxy = false;
                break;

            case ProxyMode.Custom:
                handler.UseProxy = true;
                handler.Proxy = proxySettings.Proxy;
                break;
        }

        return new HttpClient(handler);
    }

    /// <summary>
    /// 単一レコードを取得します
    /// </summary>
    /// <param name="recordId">レコードID（IssueIdまたはResultId）</param>
    /// <param name="view">ビュー設定（取得する列の指定など）</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<RecordResponse>> GetRecordAsync(long recordId, View? view = null, TimeSpan? timeout = null)
    {
        var request = new RecordRequest
        {
            ApiKey = _apiKey,
            View = view
        };

        var url = $"{_baseUrl}/api/items/{recordId}/get";
        return await PostAsync<RecordResponse>(url, request, timeout);
    }

    /// <summary>
    /// 複数レコードを取得します
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="offset">取得開始位置（ページネーション用）</param>
    /// <param name="view">ビュー設定（フィルタや並び替えなど）</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<RecordsResponse>> GetRecordsAsync(long siteId, int? offset = null, View? view = null, TimeSpan? timeout = null)
    {
        var request = new RecordsRequest
        {
            ApiKey = _apiKey,
            Offset = offset,
            View = view
        };

        var url = $"{_baseUrl}/api/items/{siteId}/get";
        return await PostAsync<RecordsResponse>(url, request, timeout);
    }


    /// <summary>
    /// ページングを自動的に処理し、全レコードを取得します
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="view">ビュー設定（フィルタや並び替えなど）</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>全レコードを含むAPIレスポンス</returns>
    public async Task<ApiResponse<RecordsResponse>> GetAllRecordsAsync(long siteId, View? view = null, TimeSpan? timeout = null)
    {
        var allRecords = new List<RecordData>();
        int offset = 0;
        int? totalCount = null;

        while (true)
        {
            var response = await GetRecordsAsync(siteId, offset, view, timeout);

            if (response.StatusCode != HttpStatusCode.OK || response.Response?.Data == null)
            {
                return response;
            }

            allRecords.AddRange(response.Response.Data);
            totalCount = response.Response.TotalCount;

            if (!response.Response.HasNextPage)
            {
                return new ApiResponse<RecordsResponse>
                {
                    StatusCode = response.StatusCode,
                    Message = response.Message,
                    Response = new RecordsResponse
                    {
                        Offset = 0,
                        PageSize = allRecords.Count,
                        TotalCount = totalCount,
                        Data = allRecords
                    }
                };
            }

            offset = (response.Response.Offset ?? 0) + (response.Response.PageSize ?? 0);
        }
    }

    /// <summary>
    /// レコードを作成します
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="title">タイトル</param>
    /// <param name="body">内容</param>
    /// <param name="status">状況</param>
    /// <param name="manager">管理者</param>
    /// <param name="owner">担当者</param>
    /// <param name="completionTime">完了日時</param>
    /// <param name="classHash">分類項目</param>
    /// <param name="numHash">数値項目</param>
    /// <param name="dateHash">日付項目</param>
    /// <param name="descriptionHash">説明項目</param>
    /// <param name="checkHash">チェック項目</param>
    /// <param name="attachmentsHash">添付ファイル項目</param>
    /// <param name="processId">プロセスID</param>
    /// <param name="processIds">複数のプロセスID</param>
    /// <param name="imageHash">画像挿入設定</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<CreateRecordResponse>> CreateRecordAsync(
        long siteId,
        string? title = null,
        string? body = null,
        int? status = null,
        int? manager = null,
        int? owner = null,
        string? completionTime = null,
        Dictionary<string, string>? classHash = null,
        Dictionary<string, decimal>? numHash = null,
        Dictionary<string, string>? dateHash = null,
        Dictionary<string, string>? descriptionHash = null,
        Dictionary<string, bool>? checkHash = null,
        Dictionary<string, List<AttachmentData>>? attachmentsHash = null,
        int? processId = null,
        List<int>? processIds = null,
        Dictionary<string, ImageSettings>? imageHash = null,
        TimeSpan? timeout = null)
    {
        var request = new CreateRecordRequest
        {
            ApiKey = _apiKey,
            Title = title,
            Body = body,
            Status = status,
            Manager = manager,
            Owner = owner,
            CompletionTime = completionTime,
            ClassHash = classHash,
            NumHash = numHash,
            DateHash = dateHash,
            DescriptionHash = descriptionHash,
            CheckHash = checkHash,
            AttachmentsHash = attachmentsHash,
            ProcessId = processId,
            ProcessIds = processIds,
            ImageHash = imageHash
        };

        var url = $"{_baseUrl}/api/items/{siteId}/create";
        return await PostAsync<CreateRecordResponse>(url, request, timeout);
    }

    /// <summary>
    /// レコードを作成します - リクエストオブジェクト使用版
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">作成リクエスト</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<CreateRecordResponse>> CreateRecordAsync(long siteId, CreateRecordRequest request, TimeSpan? timeout = null)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        request.ApiKey = _apiKey;
        var url = $"{_baseUrl}/api/items/{siteId}/create";
        return await PostAsync<CreateRecordResponse>(url, request, timeout);
    }


    /// <summary>
    /// レコードを作成または更新します（Upsert）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="keys">キーとなる項目名の配列</param>
    /// <param name="title">タイトル</param>
    /// <param name="body">内容</param>
    /// <param name="status">状況</param>
    /// <param name="manager">管理者</param>
    /// <param name="owner">担当者</param>
    /// <param name="completionTime">完了日時</param>
    /// <param name="classHash">分類項目</param>
    /// <param name="numHash">数値項目</param>
    /// <param name="dateHash">日付項目</param>
    /// <param name="descriptionHash">説明項目</param>
    /// <param name="checkHash">チェック項目</param>
    /// <param name="processId">プロセスID</param>
    /// <param name="processIds">複数のプロセスID</param>
    /// <param name="imageHash">画像挿入設定</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<UpsertRecordResponse>> UpsertRecordAsync(
        long siteId,
        List<string> keys,
        string? title = null,
        string? body = null,
        int? status = null,
        int? manager = null,
        int? owner = null,
        string? completionTime = null,
        Dictionary<string, string>? classHash = null,
        Dictionary<string, decimal>? numHash = null,
        Dictionary<string, string>? dateHash = null,
        Dictionary<string, string>? descriptionHash = null,
        Dictionary<string, bool>? checkHash = null,
        int? processId = null,
        List<int>? processIds = null,
        Dictionary<string, ImageSettings>? imageHash = null,
        TimeSpan? timeout = null)
    {
        var request = new UpsertRecordRequest
        {
            ApiKey = _apiKey,
            Keys = keys,
            Title = title,
            Body = body,
            Status = status,
            Manager = manager,
            Owner = owner,
            CompletionTime = completionTime,
            ClassHash = classHash,
            NumHash = numHash,
            DateHash = dateHash,
            DescriptionHash = descriptionHash,
            CheckHash = checkHash,
            ProcessId = processId,
            ProcessIds = processIds,
            ImageHash = imageHash
        };

        var url = $"{_baseUrl}/api/items/{siteId}/upsert";
        return await PostAsync<UpsertRecordResponse>(url, request, timeout);
    }

    /// <summary>
    /// レコードを作成または更新します（Upsert）- リクエストオブジェクト使用版
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">Upsertリクエスト</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<UpsertRecordResponse>> UpsertRecordAsync(long siteId, UpsertRecordRequest request, TimeSpan? timeout = null)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        request.ApiKey = _apiKey;
        var url = $"{_baseUrl}/api/items/{siteId}/upsert";
        return await PostAsync<UpsertRecordResponse>(url, request, timeout);
    }

    /// <summary>
    /// 複数レコードを一括作成または更新します（BulkUpsert）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="data">レコードデータの配列</param>
    /// <param name="keys">キーとなる項目名の配列（省略時：全てのレコードを新規作成）</param>
    /// <param name="keyNotFoundCreate">キーと一致するレコードが無い場合に新規作成するかどうか（省略時：true）</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<BulkUpsertRecordResponse>> BulkUpsertRecordAsync(
        long siteId,
        List<BulkUpsertRecordData> data,
        List<string>? keys = null,
        bool? keyNotFoundCreate = null,
        TimeSpan? timeout = null)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        var request = new BulkUpsertRecordRequest
        {
            ApiKey = _apiKey,
            Keys = keys,
            KeyNotFoundCreate = keyNotFoundCreate,
            Data = data
        };

        var url = $"{_baseUrl}/api/items/{siteId}/bulkupsert";
        return await PostAsync<BulkUpsertRecordResponse>(url, request, timeout);
    }

    /// <summary>
    /// 複数レコードを一括作成または更新します（BulkUpsert）- リクエストオブジェクト使用版
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">BulkUpsertリクエスト</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<BulkUpsertRecordResponse>> BulkUpsertRecordAsync(long siteId, BulkUpsertRecordRequest request, TimeSpan? timeout = null)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        request.ApiKey = _apiKey;
        var url = $"{_baseUrl}/api/items/{siteId}/bulkupsert";
        return await PostAsync<BulkUpsertRecordResponse>(url, request, timeout);
    }

    /// <summary>
    /// 拡張SQLを実行します
    /// </summary>
    /// <param name="name">拡張SQLの名前（JSONファイルで定義したName）</param>
    /// <param name="parameters">SQLに渡すパラメータ</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(
        string name,
        Dictionary<string, object>? parameters = null,
        TimeSpan? timeout = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var request = new ExtendedSqlRequest
        {
            ApiKey = _apiKey,
            Name = name,
            Params = parameters
        };

        var url = $"{_baseUrl}/api/extended/sql";
        return await PostAsync<ExtendedSqlResponse>(url, request, timeout);
    }

    /// <summary>
    /// 拡張SQLを実行します - リクエストオブジェクト使用版
    /// </summary>
    /// <param name="request">拡張SQLリクエスト</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(ExtendedSqlRequest request, TimeSpan? timeout = null)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        request.ApiKey = _apiKey;
        var url = $"{_baseUrl}/api/extended/sql";
        return await PostAsync<ExtendedSqlResponse>(url, request, timeout);
    }

    /// <summary>
    /// POSTリクエストを送信します
    /// </summary>
    /// <param name="url">リクエストURL</param>
    /// <param name="request">リクエストオブジェクト</param>
    /// <param name="timeout">リクエストタイムアウト（省略時：デフォルトタイムアウトを使用）</param>
    private async Task<ApiResponse<T>> PostAsync<T>(string url, object request, TimeSpan? timeout = null) where T : class
    {
        var formatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter
        {
            SerializerSettings = JsonSettings
        };

        var effectiveTimeout = timeout ?? _defaultTimeout;
        using var cts = effectiveTimeout.HasValue
            ? new CancellationTokenSource(effectiveTimeout.Value)
            : new CancellationTokenSource();

        var content = new StringContent(
            JsonConvert.SerializeObject(request, JsonSettings),
            System.Text.Encoding.UTF8,
            "application/json");

        using var response = await _httpClient.PostAsync(url, content, cts.Token);
        var result = await response.Content.ReadAsAsync<ApiResponse<T>>(formatters: new[] { formatter });

        return result ?? new ApiResponse<T> { StatusCode = response.StatusCode };
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

        if (disposing && _ownsHttpClient)
        {
            _httpClient.Dispose();
        }

        _disposed = true;
    }
}
