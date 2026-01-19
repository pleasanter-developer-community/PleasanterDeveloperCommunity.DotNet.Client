using Newtonsoft.Json;
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
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonProperty("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// ヘッダーを含める
        /// </summary>
        [JsonProperty("Header")]
        public bool? Header { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [JsonProperty("Columns")]
        public List<ExportColumn>? Columns { get; set; }

        /// <summary>
        /// エクスポート形式
        /// </summary>
        [JsonProperty("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// 区切り文字
        /// </summary>
        [JsonProperty("DelimitateStandard")]
        public bool? DelimitateStandard { get; set; }

        /// <summary>
        /// 履歴を結合
        /// </summary>
        [JsonProperty("JoinAll")]
        public bool? JoinAll { get; set; }

        /// <summary>
        /// リンクを使用
        /// </summary>
        [JsonProperty("UseLinks")]
        public bool? UseLinks { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
