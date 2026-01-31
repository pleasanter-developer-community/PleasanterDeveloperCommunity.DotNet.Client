using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites
{
    /// <summary>
    /// サイト削除レスポンス
    /// </summary>
    public class DeleteSiteResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }
}
