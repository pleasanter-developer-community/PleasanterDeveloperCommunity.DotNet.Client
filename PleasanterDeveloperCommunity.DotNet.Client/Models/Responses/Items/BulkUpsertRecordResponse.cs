using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 一括Upsertレスポンス
/// </summary>
public class BulkUpsertRecordResponse
{
    [JsonPropertyName("Id")]
    public long Id { get; set; }

    [JsonPropertyName("StatusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("Message")]
    public string? Message { get; set; }

    [JsonPropertyName("Created")]
    public int? Created { get; set; }

    [JsonPropertyName("Updated")]
    public int? Updated { get; set; }
}
