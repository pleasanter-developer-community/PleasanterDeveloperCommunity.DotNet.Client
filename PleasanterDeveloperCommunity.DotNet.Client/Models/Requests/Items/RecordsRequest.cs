using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// 複数レコード取得リクエスト
/// </summary>
public class RecordsRequest : ApiRequest
{
    /// <summary>
    /// オフセット（取得開始位置）
    /// </summary>
    [JsonPropertyName("Offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// ビュー設定（フィルタや並び替えなど）
    /// </summary>
    [JsonPropertyName("View")]
    public View? View { get; set; }
}
