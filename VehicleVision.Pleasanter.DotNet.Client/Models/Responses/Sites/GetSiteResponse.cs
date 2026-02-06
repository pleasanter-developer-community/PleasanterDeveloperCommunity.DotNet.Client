using System;
using System.Collections.Generic;
using VehicleVision.Pleasanter.DotNet.Client.Models.Common;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト取得レスポンス
/// </summary>
public class GetSiteResponse
{
    /// <summary>
    /// サイトデータ
    /// </summary>
    public GetSiteData? Data { get; set; }
}

/// <summary>
/// サイト取得データ
/// </summary>
public class GetSiteData
{
    /// <summary>
    /// テナントID
    /// </summary>
    public int TenantId { get; set; }

    /// <summary>
    /// サイトID
    /// </summary>
    public long SiteId { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    public int Ver { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 本文
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// サイト名
    /// </summary>
    public string? SiteName { get; set; }

    /// <summary>
    /// サイトグループ名
    /// </summary>
    public string? SiteGroupName { get; set; }

    /// <summary>
    /// グリッドガイド
    /// </summary>
    public string? GridGuide { get; set; }

    /// <summary>
    /// エディタガイド
    /// </summary>
    public string? EditorGuide { get; set; }

    /// <summary>
    /// カレンダーガイド
    /// </summary>
    public string? CalendarGuide { get; set; }

    /// <summary>
    /// クロス集計ガイド
    /// </summary>
    public string? CrosstabGuide { get; set; }

    /// <summary>
    /// ガントガイド
    /// </summary>
    public string? GanttGuide { get; set; }

    /// <summary>
    /// バーンダウンガイド
    /// </summary>
    public string? BurnDownGuide { get; set; }

    /// <summary>
    /// 時系列ガイド
    /// </summary>
    public string? TimeSeriesGuide { get; set; }

    /// <summary>
    /// カンバンガイド
    /// </summary>
    public string? KambanGuide { get; set; }

    /// <summary>
    /// 画像ライブラリガイド
    /// </summary>
    public string? ImageLibGuide { get; set; }

    /// <summary>
    /// 参照タイプ
    /// </summary>
    public string? ReferenceType { get; set; }

    /// <summary>
    /// 親サイトID
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 権限継承元サイトID
    /// </summary>
    public long InheritPermission { get; set; }

    /// <summary>
    /// 権限リスト
    /// </summary>
    public List<object>? Permissions { get; set; }

    /// <summary>
    /// サイト設定
    /// </summary>
    public SiteSettings? SiteSettings { get; set; }

    /// <summary>
    /// 公開フラグ
    /// </summary>
    public bool Publish { get; set; }

    /// <summary>
    /// 横断検索無効フラグ
    /// </summary>
    public bool DisableCrossSearch { get; set; }

    /// <summary>
    /// ロック日時
    /// </summary>
    public DateTime? LockedTime { get; set; }

    /// <summary>
    /// ロックユーザID
    /// </summary>
    public int LockedUser { get; set; }

    /// <summary>
    /// APIカウント日
    /// </summary>
    public DateTime? ApiCountDate { get; set; }

    /// <summary>
    /// APIカウント
    /// </summary>
    public int ApiCount { get; set; }

    /// <summary>
    /// コメント
    /// </summary>
    public string? Comments { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    public int Creator { get; set; }

    /// <summary>
    /// 更新者ID
    /// </summary>
    public int Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// APIバージョン
    /// </summary>
    public float ApiVersion { get; set; }

    /// <summary>
    /// 分類項目ハッシュ
    /// </summary>
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目ハッシュ
    /// </summary>
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目ハッシュ
    /// </summary>
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目ハッシュ
    /// </summary>
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目ハッシュ
    /// </summary>
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 添付ファイルハッシュ
    /// </summary>
    public Dictionary<string, object>? AttachmentsHash { get; set; }
}
