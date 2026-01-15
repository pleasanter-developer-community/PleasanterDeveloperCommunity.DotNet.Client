using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// 複数レコード取得リクエスト
/// </summary>
public class RecordsRequest : ApiRequest
{
    /// <summary>
    /// オフセット（取得開始位置）
    /// </summary>
    [JsonProperty("Offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// ビュー設定（フィルタや並び替えなど）
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}
