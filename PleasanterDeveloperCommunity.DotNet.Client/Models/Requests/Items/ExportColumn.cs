using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// エクスポート列設定
/// </summary>
public class ExportColumn
{
    /// <summary>
    /// 列名
    /// </summary>
    [JsonPropertyName("ColumnName")]
    public string? ColumnName { get; set; }
}
