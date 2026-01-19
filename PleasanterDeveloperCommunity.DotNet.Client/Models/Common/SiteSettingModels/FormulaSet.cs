using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// 計算式設定を表すクラスです。
    /// </summary>
    public class FormulaSet
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 対象列
        /// </summary>
        [JsonProperty("Target")]
        public string? Target { get; set; }

        /// <summary>
        /// 計算式
        /// </summary>
        [JsonProperty("Formula")]
        public object? Formula { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonProperty("Condition")]
        public int? Condition { get; set; }

        /// <summary>
        /// 条件外の場合の値
        /// </summary>
        [JsonProperty("OutOfCondition")]
        public string? OutOfCondition { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }

        /// <summary>
        /// 計算方法
        /// </summary>
        [JsonProperty("CalculationMethod")]
        public string? CalculationMethod { get; set; }
    }
}
