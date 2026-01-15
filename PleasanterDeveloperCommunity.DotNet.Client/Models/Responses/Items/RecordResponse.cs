using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 単一レコード取得レスポンス
/// </summary>
public class RecordResponse
{
    /// <summary>
    /// レコードデータ
    /// </summary>
    [JsonProperty("Data")]
    public List<RecordData>? Data { get; set; }
}
