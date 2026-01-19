using Newtonsoft.Json;

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
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// ラベルテキスト
        /// </summary>
        [JsonProperty("LabelText")]
        public string? LabelText { get; set; }

        /// <summary>
        /// 展開を許可
        /// </summary>
        [JsonProperty("AllowExpand")]
        public bool? AllowExpand { get; set; }

        /// <summary>
        /// 展開
        /// </summary>
        [JsonProperty("Expand")]
        public bool? Expand { get; set; }
    }
}
