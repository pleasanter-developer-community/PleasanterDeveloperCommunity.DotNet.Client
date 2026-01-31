using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items
{
    /// <summary>
    /// 一括Upsertリクエスト
    /// </summary>
    public class BulkUpsertRecordRequest : ApiRequestBase
    {
        /// <summary>
        /// レコードデータ
        /// </summary>
        [JsonPropertyName("Data")]
        public List<BulkUpsertRecordData>? Data { get; set; }

        /// <summary>
        /// キー項目
        /// </summary>
        [JsonPropertyName("Keys")]
        public List<string>? Keys { get; set; }

        /// <summary>
        /// キーに一致するレコードがない場合に作成するかどうか
        /// </summary>
        [JsonPropertyName("KeyNotFoundCreate")]
        public bool? KeyNotFoundCreate { get; set; }
    }
}
