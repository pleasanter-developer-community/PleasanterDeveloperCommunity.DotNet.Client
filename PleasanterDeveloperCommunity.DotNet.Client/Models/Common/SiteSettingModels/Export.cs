using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// エクスポート設定を表すクラスです。
    /// </summary>
    public class Export
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// ヘッダーを含める
        /// </summary>
        [JsonPropertyName("Header")]
        public bool? Header { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [JsonPropertyName("Columns")]
        public List<ExportColumn>? Columns { get; set; }

        /// <summary>
        /// エクスポート形式
        /// </summary>
        [JsonPropertyName("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// 区切り文字
        /// </summary>
        [JsonPropertyName("DelimitateStandard")]
        public bool? DelimitateStandard { get; set; }

        /// <summary>
        /// 履歴を結合
        /// </summary>
        [JsonPropertyName("JoinAll")]
        public bool? JoinAll { get; set; }

        /// <summary>
        /// リンクを使用
        /// </summary>
        [JsonPropertyName("UseLinks")]
        public bool? UseLinks { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }
    }
}
