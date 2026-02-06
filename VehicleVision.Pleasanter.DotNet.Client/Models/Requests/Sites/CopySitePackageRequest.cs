using System.Collections.Generic;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイトパッケージコピーリクエスト
/// </summary>
public class CopySitePackageRequest : ApiRequestBase
{
    /// <summary>
    /// 選択したサイト一覧
    /// </summary>
    public List<SelectedSite>? SelectedSites { get; set; }

    /// <summary>
    /// コピー先サイトID
    /// </summary>
    public long? TargetSiteId { get; set; }

    /// <summary>
    /// サイトタイトル
    /// </summary>
    public string? SiteTitle { get; set; }

    /// <summary>
    /// サイト権限を含める
    /// </summary>
    public bool? IncludeSitePermission { get; set; }

    /// <summary>
    /// レコード権限を含める
    /// </summary>
    public bool? IncludeRecordPermission { get; set; }

    /// <summary>
    /// 列権限を含める
    /// </summary>
    public bool? IncludeColumnPermission { get; set; }

    /// <summary>
    /// 通知を含める
    /// </summary>
    public bool? IncludeNotifications { get; set; }

    /// <summary>
    /// リマインダーを含める
    /// </summary>
    public bool? IncludeReminders { get; set; }
}
