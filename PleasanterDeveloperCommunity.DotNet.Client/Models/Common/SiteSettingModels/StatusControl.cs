using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// ステータスコントロール設定を表すクラスです。
    /// </summary>
    public class StatusControl
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
        /// 説明
        /// </summary>
        [JsonProperty("Description")]
        public string? Description { get; set; }

        /// <summary>
        /// ステータス
        /// </summary>
        [JsonProperty("Status")]
        public int? Status { get; set; }

        /// <summary>
        /// 読取専用
        /// </summary>
        [JsonProperty("ReadOnly")]
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// 列ハッシュ
        /// </summary>
        [JsonProperty("ColumnHash")]
        public Dictionary<string, int>? ColumnHash { get; set; }

        /// <summary>
        /// ビュー
        /// </summary>
        [JsonProperty("View")]
        public SiteSettingsView? View { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
