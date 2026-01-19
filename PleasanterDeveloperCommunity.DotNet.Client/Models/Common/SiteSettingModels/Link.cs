using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// リンク設定を表すクラスです。
    /// </summary>
    public class Link
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// サイトID
        /// </summary>
        [JsonPropertyName("SiteId")]
        public long? SiteId { get; set; }

        /// <summary>
        /// JSONフォーマット
        /// </summary>
        [JsonPropertyName("JsonFormat")]
        public bool? JsonFormat { get; set; }

        /// <summary>
        /// ルックアップ設定
        /// </summary>
        [JsonPropertyName("Lookups")]
        public List<Lookup>? Lookups { get; set; }

        /// <summary>
        /// ビュー設定
        /// </summary>
        [JsonPropertyName("View")]
        public SiteSettingsView? View { get; set; }
    }
}
