using System.Text.Json.Serialization;

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
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// ラベルテキスト
        /// </summary>
        [JsonPropertyName("LabelText")]
        public string? LabelText { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonPropertyName("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// フォーマット
        /// </summary>
        [JsonPropertyName("Format")]
        public string? Format { get; set; }

        /// <summary>
        /// サイトタイトルを出力
        /// </summary>
        [JsonPropertyName("OutputSiteTitle")]
        public bool? OutputSiteTitle { get; set; }

        /// <summary>
        /// 結合情報を出力（ID）
        /// </summary>
        [JsonPropertyName("JoinOutputId")]
        public bool? JoinOutputId { get; set; }

        /// <summary>
        /// 結合情報を出力（タイトル）
        /// </summary>
        [JsonPropertyName("JoinOutputTitle")]
        public bool? JoinOutputTitle { get; set; }

        /// <summary>
        /// JSONフォーマットでエクスポート
        /// </summary>
        [JsonPropertyName("ExportJsonFormat")]
        public bool? ExportJsonFormat { get; set; }
    }
}
