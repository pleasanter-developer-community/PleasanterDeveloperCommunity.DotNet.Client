using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items
{
    /// <summary>
    /// 複数レコード取得リクエスト
    /// </summary>
    public class GetRecordsRequest : ApiRequestBase
    {
        /// <summary>
        /// オフセット
        /// </summary>
        [JsonPropertyName("Offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// ビュー設定
        /// </summary>
        [JsonPropertyName("View")]
        public View? View { get; set; }
    }
}
