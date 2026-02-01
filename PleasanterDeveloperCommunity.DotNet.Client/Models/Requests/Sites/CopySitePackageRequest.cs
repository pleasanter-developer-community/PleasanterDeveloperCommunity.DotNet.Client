using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイトパッケージコピーリクエスト
/// </summary>
public class CopySitePackageRequest : ApiRequestBase
{
    /// <summary>
    /// 選択したサイト一覧
    /// </summary>
    [JsonProperty("SelectedSites")]
    public List<SelectedSite>? SelectedSites { get; set; }

    /// <summary>
    /// コピー先サイトID
    /// </summary>
    [JsonProperty("TargetSiteId")]
    public long? TargetSiteId { get; set; }

    /// <summary>
    /// サイトタイトル
    /// </summary>
    [JsonProperty("SiteTitle")]
    public string? SiteTitle { get; set; }

    /// <summary>
    /// サイト権限を含める
    /// </summary>
    [JsonProperty("IncludeSitePermission")]
    public bool? IncludeSitePermission { get; set; }

    /// <summary>
    /// レコード権限を含める
    /// </summary>
    [JsonProperty("IncludeRecordPermission")]
    public bool? IncludeRecordPermission { get; set; }

    /// <summary>
    /// 列権限を含める
    /// </summary>
    [JsonProperty("IncludeColumnPermission")]
    public bool? IncludeColumnPermission { get; set; }

    /// <summary>
    /// 通知を含める
    /// </summary>
    [JsonProperty("IncludeNotifications")]
    public bool? IncludeNotifications { get; set; }

    /// <summary>
    /// リマインダーを含める
    /// </summary>
    [JsonProperty("IncludeReminders")]
    public bool? IncludeReminders { get; set; }
}
