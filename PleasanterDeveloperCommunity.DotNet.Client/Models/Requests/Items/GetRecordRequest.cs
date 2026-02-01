using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード取得リクエスト
/// </summary>
public class GetRecordRequest : ApiRequestBase
{
    /// <summary>
    /// ビュー設定
    /// </summary>
    [JsonPropertyName("View")]
    public View? View { get; set; }
}
