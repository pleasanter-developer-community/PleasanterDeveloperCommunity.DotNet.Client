using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// コピー対象サイトの設定
/// </summary>
public class SelectedSite
{
    /// <summary>
    /// コピー対象のサイトID
    /// </summary>
    [JsonPropertyName("SiteId")]
    public long SiteId { get; set; }

    /// <summary>
    /// データを含めるかどうか（省略時：true）
    /// </summary>
    [JsonPropertyName("IncludeData")]
    public bool? IncludeData { get; set; }
}
