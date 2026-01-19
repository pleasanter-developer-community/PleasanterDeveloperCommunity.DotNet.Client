using System.Text.Json.Serialization;
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
    [JsonPropertyName("TenantId")]
    public int? TenantId { get; set; }

    /// <summary>
    /// サイトのタイトル
    /// </summary>
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 参照タイプ（Sites, Issues, Results, Wikis のいずれか）
    /// </summary>
    [JsonPropertyName("ReferenceType")]
    public SiteReferenceType? ReferenceType { get; set; }

    /// <summary>
    /// 親サイトID
    /// </summary>
    [JsonPropertyName("ParentId")]
    public long? ParentId { get; set; }

    /// <summary>
    /// アクセス権の継承元サイトID
    /// </summary>
    [JsonPropertyName("InheritPermission")]
    public long? InheritPermission { get; set; }

    /// <summary>
    /// サイト設定（サイトパッケージのSiteパラメータと同等の形式）
    /// </summary>
    /// <remarks>
    /// SiteSettingsには、GridColumns、EditorColumnHash、その他のサイト設定を指定できます。
    /// 詳細なスキーマについては、サイトパッケージのエクスポート結果を参照してください。
    /// </remarks>
    [JsonPropertyName("SiteSettings")]
    public SiteSettingsType? SiteSettings { get; set; }
}
