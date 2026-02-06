using VehicleVision.Pleasanter.DotNet.Client.Models.Common;
using VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Types;
using System;
using System.Collections.Generic;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Items;

/// <summary>
/// エクスポート列
/// </summary>
public class ExportColumn
{
    /// <summary>
    /// 列名
    /// </summary>
    public string? ColumnName { get; set; }
}

/// <summary>
/// エクスポート設定
/// </summary>
public class ExportSetting
{
    /// <summary>
    /// エクスポート名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// エクスポート対象列
    /// </summary>
    public List<ExportColumn>? Columns { get; set; }

    /// <summary>
    /// ヘッダーを含めるか
    /// </summary>
    public bool? Header { get; set; }

    /// <summary>
    /// エクスポートタイプ
    /// </summary>
    public ExportType? Type { get; set; }
}

/// <summary>
/// 一括Upsert用レコードデータ
/// </summary>
public class BulkUpsertRecordData
{
    /// <summary>
    /// タイトル
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 本文
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// 状態
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 管理者
    /// </summary>
    public int? Manager { get; set; }

    /// <summary>
    /// 担当者
    /// </summary>
    public int? Owner { get; set; }

    /// <summary>
    /// 完了日時
    /// </summary>
    public string? CompletionTime { get; set; }

    /// <summary>
    /// 分類項目
    /// </summary>
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
    public Dictionary<string, bool>? CheckHash { get; set; }
}
