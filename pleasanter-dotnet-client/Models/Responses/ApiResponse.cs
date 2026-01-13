using Newtonsoft.Json;
using System.Net;

namespace pleasanter_dotnet_client.Models.Responses;

/// <summary>
/// APIレスポンスの基底クラス
/// </summary>
/// <typeparam name="T">レスポンスデータの型</typeparam>
public class ApiResponse<T> where T : class
{
    /// <summary>
    /// ステータスコード（200: 成功）
    /// </summary>
    [JsonProperty("StatusCode")]
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonProperty("Response")]
    public T? Response { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonProperty("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// 成功かどうかを判定します
    /// </summary>
    public bool IsSuccess => StatusCode == HttpStatusCode.OK;
}
