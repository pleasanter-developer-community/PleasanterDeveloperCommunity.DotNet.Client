using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// タブ設定を表すクラスです。
    /// </summary>
    public class Tab
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
    }
}
