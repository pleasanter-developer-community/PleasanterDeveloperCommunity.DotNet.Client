using System.Text.Json.Serialization;

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
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// ラベルテキスト
        /// </summary>
        [JsonPropertyName("LabelText")]
        public string? LabelText { get; set; }
    }
}
