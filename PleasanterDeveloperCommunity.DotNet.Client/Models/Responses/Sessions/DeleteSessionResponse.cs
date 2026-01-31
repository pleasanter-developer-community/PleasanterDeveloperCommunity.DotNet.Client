using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sessions
{
    /// <summary>
    /// セッション削除レスポンス
    /// </summary>
    public class DeleteSessionResponse
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
