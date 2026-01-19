using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// HTML設定を表すクラスです。
    /// </summary>
    public class Html
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
        /// 本文
        /// </summary>
        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        /// <summary>
        /// 位置種類
        /// </summary>
        [JsonPropertyName("PositionType")]
        public int? PositionType { get; set; }

        /// <summary>
        /// 全て
        /// </summary>
        [JsonPropertyName("All")]
        public bool? All { get; set; }

        /// <summary>
        /// 新規
        /// </summary>
        [JsonPropertyName("New")]
        public bool? New { get; set; }

        /// <summary>
        /// 編集
        /// </summary>
        [JsonPropertyName("Edit")]
        public bool? Edit { get; set; }

        /// <summary>
        /// 一覧
        /// </summary>
        [JsonPropertyName("Index")]
        public bool? Index { get; set; }

        /// <summary>
        /// カレンダー
        /// </summary>
        [JsonPropertyName("Calendar")]
        public bool? Calendar { get; set; }

        /// <summary>
        /// クロス集計
        /// </summary>
        [JsonPropertyName("Crosstab")]
        public bool? Crosstab { get; set; }

        /// <summary>
        /// ガント
        /// </summary>
        [JsonPropertyName("Gantt")]
        public bool? Gantt { get; set; }

        /// <summary>
        /// バーンダウン
        /// </summary>
        [JsonPropertyName("BurnDown")]
        public bool? BurnDown { get; set; }

        /// <summary>
        /// 時系列
        /// </summary>
        [JsonPropertyName("TimeSeries")]
        public bool? TimeSeries { get; set; }

        /// <summary>
        /// 分析
        /// </summary>
        [JsonPropertyName("Analy")]
        public bool? Analy { get; set; }

        /// <summary>
        /// カンバン
        /// </summary>
        [JsonPropertyName("Kamban")]
        public bool? Kamban { get; set; }

        /// <summary>
        /// 画像ライブラリ
        /// </summary>
        [JsonPropertyName("ImageLib")]
        public bool? ImageLib { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }
    }
}
