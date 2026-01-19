using Newtonsoft.Json;
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
    [JsonProperty("TenantId")]
    public int TenantId { get; set; }

    /// <summary>
    /// サイトID
    /// </summary>
    [JsonProperty("SiteId")]
    public long SiteId { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    [JsonProperty("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    [JsonProperty("Ver")]
    public int Ver { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// サイト名
    /// </summary>
    [JsonProperty("SiteName")]
    public string? SiteName { get; set; }

    /// <summary>
    /// サイトグループ名
    /// </summary>
    [JsonProperty("SiteGroupName")]
    public string? SiteGroupName { get; set; }

    /// <summary>
    /// 一覧ガイド
    /// </summary>
    [JsonProperty("GridGuide")]
    public string? GridGuide { get; set; }

    /// <summary>
    /// エディタガイド
    /// </summary>
    [JsonProperty("EditorGuide")]
    public string? EditorGuide { get; set; }

    /// <summary>
    /// カレンダーガイド
    /// </summary>
    [JsonProperty("CalendarGuide")]
    public string? CalendarGuide { get; set; }

    /// <summary>
    /// クロス集計ガイド
    /// </summary>
    [JsonProperty("CrosstabGuide")]
    public string? CrosstabGuide { get; set; }

    /// <summary>
    /// ガントチャートガイド
    /// </summary>
    [JsonProperty("GanttGuide")]
    public string? GanttGuide { get; set; }

    /// <summary>
    /// バーンダウンチャートガイド
    /// </summary>
    [JsonProperty("BurnDownGuide")]
    public string? BurnDownGuide { get; set; }

    /// <summary>
    /// 時系列チャートガイド
    /// </summary>
    [JsonProperty("TimeSeriesGuide")]
    public string? TimeSeriesGuide { get; set; }

    /// <summary>
    /// カンバンガイド
    /// </summary>
    [JsonProperty("KambanGuide")]
    public string? KambanGuide { get; set; }

    /// <summary>
    /// 画像ライブラリガイド
    /// </summary>
    [JsonProperty("ImageLibGuide")]
    public string? ImageLibGuide { get; set; }

    /// <summary>
    /// 参照タイプ（Sites, Issues, Results, Wikis）
    /// </summary>
    [JsonProperty("ReferenceType")]
    public string? ReferenceType { get; set; }

    /// <summary>
    /// 親サイトID
    /// </summary>
    [JsonProperty("ParentId")]
    public long ParentId { get; set; }

    /// <summary>
    /// アクセス権の継承元サイトID
    /// </summary>
    [JsonProperty("InheritPermission")]
    public long InheritPermission { get; set; }

    /// <summary>
    /// アクセス権
    /// </summary>
    [JsonProperty("Permissions")]
    public List<object>? Permissions { get; set; }

    /// <summary>
    /// サイト設定
    /// </summary>
    [JsonProperty("SiteSettings")]
    public SiteSettingsType? SiteSettings { get; set; }

    /// <summary>
    /// 公開フラグ
    /// </summary>
    [JsonProperty("Publish")]
    public bool Publish { get; set; }

    /// <summary>
    /// クロスサイト検索無効フラグ
    /// </summary>
    [JsonProperty("DisableCrossSearch")]
    public bool DisableCrossSearch { get; set; }

    /// <summary>
    /// ロック日時
    /// </summary>
    [JsonProperty("LockedTime")]
    public DateTime? LockedTime { get; set; }

    /// <summary>
    /// ロックユーザID
    /// </summary>
    [JsonProperty("LockedUser")]
    public int LockedUser { get; set; }

    /// <summary>
    /// API呼び出し日付
    /// </summary>
    [JsonProperty("ApiCountDate")]
    public DateTime? ApiCountDate { get; set; }

    /// <summary>
    /// API呼び出し回数
    /// </summary>
    [JsonProperty("ApiCount")]
    public int ApiCount { get; set; }

    /// <summary>
    /// コメント
    /// </summary>
    [JsonProperty("Comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    [JsonProperty("Creator")]
    public int Creator { get; set; }

    /// <summary>
    /// 更新者ID
    /// </summary>
    [JsonProperty("Updator")]
    public int Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    [JsonProperty("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// APIバージョン
    /// </summary>
    [JsonProperty("ApiVersion")]
    public float ApiVersion { get; set; }

    /// <summary>
    /// 分類項目
    /// </summary>
    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    [JsonProperty("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 添付ファイル項目
    /// </summary>
    [JsonProperty("AttachmentsHash")]
    public Dictionary<string, object>? AttachmentsHash { get; set; }
}
