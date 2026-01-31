using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items
{
    /// <summary>
    /// 一括削除リクエスト
    /// </summary>
    public class BulkDeleteRecordRequest : ApiRequestBase
    {
        /// <summary>
        /// 削除対象レコードID一覧
        /// </summary>
        [JsonPropertyName("Selected")]
        public List<long>? Selected { get; set; }

        /// <summary>
        /// ビュー設定
        /// </summary>
        [JsonPropertyName("View")]
        public View? View { get; set; }

        /// <summary>
        /// 全削除フラグ
        /// </summary>
        [JsonPropertyName("All")]
        public bool? All { get; set; }

        /// <summary>
        /// 物理削除フラグ
        /// </summary>
        [JsonPropertyName("PhysicalDelete")]
        public bool? PhysicalDelete { get; set; }
    }
}
