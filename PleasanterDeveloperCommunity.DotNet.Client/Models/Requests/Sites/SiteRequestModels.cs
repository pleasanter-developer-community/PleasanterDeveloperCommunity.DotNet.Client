using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// コピー対象サイト
/// </summary>
public class SelectedSite
{
    /// <summary>
    /// サイトID
    /// </summary>
    public long SiteId { get; set; }

    /// <summary>
    /// データを含めるか
    /// </summary>
    public bool? IncludeData { get; set; }
}
