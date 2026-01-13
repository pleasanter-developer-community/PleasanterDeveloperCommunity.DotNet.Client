using Newtonsoft.Json;

namespace pleasanter_dotnet_client.Models.Requests;

/// <summary>
/// レコード取得リクエスト
/// </summary>
public class GetRecordRequest : ApiRequest
{
    /// <summary>
    /// ビュー設定（フィルタや並び替えなど）
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}
