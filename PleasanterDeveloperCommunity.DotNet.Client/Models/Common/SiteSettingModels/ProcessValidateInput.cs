using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// プロセスの入力検証設定を表すクラスです。
    /// </summary>
    public class ProcessValidateInput
    {
        /// <summary>
        /// 列名
        /// </summary>
        [JsonProperty("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// 必須
        /// </summary>
        [JsonProperty("Required")]
        public bool? Required { get; set; }

        /// <summary>
        /// クライアント正規表現検証
        /// </summary>
        [JsonProperty("ClientRegexValidation")]
        public string? ClientRegexValidation { get; set; }

        /// <summary>
        /// サーバ正規表現検証
        /// </summary>
        [JsonProperty("ServerRegexValidation")]
        public string? ServerRegexValidation { get; set; }

        /// <summary>
        /// 正規表現検証メッセージ
        /// </summary>
        [JsonProperty("RegexValidationMessage")]
        public string? RegexValidationMessage { get; set; }
    }
}
