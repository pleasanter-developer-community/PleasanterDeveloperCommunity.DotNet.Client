using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// エクスポートレスポンス
/// </summary>
public class ExportResponse
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("Content")]
    public string? Content { get; set; }
}
