using System.Collections.Generic;
using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items
{
    /// <summary>
    /// 複数レコード取得レスポンス
    /// </summary>
    public class RecordsResponse
    {
        [JsonPropertyName("Offset")]
        public int? Offset { get; set; }

        [JsonPropertyName("PageSize")]
        public int? PageSize { get; set; }

        [JsonPropertyName("TotalCount")]
        public int? TotalCount { get; set; }

        [JsonPropertyName("Data")]
        public List<RecordData>? Data { get; set; }
    }
}
