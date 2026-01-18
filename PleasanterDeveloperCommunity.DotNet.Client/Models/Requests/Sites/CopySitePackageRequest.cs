using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイトコピーリクエスト
/// </summary>
public class CopySitePackageRequest : ApiRequest
{
    /// <summary>
    /// コピー先のフォルダのサイトID。省略する場合、トップ画面にコピーします。
    /// </summary>
    [JsonProperty("TargetSiteId")]
    public long? TargetSiteId { get; set; }

    /// <summary>
    /// サイトのタイトル。サイトのタイトルを変更する場合に使用してください。
    /// </summary>
    [JsonProperty("SiteTitle")]
    public string? SiteTitle { get; set; }

    /// <summary>
    /// コピーするサイトの一覧
    /// </summary>
    [JsonProperty("SelectedSites")]
    public List<SelectedSite>? SelectedSites { get; set; }

    /// <summary>
    /// サイトのアクセス権を含めるかどうか
    /// </summary>
    [JsonProperty("IncludeSitePermission")]
    public bool? IncludeSitePermission { get; set; }

    /// <summary>
    /// レコードのアクセス権を含めるかどうか
    /// </summary>
    [JsonProperty("IncludeRecordPermission")]
    public bool? IncludeRecordPermission { get; set; }

    /// <summary>
    /// 項目のアクセス権を含めるかどうか
    /// </summary>
    [JsonProperty("IncludeColumnPermission")]
    public bool? IncludeColumnPermission { get; set; }

    /// <summary>
    /// 通知設定を含めるかどうか
    /// </summary>
    [JsonProperty("IncludeNotifications")]
    public bool? IncludeNotifications { get; set; }

    /// <summary>
    /// リマインダー設定を含めるかどうか
    /// </summary>
    [JsonProperty("IncludeReminders")]
    public bool? IncludeReminders { get; set; }
}
