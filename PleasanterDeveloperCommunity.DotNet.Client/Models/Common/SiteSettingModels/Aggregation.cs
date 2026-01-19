using Newtonsoft.Json;

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
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// グループ化する列
        /// </summary>
        [JsonProperty("GroupBy")]
        public string? GroupBy { get; set; }

        /// <summary>
        /// 集計種類
        /// </summary>
        [JsonProperty("Type")]
        public string? Type { get; set; }

        /// <summary>
        /// 対象列
        /// </summary>
        [JsonProperty("Target")]
        public string? Target { get; set; }

        /// <summary>
        /// データ
        /// </summary>
        [JsonProperty("Data")]
        public string? Data { get; set; }
    }
}
