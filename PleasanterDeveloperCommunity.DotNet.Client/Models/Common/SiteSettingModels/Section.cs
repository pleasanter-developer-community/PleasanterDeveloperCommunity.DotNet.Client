using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// セクション設定を表すクラスです。
    /// </summary>
    public class Section
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// ラベルテキスト
        /// </summary>
        [JsonPropertyName("LabelText")]
        public string? LabelText { get; set; }

        /// <summary>
        /// 展開を許可
        /// </summary>
        [JsonPropertyName("AllowExpand")]
        public bool? AllowExpand { get; set; }

        /// <summary>
        /// 展開
        /// </summary>
        [JsonPropertyName("Expand")]
        public bool? Expand { get; set; }
    }
}
