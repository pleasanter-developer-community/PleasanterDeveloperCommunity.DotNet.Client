using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions
{
    /// <summary>
    /// 拡張機能削除レスポンス
    /// </summary>
    public class DeleteExtensionResponse
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
    }
}
