using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 一括Upsertレスポンス
/// </summary>
public class BulkUpsertRecordResponse
{
    [JsonProperty("Id")]
    public long Id { get; set; }

    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    [JsonProperty("Message")]
    public string? Message { get; set; }

    [JsonProperty("Created")]
    public int? Created { get; set; }

    [JsonProperty("Updated")]
    public int? Updated { get; set; }
}
