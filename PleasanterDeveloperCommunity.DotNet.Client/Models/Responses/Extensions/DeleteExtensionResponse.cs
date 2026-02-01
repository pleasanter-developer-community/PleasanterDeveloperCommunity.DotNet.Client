using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions;

/// <summary>
/// 拡張機能削除レスポンス
/// </summary>
public class DeleteExtensionResponse
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
}
