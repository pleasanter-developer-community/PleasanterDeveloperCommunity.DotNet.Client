using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// 複数レコード取得リクエスト
/// </summary>
public class GetRecordsRequest : ApiRequestBase
{
    /// <summary>
    /// オフセット
    /// </summary>
    [JsonProperty("Offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// ビュー設定
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}
