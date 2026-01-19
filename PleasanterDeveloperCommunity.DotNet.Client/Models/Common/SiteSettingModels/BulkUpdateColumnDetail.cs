using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// 一括更新列の詳細設定を表すクラスです。
    /// </summary>
    public class BulkUpdateColumnDetail
    {
        /// <summary>
        /// デフォルト入力値
        /// </summary>
        [JsonProperty("DefaultInput")]
        public string? DefaultInput { get; set; }

        /// <summary>
        /// 必須検証
        /// </summary>
        [JsonProperty("ValidateRequired")]
        public bool? ValidateRequired { get; set; }

        /// <summary>
        /// エディタ読取専用
        /// </summary>
        [JsonProperty("EditorReadOnly")]
        public bool? EditorReadOnly { get; set; }
    }
}
