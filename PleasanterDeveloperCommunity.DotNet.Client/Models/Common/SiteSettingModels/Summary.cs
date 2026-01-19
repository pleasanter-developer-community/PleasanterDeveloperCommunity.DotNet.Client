using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// サマリ設定を表すクラスです。
    /// </summary>
    public class Summary
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// サイトID
        /// </summary>
        [JsonProperty("SiteId")]
        public long? SiteId { get; set; }

        /// <summary>
        /// 宛先のレファレンスの種類
        /// </summary>
        [JsonProperty("DestinationReferenceType")]
        public string? DestinationReferenceType { get; set; }

        /// <summary>
        /// 宛先の列
        /// </summary>
        [JsonProperty("DestinationColumn")]
        public string? DestinationColumn { get; set; }

        /// <summary>
        /// 宛先の条件
        /// </summary>
        [JsonProperty("DestinationCondition")]
        public int? DestinationCondition { get; set; }

        /// <summary>
        /// リンクを設定する列
        /// </summary>
        [JsonProperty("SetZeroWhenOutOfCondition")]
        public bool? SetZeroWhenOutOfCondition { get; set; }

        /// <summary>
        /// リンクの列
        /// </summary>
        [JsonProperty("LinkColumn")]
        public string? LinkColumn { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonProperty("Type")]
        public string? Type { get; set; }

        /// <summary>
        /// 元の列
        /// </summary>
        [JsonProperty("SourceColumn")]
        public string? SourceColumn { get; set; }

        /// <summary>
        /// 元の条件
        /// </summary>
        [JsonProperty("SourceCondition")]
        public int? SourceCondition { get; set; }
    }
}
