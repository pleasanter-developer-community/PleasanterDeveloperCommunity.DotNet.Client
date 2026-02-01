using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイト設定更新リクエスト（部分更新）
/// </summary>
public class UpdateSiteSettingsRequest : ApiRequestBase
{
    /// <summary>
    /// サイト設定
    /// </summary>
    [JsonPropertyName("SiteSettings")]
    public SiteSettings? SiteSettings { get; set; }
}
