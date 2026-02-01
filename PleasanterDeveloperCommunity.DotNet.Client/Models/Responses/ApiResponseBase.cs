using System.Net;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// APIレスポンス基底クラス
/// </summary>
/// <typeparam name="T">レスポンスデータの型</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// HTTPステータスコード
    /// </summary>
    [JsonProperty("StatusCode")]
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// レスポンスメッセージ
    /// </summary>
    [JsonProperty("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonProperty("Response")]
    public T? Response { get; set; }

    /// <summary>
    /// 成功したかどうか
    /// </summary>
    [JsonIgnore]
    public bool IsSuccess => StatusCode == HttpStatusCode.OK;
}
