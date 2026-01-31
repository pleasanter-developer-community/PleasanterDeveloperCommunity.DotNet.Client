using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items
{
    /// <summary>
    /// レコード削除レスポンス
    /// </summary>
    public class DeleteRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("LimitPerDate")]
        public int? LimitPerDate { get; set; }

        [JsonPropertyName("LimitRemaining")]
        public int? LimitRemaining { get; set; }
    }
}
