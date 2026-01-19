using System.Text.Json.Serialization;
using System.Net;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// APIレスポンスの基底クラス（レスポンスデータなし）
/// </summary>
public class ApiResponse
{
    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonPropertyName("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// 1日あたりのAPI呼び出し上限
    /// </summary>
    [JsonPropertyName("LimitPerDate")]
    public int? LimitPerDate { get; set; }

    /// <summary>
    /// 残りのAPI呼び出し回数
    /// </summary>
    [JsonPropertyName("LimitRemaining")]
    public int? LimitRemaining { get; set; }

    /// <summary>
    /// ステータスコード（200: 成功）
    /// </summary>
    [JsonPropertyName("StatusCode")]
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// 成功かどうかを判定します
    /// </summary>
    public bool IsSuccess => StatusCode == HttpStatusCode.OK;
}

/// <summary>
/// APIレスポンスクラス（レスポンスデータあり）
/// </summary>
/// <typeparam name="T">レスポンスデータの型</typeparam>
public class ApiResponse<T> : ApiResponse where T : class
{
    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonPropertyName("Response")]
    public T? Response { get; set; }
}
