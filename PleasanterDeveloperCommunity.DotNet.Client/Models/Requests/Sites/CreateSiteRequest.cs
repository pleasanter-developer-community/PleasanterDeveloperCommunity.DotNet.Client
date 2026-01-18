using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
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
    [JsonProperty("TenantId")]
    public int? TenantId { get; set; }

    /// <summary>
    /// サイトのタイトル
    /// </summary>
    [JsonProperty("Title")]
    [Required(ErrorMessage = "Title は必須です。")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 参照タイプ（Sites, Issues, Results, Wikis のいずれか）
    /// </summary>
    [JsonProperty("ReferenceType")]
    [Required(ErrorMessage = "ReferenceType は必須です。")]
    public SiteReferenceType ReferenceType { get; set; }

    /// <summary>
    /// 親サイトID（省略時はAPIリクエストURLで指定した親サイトID配下に作成されます）
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
    /// SiteSettingsには、GridColumns、EditorColumnHash、その他のサイト設定をJSON形式で指定できます。
    /// 詳細なスキーマについては、サイトパッケージのエクスポート結果を参照してください。
    /// </remarks>
    [JsonProperty("SiteSettings")]
    public object? SiteSettings { get; set; }
}
