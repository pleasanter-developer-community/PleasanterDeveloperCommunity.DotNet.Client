using System.Text.Json.Serialization;
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
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        /// <summary>
        /// ステータス
        /// </summary>
        [JsonPropertyName("Status")]
        public int? Status { get; set; }

        /// <summary>
        /// 読取専用
        /// </summary>
        [JsonPropertyName("ReadOnly")]
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// 列ハッシュ
        /// </summary>
        [JsonPropertyName("ColumnHash")]
        public Dictionary<string, int>? ColumnHash { get; set; }

        /// <summary>
        /// ビュー
        /// </summary>
        [JsonPropertyName("View")]
        public SiteSettingsView? View { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }
    }
}
