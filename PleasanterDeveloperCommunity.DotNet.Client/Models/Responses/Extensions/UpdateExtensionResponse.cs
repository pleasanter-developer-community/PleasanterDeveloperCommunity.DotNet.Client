using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions;

/// <summary>
/// 拡張機能更新レスポンス
/// </summary>
public class UpdateExtensionResponse
{
    /// <summary>
    /// ステータスコード
    /// </summary>
    [JsonPropertyName("StatusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonPropertyName("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// 更新された拡張機能ID
    /// </summary>
    [JsonPropertyName("Id")]
    public long Id { get; set; }
}
