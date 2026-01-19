using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// プロセスのデータ変更設定を表すクラスです。
    /// </summary>
    public class ProcessDataChange
    {
        /// <summary>
        /// 列名
        /// </summary>
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonPropertyName("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// 値
        /// </summary>
        [JsonPropertyName("Value")]
        public string? Value { get; set; }

        /// <summary>
        /// 基本列
        /// </summary>
        [JsonPropertyName("BaseColumn")]
        public string? BaseColumn { get; set; }

        /// <summary>
        /// 基本日時
        /// </summary>
        [JsonPropertyName("BaseDateTime")]
        public int? BaseDateTime { get; set; }

        /// <summary>
        /// 加算値
        /// </summary>
        [JsonPropertyName("AddValue")]
        public int? AddValue { get; set; }
    }
}
