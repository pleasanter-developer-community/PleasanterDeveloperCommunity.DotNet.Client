using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions;

/// <summary>
/// 拡張機能作成レスポンス
/// </summary>
public class CreateExtensionResponse
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
    /// 作成された拡張機能ID
    /// </summary>
    [JsonPropertyName("Id")]
    public long Id { get; set; }
}
