using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions;

/// <summary>
/// 拡張機能作成レスポンス
/// </summary>
public class CreateExtensionResponse
{
    /// <summary>
    /// ステータスコード
    /// </summary>
    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonProperty("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// 作成された拡張機能ID
    /// </summary>
    [JsonProperty("Id")]
    public long Id { get; set; }
}
