using VehicleVision.Pleasanter.DotNet.Client.Models.Common;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイト更新リクエスト
/// </summary>
public class UpdateSiteRequest : ApiRequestBase
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
    /// 親サイトID
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// 権限継承元サイトID
    /// </summary>
    public long? InheritPermission { get; set; }

    /// <summary>
    /// サイト設定
    /// </summary>
    public SiteSettings? SiteSettings { get; set; }
}
