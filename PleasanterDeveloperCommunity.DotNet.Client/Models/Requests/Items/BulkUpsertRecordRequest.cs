using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// 一括Upsertリクエスト
/// </summary>
public class BulkUpsertRecordRequest : ApiRequestBase
{
    /// <summary>
    /// レコードデータ
    /// </summary>
    [JsonProperty("Data")]
    public List<BulkUpsertRecordData>? Data { get; set; }

    /// <summary>
    /// キー項目
    /// </summary>
    [JsonProperty("Keys")]
    public List<string>? Keys { get; set; }

    /// <summary>
    /// キーに一致するレコードがない場合に作成するかどうか
    /// </summary>
    [JsonProperty("KeyNotFoundCreate")]
    public bool? KeyNotFoundCreate { get; set; }
}
