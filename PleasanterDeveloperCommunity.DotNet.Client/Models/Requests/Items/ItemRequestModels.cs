using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// エクスポート列
/// </summary>
public class ExportColumn
{
    [JsonProperty("ColumnName")]
    public string? ColumnName { get; set; }
}

/// <summary>
/// エクスポート設定
/// </summary>
public class ExportSetting
{
    [JsonProperty("Name")]
    public string? Name { get; set; }

    [JsonProperty("Columns")]
    public List<ExportColumn>? Columns { get; set; }

    [JsonProperty("Header")]
    public bool? Header { get; set; }

    [JsonProperty("Type")]
    public ExportType? Type { get; set; }
}

/// <summary>
/// 一括Upsert用レコードデータ
/// </summary>
public class BulkUpsertRecordData
{
    [JsonProperty("Title")]
    public string? Title { get; set; }

    [JsonProperty("Body")]
    public string? Body { get; set; }

    [JsonProperty("Status")]
    public int? Status { get; set; }

    [JsonProperty("Manager")]
    public int? Manager { get; set; }

    [JsonProperty("Owner")]
    public int? Owner { get; set; }

    [JsonProperty("CompletionTime")]
    public string? CompletionTime { get; set; }

    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    [JsonProperty("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }
}
