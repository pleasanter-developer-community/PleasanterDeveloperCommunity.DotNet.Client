using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using SiteSettingsType = PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettings;
using System.ComponentModel.DataAnnotations;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイト作成リクエスト
/// </summary>
public class CreateSiteRequest : ApiRequest
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
    [Required(ErrorMessage = "Title は必須です。")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 参照タイプ（Sites, Issues, Results, Wikis のいずれか）
    /// </summary>
    [JsonPropertyName("ReferenceType")]
    [Required(ErrorMessage = "ReferenceType は必須です。")]
    public SiteReferenceType ReferenceType { get; set; }

    /// <summary>
    /// 親サイトID（省略時はAPIリクエストURLで指定した親サイトID配下に作成されます）
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
