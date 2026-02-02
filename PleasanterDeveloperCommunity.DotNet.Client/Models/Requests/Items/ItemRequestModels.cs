using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// エクスポート列
/// </summary>
public class ExportColumn
{
    public string? ColumnName { get; set; }
}

/// <summary>
/// エクスポート設定
/// </summary>
public class ExportSetting
{
    public string? Name { get; set; }

    public List<ExportColumn>? Columns { get; set; }

    public bool? Header { get; set; }

    public ExportType? Type { get; set; }
}

/// <summary>
/// 一括Upsert用レコードデータ
/// </summary>
public class BulkUpsertRecordData
{
    public string? Title { get; set; }

    public string? Body { get; set; }

    public int? Status { get; set; }

    public int? Manager { get; set; }

    public int? Owner { get; set; }

    public string? CompletionTime { get; set; }

    public Dictionary<string, string>? ClassHash { get; set; }

    public Dictionary<string, decimal>? NumHash { get; set; }

    public Dictionary<string, DateTime>? DateHash { get; set; }

    public Dictionary<string, string>? DescriptionHash { get; set; }

    public Dictionary<string, bool>? CheckHash { get; set; }
}
