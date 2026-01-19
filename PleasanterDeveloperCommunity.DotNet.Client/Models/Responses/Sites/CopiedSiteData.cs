using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// コピーされたサイトの情報
/// </summary>
public class CopiedSiteData
{
    /// <summary>
    /// コピー元のサイトID
    /// </summary>
    [JsonPropertyName("OldSiteId")]
    public long OldSiteId { get; set; }

    /// <summary>
    /// コピー先の新しいサイトID
    /// </summary>
    [JsonPropertyName("NewSiteId")]
    public long NewSiteId { get; set; }

    /// <summary>
    /// 参照タイプ（Sites, Results, Issuesなど）
    /// </summary>
    [JsonPropertyName("ReferenceType")]
    public string? ReferenceType { get; set; }

    /// <summary>
    /// サイトのタイトル
    /// </summary>
    [JsonPropertyName("Title")]
    public string? Title { get; set; }
}
