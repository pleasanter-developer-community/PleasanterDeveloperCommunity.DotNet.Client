using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// ダッシュボードパーツ設定を表すクラスです。
    /// </summary>
    public class DashboardPart
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonPropertyName("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// サイトID
        /// </summary>
        [JsonPropertyName("SiteId")]
        public long? SiteId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("Content")]
        public string? Content { get; set; }

        /// <summary>
        /// HTML内容
        /// </summary>
        [JsonPropertyName("HtmlContent")]
        public string? HtmlContent { get; set; }

        /// <summary>
        /// 非同期読み込み
        /// </summary>
        [JsonPropertyName("AsynchronousLoading")]
        public bool? AsynchronousLoading { get; set; }

        /// <summary>
        /// 展開
        /// </summary>
        [JsonPropertyName("Expand")]
        public bool? Expand { get; set; }

        /// <summary>
        /// X位置
        /// </summary>
        [JsonPropertyName("X")]
        public int? X { get; set; }

        /// <summary>
        /// Y位置
        /// </summary>
        [JsonPropertyName("Y")]
        public int? Y { get; set; }

        /// <summary>
        /// 幅
        /// </summary>
        [JsonPropertyName("Width")]
        public int? Width { get; set; }

        /// <summary>
        /// 高さ
        /// </summary>
        [JsonPropertyName("Height")]
        public int? Height { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }
    }
}
