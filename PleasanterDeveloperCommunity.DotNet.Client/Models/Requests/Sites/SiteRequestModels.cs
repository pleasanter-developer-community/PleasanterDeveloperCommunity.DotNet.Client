using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// コピー対象サイト
/// </summary>
public class SelectedSite
{
    public long SiteId { get; set; }

    public bool? IncludeData { get; set; }
}
