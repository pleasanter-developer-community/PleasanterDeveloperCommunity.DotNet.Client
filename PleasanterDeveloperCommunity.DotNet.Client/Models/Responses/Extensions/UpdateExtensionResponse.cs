using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions;

/// <summary>
/// 拡張機能更新レスポンス
/// </summary>
public class UpdateExtensionResponse
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
    /// 更新された拡張機能ID
    /// </summary>
    [JsonProperty("Id")]
    public long Id { get; set; }
}
