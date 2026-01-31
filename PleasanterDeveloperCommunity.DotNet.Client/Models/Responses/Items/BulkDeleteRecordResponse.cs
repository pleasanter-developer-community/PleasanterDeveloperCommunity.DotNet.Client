using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items
{
    /// <summary>
    /// 一括削除レスポンス
    /// </summary>
    public class BulkDeleteRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }
}
