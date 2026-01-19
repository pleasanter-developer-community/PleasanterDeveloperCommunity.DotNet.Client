using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// スクリプト設定を表すクラスです。
    /// </summary>
    public class Script
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
        /// 本文
        /// </summary>
        [JsonProperty("Body")]
        public string? Body { get; set; }

        /// <summary>
        /// 全て
        /// </summary>
        [JsonProperty("All")]
        public bool? All { get; set; }

        /// <summary>
        /// 新規
        /// </summary>
        [JsonProperty("New")]
        public bool? New { get; set; }

        /// <summary>
        /// 編集
        /// </summary>
        [JsonProperty("Edit")]
        public bool? Edit { get; set; }

        /// <summary>
        /// 一覧
        /// </summary>
        [JsonProperty("Index")]
        public bool? Index { get; set; }

        /// <summary>
        /// カレンダー
        /// </summary>
        [JsonProperty("Calendar")]
        public bool? Calendar { get; set; }

        /// <summary>
        /// クロス集計
        /// </summary>
        [JsonProperty("Crosstab")]
        public bool? Crosstab { get; set; }

        /// <summary>
        /// ガント
        /// </summary>
        [JsonProperty("Gantt")]
        public bool? Gantt { get; set; }

        /// <summary>
        /// バーンダウン
        /// </summary>
        [JsonProperty("BurnDown")]
        public bool? BurnDown { get; set; }

        /// <summary>
        /// 時系列
        /// </summary>
        [JsonProperty("TimeSeries")]
        public bool? TimeSeries { get; set; }

        /// <summary>
        /// 分析
        /// </summary>
        [JsonProperty("Analy")]
        public bool? Analy { get; set; }

        /// <summary>
        /// カンバン
        /// </summary>
        [JsonProperty("Kamban")]
        public bool? Kamban { get; set; }

        /// <summary>
        /// 画像ライブラリ
        /// </summary>
        [JsonProperty("ImageLib")]
        public bool? ImageLib { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
