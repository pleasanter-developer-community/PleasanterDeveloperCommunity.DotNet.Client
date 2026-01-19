using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// 集計設定を表すクラスです。
    /// </summary>
    public class Aggregation
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// グループ化する列
        /// </summary>
        [JsonPropertyName("GroupBy")]
        public string? GroupBy { get; set; }

        /// <summary>
        /// 集計種類
        /// </summary>
        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        /// <summary>
        /// 対象列
        /// </summary>
        [JsonPropertyName("Target")]
        public string? Target { get; set; }

        /// <summary>
        /// データ
        /// </summary>
        [JsonPropertyName("Data")]
        public string? Data { get; set; }
    }
}
