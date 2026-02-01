using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// エクスポートレスポンス
/// </summary>
public class ExportResponse
{
    [JsonProperty("Name")]
    public string? Name { get; set; }

    [JsonProperty("Content")]
    public string? Content { get; set; }
}
