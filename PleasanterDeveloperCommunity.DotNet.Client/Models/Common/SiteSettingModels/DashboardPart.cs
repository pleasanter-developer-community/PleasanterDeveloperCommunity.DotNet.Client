using Newtonsoft.Json;

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
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [JsonProperty("Title")]
        public string? Title { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonProperty("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// サイトID
        /// </summary>
        [JsonProperty("SiteId")]
        public long? SiteId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("Content")]
        public string? Content { get; set; }

        /// <summary>
        /// HTML内容
        /// </summary>
        [JsonProperty("HtmlContent")]
        public string? HtmlContent { get; set; }

        /// <summary>
        /// 非同期読み込み
        /// </summary>
        [JsonProperty("AsynchronousLoading")]
        public bool? AsynchronousLoading { get; set; }

        /// <summary>
        /// 展開
        /// </summary>
        [JsonProperty("Expand")]
        public bool? Expand { get; set; }

        /// <summary>
        /// X位置
        /// </summary>
        [JsonProperty("X")]
        public int? X { get; set; }

        /// <summary>
        /// Y位置
        /// </summary>
        [JsonProperty("Y")]
        public int? Y { get; set; }

        /// <summary>
        /// 幅
        /// </summary>
        [JsonProperty("Width")]
        public int? Width { get; set; }

        /// <summary>
        /// 高さ
        /// </summary>
        [JsonProperty("Height")]
        public int? Height { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
