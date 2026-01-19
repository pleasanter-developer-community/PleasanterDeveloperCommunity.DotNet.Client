using Newtonsoft.Json;
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
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        [JsonProperty("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// サイトID
        /// </summary>
        [JsonProperty("SiteId")]
        public long? SiteId { get; set; }

        /// <summary>
        /// JSONフォーマット
        /// </summary>
        [JsonProperty("JsonFormat")]
        public bool? JsonFormat { get; set; }

        /// <summary>
        /// ルックアップ設定
        /// </summary>
        [JsonProperty("Lookups")]
        public List<Lookup>? Lookups { get; set; }

        /// <summary>
        /// ビュー設定
        /// </summary>
        [JsonProperty("View")]
        public SiteSettingsView? View { get; set; }
    }
}
