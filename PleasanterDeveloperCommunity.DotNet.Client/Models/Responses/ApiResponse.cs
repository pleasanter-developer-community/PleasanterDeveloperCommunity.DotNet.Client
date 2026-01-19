using System.Text.Json.Serialization;
using System.Net;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// APIレスポンスの基底クラス
/// </summary>
/// <typeparam name="T">レスポンスデータの型</typeparam>
public class ApiResponse<T> where T : class
{
    /// <summary>
    /// ステータスコード（200: 成功）
    /// </summary>
    [JsonPropertyName("StatusCode")]
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonPropertyName("Response")]
    public T? Response { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonPropertyName("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// 成功かどうかを判定します
    /// </summary>
    public bool IsSuccess => StatusCode == HttpStatusCode.OK;
}
