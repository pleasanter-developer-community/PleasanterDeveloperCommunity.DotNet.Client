using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Validation;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード一括作成・更新（BulkUpsert）リクエスト
/// </summary>
public class BulkUpsertRecordRequest : ApiRequest
{
    /// <summary>
    /// キーとなる項目名の配列
    /// </summary>
    [JsonPropertyName("Keys")]
    [RegexList(ColumnPatterns.ColumnNamePattern, ErrorMessage = "Keys の要素はプリザンターの有効な列名である必要があります。")]
    public List<string>? Keys { get; set; }

    /// <summary>
    /// キーと一致するレコードが無い場合に新規作成するかどうか（省略時：true）
    /// </summary>
    [JsonPropertyName("KeyNotFoundCreate")]
    public bool? KeyNotFoundCreate { get; set; }

    /// <summary>
    /// レコードデータの配列
    /// </summary>
    [JsonPropertyName("Data")]
    public List<BulkUpsertRecordData>? Data { get; set; }
}
