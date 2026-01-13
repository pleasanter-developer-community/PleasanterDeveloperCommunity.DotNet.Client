using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using pleasanter_dotnet_client.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace pleasanter_dotnet_client;

/// <summary>
/// プリザンターAPIクライアント
/// </summary>
public class PleasanterClient : IDisposable
{
    private static readonly JsonSerializerSettings JsonSettings = new()
    {
        NullValueHandling = NullValueHandling.Ignore
    };

    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;
    private bool _disposed;

    /// <summary>
    /// PleasanterClientのコンストラクタ
    /// </summary>
    /// <param name="baseUrl">プリザンターのベースURL（例: https://example.com/pleasanter）</param>
    /// <param name="apiKey">APIキー</param>
    public PleasanterClient(string baseUrl, string apiKey)
        : this(baseUrl, apiKey, new HttpClient())
    {
    }

    /// <summary>
    /// PleasanterClientのコンストラクタ（HttpClientを外部から渡す場合）
    /// </summary>
    /// <param name="baseUrl">プリザンターのベースURL</param>
    /// <param name="apiKey">APIキー</param>
    /// <param name="httpClient">HttpClientインスタンス</param>
    public PleasanterClient(string baseUrl, string apiKey, HttpClient httpClient)
    {
        _baseUrl = !string.IsNullOrWhiteSpace(baseUrl)
            ? baseUrl.TrimEnd('/')
            : throw new ArgumentNullException(nameof(baseUrl));
        _apiKey = !string.IsNullOrWhiteSpace(apiKey)
            ? apiKey
            : throw new ArgumentNullException(nameof(apiKey));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    /// <summary>
    /// 単一レコードを取得します
    /// </summary>
    /// <param name="recordId">レコードID（IssueIdまたはResultId）</param>
    /// <param name="view">ビュー設定（取得する列の指定など）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<GetRecordResponse>> GetRecordAsync(long recordId, View? view = null)
    {
        var request = new GetRecordRequest
        {
            ApiKey = _apiKey,
            View = view
        };

        var url = $"{_baseUrl}/api/items/{recordId}/get";
        return await PostAsync<GetRecordResponse>(url, request);
    }

    /// <summary>
    /// 複数レコードを取得します
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="offset">取得開始位置（ページネーション用）</param>
    /// <param name="view">ビュー設定（フィルタや並び替えなど）</param>
    /// <returns>APIレスポンス</returns>
    public async Task<ApiResponse<GetRecordsResponse>> GetRecordsAsync(long siteId, int? offset = null, View? view = null)
    {
        var request = new GetRecordsRequest
        {
            ApiKey = _apiKey,
            Offset = offset,
            View = view
        };

        var url = $"{_baseUrl}/api/items/{siteId}/get";
        return await PostAsync<GetRecordsResponse>(url, request);
    }

    /// <summary>
    /// ページングを自動的に処理し、全レコードを取得します
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="view">ビュー設定（フィルタや並び替えなど）</param>
    /// <returns>全レコードを含むAPIレスポンス</returns>
    public async Task<ApiResponse<GetRecordsResponse>> GetAllRecordsAsync(long siteId, View? view = null)
    {
        var allRecords = new List<RecordData>();
        int offset = 0;
        int? totalCount = null;

        while (true)
        {
            var response = await GetRecordsAsync(siteId, offset, view);

            if (response.StatusCode != HttpStatusCode.OK || response.Response?.Data == null)
            {
                return response;
            }

            allRecords.AddRange(response.Response.Data);
            totalCount = response.Response.TotalCount;

            if (!response.Response.HasNextPage)
            {
                return new ApiResponse<GetRecordsResponse>
                {
                    StatusCode = response.StatusCode,
                    Message = response.Message,
                    Response = new GetRecordsResponse
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
    /// POSTリクエストを送信します
    /// </summary>
    private async Task<ApiResponse<T>> PostAsync<T>(string url, object request) where T : class
    {
        var formatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter
        {
            SerializerSettings = JsonSettings
        };

        using var response = await _httpClient.PostAsJsonAsync(url, request);
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
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _httpClient?.Dispose();
        }
        _disposed = true;
    }
}
