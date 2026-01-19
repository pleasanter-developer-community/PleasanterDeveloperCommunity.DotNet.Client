using System.Collections.Generic;
using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// エクスポート設定
/// </summary>
public class ExportSetting
{
    /// <summary>
    /// エクスポート設定の名前
    /// </summary>
    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// 出力対象となる項目
    /// </summary>
    [JsonPropertyName("Columns")]
    public List<ExportColumn>? Columns { get; set; }

    /// <summary>
    /// 出力するCSVにヘッダ行を追加するか否か
    /// </summary>
    [JsonPropertyName("Header")]
    public bool? Header { get; set; }

    /// <summary>
    /// 出力するファイルの種類（Csv または Json）
    /// </summary>
    [JsonPropertyName("Type")]
    public ExportType? Type { get; set; }
}
