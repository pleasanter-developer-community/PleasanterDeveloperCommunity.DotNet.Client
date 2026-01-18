using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// コピーされたサイトの情報
/// </summary>
public class CopiedSiteData
{
    /// <summary>
    /// コピー元のサイトID
    /// </summary>
    [JsonProperty("OldSiteId")]
    public long OldSiteId { get; set; }

    /// <summary>
    /// コピー先の新しいサイトID
    /// </summary>
    [JsonProperty("NewSiteId")]
    public long NewSiteId { get; set; }

    /// <summary>
    /// 参照タイプ（Sites, Results, Issuesなど）
    /// </summary>
    [JsonProperty("ReferenceType")]
    public string? ReferenceType { get; set; }

    /// <summary>
    /// サイトのタイトル
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }
}
