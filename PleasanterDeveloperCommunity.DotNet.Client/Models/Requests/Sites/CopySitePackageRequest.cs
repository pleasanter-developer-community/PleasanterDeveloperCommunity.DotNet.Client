using System.Text.Json.Serialization;
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
    [JsonPropertyName("TargetSiteId")]
    public long? TargetSiteId { get; set; }

    /// <summary>
    /// サイトのタイトル。サイトのタイトルを変更する場合に使用してください。
    /// </summary>
    [JsonPropertyName("SiteTitle")]
    public string? SiteTitle { get; set; }

    /// <summary>
    /// コピーするサイトの一覧
    /// </summary>
    [JsonPropertyName("SelectedSites")]
    public List<SelectedSite>? SelectedSites { get; set; }

    /// <summary>
    /// サイトのアクセス権を含めるかどうか
    /// </summary>
    [JsonPropertyName("IncludeSitePermission")]
    public bool? IncludeSitePermission { get; set; }

    /// <summary>
    /// レコードのアクセス権を含めるかどうか
    /// </summary>
    [JsonPropertyName("IncludeRecordPermission")]
    public bool? IncludeRecordPermission { get; set; }

    /// <summary>
    /// 項目のアクセス権を含めるかどうか
    /// </summary>
    [JsonPropertyName("IncludeColumnPermission")]
    public bool? IncludeColumnPermission { get; set; }

    /// <summary>
    /// 通知設定を含めるかどうか
    /// </summary>
    [JsonPropertyName("IncludeNotifications")]
    public bool? IncludeNotifications { get; set; }

    /// <summary>
    /// リマインダー設定を含めるかどうか
    /// </summary>
    [JsonPropertyName("IncludeReminders")]
    public bool? IncludeReminders { get; set; }
}
