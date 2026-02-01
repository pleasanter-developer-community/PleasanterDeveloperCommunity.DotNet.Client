using System.Collections.Generic;
using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 複数レコード取得レスポンス
/// </summary>
public class RecordsResponse
{
    [JsonProperty("Offset")]
    public int? Offset { get; set; }

    [JsonProperty("PageSize")]
    public int? PageSize { get; set; }

    [JsonProperty("TotalCount")]
    public int? TotalCount { get; set; }

    [JsonProperty("Data")]
    public List<RecordData>? Data { get; set; }
}
