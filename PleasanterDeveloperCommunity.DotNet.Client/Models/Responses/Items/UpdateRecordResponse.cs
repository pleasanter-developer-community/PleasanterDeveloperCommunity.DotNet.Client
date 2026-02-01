using System;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコード更新レスポンス
/// </summary>
public class UpdateRecordResponse
{
    [JsonProperty("Id")]
    public long Id { get; set; }

    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    [JsonProperty("Message")]
    public string? Message { get; set; }

    [JsonProperty("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }

    [JsonProperty("LimitPerDate")]
    public int? LimitPerDate { get; set; }

    [JsonProperty("LimitRemaining")]
    public int? LimitRemaining { get; set; }
}
