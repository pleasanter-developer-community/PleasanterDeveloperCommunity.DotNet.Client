using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// コピー対象サイト
/// </summary>
public class SelectedSite
{
    [JsonProperty("SiteId")]
    public long SiteId { get; set; }

    [JsonProperty("IncludeData")]
    public bool? IncludeData { get; set; }
}
