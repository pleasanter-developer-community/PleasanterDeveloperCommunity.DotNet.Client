using System;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items
{
    /// <summary>
    /// レコード更新レスポンス
    /// </summary>
    public class UpdateRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }

        [JsonPropertyName("LimitPerDate")]
        public int? LimitPerDate { get; set; }

        [JsonPropertyName("LimitRemaining")]
        public int? LimitRemaining { get; set; }
    }
}
