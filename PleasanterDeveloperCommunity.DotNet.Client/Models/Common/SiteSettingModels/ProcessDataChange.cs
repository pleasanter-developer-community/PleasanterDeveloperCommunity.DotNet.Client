using Newtonsoft.Json;

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
        [JsonProperty("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonProperty("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// 値
        /// </summary>
        [JsonProperty("Value")]
        public string? Value { get; set; }

        /// <summary>
        /// 基本列
        /// </summary>
        [JsonProperty("BaseColumn")]
        public string? BaseColumn { get; set; }

        /// <summary>
        /// 基本日時
        /// </summary>
        [JsonProperty("BaseDateTime")]
        public int? BaseDateTime { get; set; }

        /// <summary>
        /// 加算値
        /// </summary>
        [JsonProperty("AddValue")]
        public int? AddValue { get; set; }
    }
}
