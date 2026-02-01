using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコード作成レスポンス
/// </summary>
public class CreateRecordResponse
{
    [JsonProperty("Id")]
    public long Id { get; set; }

    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    [JsonProperty("Message")]
    public string? Message { get; set; }

    [JsonProperty("LimitPerDate")]
    public int? LimitPerDate { get; set; }

    [JsonProperty("LimitRemaining")]
    public int? LimitRemaining { get; set; }
}
