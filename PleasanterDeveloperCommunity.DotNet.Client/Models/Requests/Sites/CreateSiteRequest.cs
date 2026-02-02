using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイト作成リクエスト
/// </summary>
public class CreateSiteRequest : ApiRequestBase
{
    /// <summary>
    /// タイトル
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 参照タイプ
    /// </summary>
    public string? ReferenceType { get; set; }

    /// <summary>
    /// テナントID
    /// </summary>
    public int? TenantId { get; set; }

    /// <summary>
    /// 権限継承元サイトID
    /// </summary>
    public long? InheritPermission { get; set; }

    /// <summary>
    /// サイト設定
    /// </summary>
    public SiteSettings? SiteSettings { get; set; }
}
