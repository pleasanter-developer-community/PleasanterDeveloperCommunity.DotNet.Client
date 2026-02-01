using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード取得リクエスト
/// </summary>
public class GetRecordRequest : ApiRequestBase
{
    /// <summary>
    /// ビュー設定
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}
