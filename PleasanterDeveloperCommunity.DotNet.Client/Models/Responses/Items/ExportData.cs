using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// エクスポートデータ
/// </summary>
public class ExportData
{
    /// <summary>
    /// エクスポートファイル名
    /// </summary>
    [JsonProperty("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// エクスポートデータ内容（CSVまたはJSON形式の文字列）
    /// </summary>
    [JsonProperty("Content")]
    public string? Content { get; set; }
}
