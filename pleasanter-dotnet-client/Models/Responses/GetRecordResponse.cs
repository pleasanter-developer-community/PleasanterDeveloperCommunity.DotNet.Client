using Newtonsoft.Json;
using System.Collections.Generic;

namespace pleasanter_dotnet_client.Models.Responses;

/// <summary>
/// 単一レコード取得レスポンス
/// </summary>
public class GetRecordResponse
{
    /// <summary>
    /// レコードデータ
    /// </summary>
    [JsonProperty("Data")]
    public List<RecordData>? Data { get; set; }
}
