using System.Text.Json.Serialization;

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
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// 必須
        /// </summary>
        [JsonPropertyName("Required")]
        public bool? Required { get; set; }

        /// <summary>
        /// クライアント正規表現検証
        /// </summary>
        [JsonPropertyName("ClientRegexValidation")]
        public string? ClientRegexValidation { get; set; }

        /// <summary>
        /// サーバ正規表現検証
        /// </summary>
        [JsonPropertyName("ServerRegexValidation")]
        public string? ServerRegexValidation { get; set; }

        /// <summary>
        /// 正規表現検証メッセージ
        /// </summary>
        [JsonPropertyName("RegexValidationMessage")]
        public string? RegexValidationMessage { get; set; }
    }
}
