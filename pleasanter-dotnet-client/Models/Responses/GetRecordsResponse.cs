using Newtonsoft.Json;
using System.Collections.Generic;

namespace pleasanter_dotnet_client.Models.Responses;

/// <summary>
/// 複数レコード取得レスポンス
/// </summary>
public class GetRecordsResponse
{
    /// <summary>
    /// オフセット
    /// </summary>
    [JsonProperty("Offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// ページサイズ
    /// </summary>
    [JsonProperty("PageSize")]
    public int? PageSize { get; set; }

    /// <summary>
    /// 合計レコード数
    /// </summary>
    [JsonProperty("TotalCount")]
    public int? TotalCount { get; set; }

    /// <summary>
    /// レコードデータ
    /// </summary>
    [JsonProperty("Data")]
    public List<RecordData>? Data { get; set; }

    /// <summary>
    /// 次のページが存在するかを判定します
    /// </summary>
    public bool HasNextPage => Offset.HasValue && PageSize.HasValue && TotalCount.HasValue
        && (Offset.Value + PageSize.Value) < TotalCount.Value;
}
