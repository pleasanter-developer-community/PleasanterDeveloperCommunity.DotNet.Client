using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites
{
    /// <summary>
    /// サイトパッケージコピーリクエスト
    /// </summary>
    public class CopySitePackageRequest : ApiRequestBase
    {
        /// <summary>
        /// 選択したサイト一覧
        /// </summary>
        [JsonPropertyName("SelectedSites")]
        public List<SelectedSite>? SelectedSites { get; set; }

        /// <summary>
        /// コピー先サイトID
        /// </summary>
        [JsonPropertyName("TargetSiteId")]
        public long? TargetSiteId { get; set; }

        /// <summary>
        /// サイトタイトル
        /// </summary>
        [JsonPropertyName("SiteTitle")]
        public string? SiteTitle { get; set; }

        /// <summary>
        /// サイト権限を含める
        /// </summary>
        [JsonPropertyName("IncludeSitePermission")]
        public bool? IncludeSitePermission { get; set; }

        /// <summary>
        /// レコード権限を含める
        /// </summary>
        [JsonPropertyName("IncludeRecordPermission")]
        public bool? IncludeRecordPermission { get; set; }

        /// <summary>
        /// 列権限を含める
        /// </summary>
        [JsonPropertyName("IncludeColumnPermission")]
        public bool? IncludeColumnPermission { get; set; }

        /// <summary>
        /// 通知を含める
        /// </summary>
        [JsonPropertyName("IncludeNotifications")]
        public bool? IncludeNotifications { get; set; }

        /// <summary>
        /// リマインダーを含める
        /// </summary>
        [JsonPropertyName("IncludeReminders")]
        public bool? IncludeReminders { get; set; }
    }
}
