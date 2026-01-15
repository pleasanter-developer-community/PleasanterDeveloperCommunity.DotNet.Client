using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード取得リクエスト
/// </summary>
public class RecordRequest : ApiRequest
{
    /// <summary>
    /// ビュー設定（フィルタや並び替えなど）
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}
