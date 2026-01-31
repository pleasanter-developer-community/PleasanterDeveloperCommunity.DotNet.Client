using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items
{
    /// <summary>
    /// エクスポート列
    /// </summary>
    public class ExportColumn
    {
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }
    }

    /// <summary>
    /// エクスポート設定
    /// </summary>
    public class ExportSetting
    {
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Columns")]
        public List<ExportColumn>? Columns { get; set; }

        [JsonPropertyName("Header")]
        public bool? Header { get; set; }

        [JsonPropertyName("Type")]
        public ExportType? Type { get; set; }
    }

    /// <summary>
    /// 一括Upsert用レコードデータ
    /// </summary>
    public class BulkUpsertRecordData
    {
        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        [JsonPropertyName("Status")]
        public int? Status { get; set; }

        [JsonPropertyName("Manager")]
        public int? Manager { get; set; }

        [JsonPropertyName("Owner")]
        public int? Owner { get; set; }

        [JsonPropertyName("CompletionTime")]
        public string? CompletionTime { get; set; }

        [JsonPropertyName("ClassHash")]
        public Dictionary<string, string>? ClassHash { get; set; }

        [JsonPropertyName("NumHash")]
        public Dictionary<string, decimal>? NumHash { get; set; }

        [JsonPropertyName("DateHash")]
        public Dictionary<string, DateTime>? DateHash { get; set; }

        [JsonPropertyName("DescriptionHash")]
        public Dictionary<string, string>? DescriptionHash { get; set; }

        [JsonPropertyName("CheckHash")]
        public Dictionary<string, bool>? CheckHash { get; set; }
    }
}
