using VehicleVision.Pleasanter.DotNet.Client.Models.Common;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイト設定更新リクエスト（部分更新）
/// </summary>
public class UpdateSiteSettingsRequest : ApiRequestBase
{
    /// <summary>
    /// サイト設定
    /// </summary>
    public SiteSettings? SiteSettings { get; set; }
}
