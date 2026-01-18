using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード一括削除リクエスト
/// </summary>
public class BulkDeleteRecordRequest : ApiRequest
{
    /// <summary>
    /// ビュー設定（削除対象のフィルタ条件）
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }

    /// <summary>
    /// 削除するレコードのIDリスト
    /// </summary>
    [JsonProperty("Selected")]
    public List<long>? Selected { get; set; }

    /// <summary>
    /// テーブルのすべてのレコードを一括削除する場合true
    /// </summary>
    [JsonProperty("All")]
    public bool? All { get; set; }

    /// <summary>
    /// レコード削除と同時に変更履歴およびごみ箱から削除する場合はtrue
    /// </summary>
    [JsonProperty("PhysicalDelete")]
    public bool? PhysicalDelete { get; set; }
}
