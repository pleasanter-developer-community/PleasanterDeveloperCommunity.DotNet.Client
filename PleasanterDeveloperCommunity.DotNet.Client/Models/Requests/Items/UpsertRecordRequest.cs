using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Validation;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード作成・更新（Upsert）リクエスト
/// </summary>
public class UpsertRecordRequest : RecordRequestBase
{
    /// <summary>
    /// キーとなる項目名の配列
    /// </summary>
    [JsonProperty("Keys")]
    [RegexList(ColumnPatterns.ColumnNamePattern, ErrorMessage = "Keys の要素はプリザンターの有効な列名である必要があります。")]
    public List<string>? Keys { get; set; }
}
