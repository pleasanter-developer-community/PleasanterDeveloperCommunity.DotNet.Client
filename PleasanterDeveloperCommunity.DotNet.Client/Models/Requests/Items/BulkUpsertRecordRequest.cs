using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// 一括Upsertリクエスト
/// </summary>
public class BulkUpsertRecordRequest : ApiRequestBase
{
    /// <summary>
    /// レコードデータ
    /// </summary>
    public List<BulkUpsertRecordData>? Data { get; set; }

    /// <summary>
    /// キー項目
    /// </summary>
    public List<string>? Keys { get; set; }

    /// <summary>
    /// キーに一致するレコードがない場合に作成するかどうか
    /// </summary>
    public bool? KeyNotFoundCreate { get; set; }
}
