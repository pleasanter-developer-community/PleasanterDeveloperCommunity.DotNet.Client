using System.Text.Json.Serialization;

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
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// サイトID
        /// </summary>
        [JsonPropertyName("SiteId")]
        public long? SiteId { get; set; }

        /// <summary>
        /// 宛先のレファレンスの種類
        /// </summary>
        [JsonPropertyName("DestinationReferenceType")]
        public string? DestinationReferenceType { get; set; }

        /// <summary>
        /// 宛先の列
        /// </summary>
        [JsonPropertyName("DestinationColumn")]
        public string? DestinationColumn { get; set; }

        /// <summary>
        /// 宛先の条件
        /// </summary>
        [JsonPropertyName("DestinationCondition")]
        public int? DestinationCondition { get; set; }

        /// <summary>
        /// リンクを設定する列
        /// </summary>
        [JsonPropertyName("SetZeroWhenOutOfCondition")]
        public bool? SetZeroWhenOutOfCondition { get; set; }

        /// <summary>
        /// リンクの列
        /// </summary>
        [JsonPropertyName("LinkColumn")]
        public string? LinkColumn { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        /// <summary>
        /// 元の列
        /// </summary>
        [JsonPropertyName("SourceColumn")]
        public string? SourceColumn { get; set; }

        /// <summary>
        /// 元の条件
        /// </summary>
        [JsonPropertyName("SourceCondition")]
        public int? SourceCondition { get; set; }
    }
}
