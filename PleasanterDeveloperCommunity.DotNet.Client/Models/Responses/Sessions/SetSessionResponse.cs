using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sessions
{
    /// <summary>
    /// セッション設定レスポンス
    /// </summary>
    public class SetSessionResponse
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
