using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items
{
    /// <summary>
    /// エクスポートリクエスト
    /// </summary>
    public class ExportRequest : ApiRequestBase
    {
        /// <summary>
        /// エクスポート設定ID
        /// </summary>
        [JsonPropertyName("ExportId")]
        public int? ExportId { get; set; }

        /// <summary>
        /// エクスポート設定
        /// </summary>
        [JsonPropertyName("Export")]
        public ExportSetting? Export { get; set; }

        /// <summary>
        /// ビュー設定
        /// </summary>
        [JsonPropertyName("View")]
        public View? View { get; set; }
    }
}
