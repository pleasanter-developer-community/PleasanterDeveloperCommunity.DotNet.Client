using System.Text.Json.Serialization;

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
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 対象列
        /// </summary>
        [JsonPropertyName("Target")]
        public string? Target { get; set; }

        /// <summary>
        /// 計算式
        /// </summary>
        [JsonPropertyName("Formula")]
        public object? Formula { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonPropertyName("Condition")]
        public int? Condition { get; set; }

        /// <summary>
        /// 条件外の場合の値
        /// </summary>
        [JsonPropertyName("OutOfCondition")]
        public string? OutOfCondition { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }

        /// <summary>
        /// 計算方法
        /// </summary>
        [JsonPropertyName("CalculationMethod")]
        public string? CalculationMethod { get; set; }
    }
}
