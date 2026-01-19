using System.Text.Json.Serialization;
using SiteSettingsType = PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettings;
using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト取得レスポンス
/// </summary>
public class GetSiteResponse : DataResponseBase<GetSiteData>
{
}

/// <summary>
/// サイトデータ
/// </summary>
public class GetSiteData
{
    /// <summary>
    /// テナントID
    /// </summary>
    [JsonPropertyName("TenantId")]
    public int TenantId { get; set; }

    /// <summary>
    /// サイトID
    /// </summary>
    [JsonPropertyName("SiteId")]
    public long SiteId { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    [JsonPropertyName("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    [JsonPropertyName("Ver")]
    public int Ver { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonPropertyName("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// サイト名
    /// </summary>
    [JsonPropertyName("SiteName")]
    public string? SiteName { get; set; }

    /// <summary>
    /// サイトグループ名
    /// </summary>
    [JsonPropertyName("SiteGroupName")]
    public string? SiteGroupName { get; set; }

    /// <summary>
    /// 一覧ガイド
    /// </summary>
    [JsonPropertyName("GridGuide")]
    public string? GridGuide { get; set; }

    /// <summary>
    /// エディタガイド
    /// </summary>
    [JsonPropertyName("EditorGuide")]
    public string? EditorGuide { get; set; }

    /// <summary>
    /// カレンダーガイド
    /// </summary>
    [JsonPropertyName("CalendarGuide")]
    public string? CalendarGuide { get; set; }

    /// <summary>
    /// クロス集計ガイド
    /// </summary>
    [JsonPropertyName("CrosstabGuide")]
    public string? CrosstabGuide { get; set; }

    /// <summary>
    /// ガントチャートガイド
    /// </summary>
    [JsonPropertyName("GanttGuide")]
    public string? GanttGuide { get; set; }

    /// <summary>
    /// バーンダウンチャートガイド
    /// </summary>
    [JsonPropertyName("BurnDownGuide")]
    public string? BurnDownGuide { get; set; }

    /// <summary>
    /// 時系列チャートガイド
    /// </summary>
    [JsonPropertyName("TimeSeriesGuide")]
    public string? TimeSeriesGuide { get; set; }

    /// <summary>
    /// カンバンガイド
    /// </summary>
    [JsonPropertyName("KambanGuide")]
    public string? KambanGuide { get; set; }

    /// <summary>
    /// 画像ライブラリガイド
    /// </summary>
    [JsonPropertyName("ImageLibGuide")]
    public string? ImageLibGuide { get; set; }

    /// <summary>
    /// 参照タイプ（Sites, Issues, Results, Wikis）
    /// </summary>
    [JsonPropertyName("ReferenceType")]
    public string? ReferenceType { get; set; }

    /// <summary>
    /// 親サイトID
    /// </summary>
    [JsonPropertyName("ParentId")]
    public long ParentId { get; set; }

    /// <summary>
    /// アクセス権の継承元サイトID
    /// </summary>
    [JsonPropertyName("InheritPermission")]
    public long InheritPermission { get; set; }

    /// <summary>
    /// アクセス権
    /// </summary>
    [JsonPropertyName("Permissions")]
    public List<object>? Permissions { get; set; }

    /// <summary>
    /// サイト設定
    /// </summary>
    [JsonPropertyName("SiteSettings")]
    public SiteSettingsType? SiteSettings { get; set; }

    /// <summary>
    /// 公開フラグ
    /// </summary>
    [JsonPropertyName("Publish")]
    public bool Publish { get; set; }

    /// <summary>
    /// クロスサイト検索無効フラグ
    /// </summary>
    [JsonPropertyName("DisableCrossSearch")]
    public bool DisableCrossSearch { get; set; }

    /// <summary>
    /// ロック日時
    /// </summary>
    [JsonPropertyName("LockedTime")]
    public DateTime? LockedTime { get; set; }

    /// <summary>
    /// ロックユーザID
    /// </summary>
    [JsonPropertyName("LockedUser")]
    public int LockedUser { get; set; }

    /// <summary>
    /// API呼び出し日付
    /// </summary>
    [JsonPropertyName("ApiCountDate")]
    public DateTime? ApiCountDate { get; set; }

    /// <summary>
    /// API呼び出し回数
    /// </summary>
    [JsonPropertyName("ApiCount")]
    public int ApiCount { get; set; }

    /// <summary>
    /// コメント
    /// </summary>
    [JsonPropertyName("Comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    [JsonPropertyName("Creator")]
    public int Creator { get; set; }

    /// <summary>
    /// 更新者ID
    /// </summary>
    [JsonPropertyName("Updator")]
    public int Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    [JsonPropertyName("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// APIバージョン
    /// </summary>
    [JsonPropertyName("ApiVersion")]
    public float ApiVersion { get; set; }

    /// <summary>
    /// 分類項目
    /// </summary>
    [JsonPropertyName("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    [JsonPropertyName("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    [JsonPropertyName("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    [JsonPropertyName("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
    [JsonPropertyName("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 添付ファイル項目
    /// </summary>
    [JsonPropertyName("AttachmentsHash")]
    public Dictionary<string, object>? AttachmentsHash { get; set; }
}
