using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using SiteSettingsType = PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettings;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイト更新リクエスト
/// </summary>
public class UpdateSiteRequest : ApiRequest
{
    /// <summary>
    /// テナントID
    /// </summary>
    [JsonProperty("TenantId")]
    public int? TenantId { get; set; }

    /// <summary>
    /// サイトのタイトル
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 参照タイプ（Sites, Issues, Results, Wikis のいずれか）
    /// </summary>
    [JsonProperty("ReferenceType")]
    public SiteReferenceType? ReferenceType { get; set; }

    /// <summary>
    /// 親サイトID
    /// </summary>
    [JsonProperty("ParentId")]
    public long? ParentId { get; set; }

    /// <summary>
    /// アクセス権の継承元サイトID
    /// </summary>
    [JsonProperty("InheritPermission")]
    public long? InheritPermission { get; set; }

    /// <summary>
    /// サイト設定（サイトパッケージのSiteパラメータと同等の形式）
    /// </summary>
    /// <remarks>
    /// SiteSettingsには、GridColumns、EditorColumnHash、その他のサイト設定を指定できます。
    /// 詳細なスキーマについては、サイトパッケージのエクスポート結果を参照してください。
    /// </remarks>
    [JsonProperty("SiteSettings")]
    public SiteSettingsType? SiteSettings { get; set; }
}
