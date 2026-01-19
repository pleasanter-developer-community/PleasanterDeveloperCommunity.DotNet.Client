using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// エクスポート列設定を表すクラスです。
    /// </summary>
    public class ExportColumn
    {
        /// <summary>
        /// 列名
        /// </summary>
        [JsonProperty("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// ラベルテキスト
        /// </summary>
        [JsonProperty("LabelText")]
        public string? LabelText { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonProperty("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// フォーマット
        /// </summary>
        [JsonProperty("Format")]
        public string? Format { get; set; }

        /// <summary>
        /// サイトタイトルを出力
        /// </summary>
        [JsonProperty("OutputSiteTitle")]
        public bool? OutputSiteTitle { get; set; }

        /// <summary>
        /// 結合情報を出力（ID）
        /// </summary>
        [JsonProperty("JoinOutputId")]
        public bool? JoinOutputId { get; set; }

        /// <summary>
        /// 結合情報を出力（タイトル）
        /// </summary>
        [JsonProperty("JoinOutputTitle")]
        public bool? JoinOutputTitle { get; set; }

        /// <summary>
        /// JSONフォーマットでエクスポート
        /// </summary>
        [JsonProperty("ExportJsonFormat")]
        public bool? ExportJsonFormat { get; set; }
    }
}
