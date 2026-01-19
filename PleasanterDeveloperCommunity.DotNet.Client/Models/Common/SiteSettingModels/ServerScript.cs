using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// サーバスクリプト設定を表すクラスです。
    /// </summary>
    public class ServerScript
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
        /// 名前
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// 本文
        /// </summary>
        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        /// <summary>
        /// サイト設定読み込み時
        /// </summary>
        [JsonPropertyName("WhenloadingSiteSettings")]
        public bool? WhenloadingSiteSettings { get; set; }

        /// <summary>
        /// ビュー処理時
        /// </summary>
        [JsonPropertyName("WhenViewProcessing")]
        public bool? WhenViewProcessing { get; set; }

        /// <summary>
        /// レコード読み込み時
        /// </summary>
        [JsonPropertyName("WhenloadingRecord")]
        public bool? WhenloadingRecord { get; set; }

        /// <summary>
        /// 計算式前
        /// </summary>
        [JsonPropertyName("BeforeFormula")]
        public bool? BeforeFormula { get; set; }

        /// <summary>
        /// 計算式後
        /// </summary>
        [JsonPropertyName("AfterFormula")]
        public bool? AfterFormula { get; set; }

        /// <summary>
        /// 作成前
        /// </summary>
        [JsonPropertyName("BeforeCreate")]
        public bool? BeforeCreate { get; set; }

        /// <summary>
        /// 作成後
        /// </summary>
        [JsonPropertyName("AfterCreate")]
        public bool? AfterCreate { get; set; }

        /// <summary>
        /// 更新前
        /// </summary>
        [JsonPropertyName("BeforeUpdate")]
        public bool? BeforeUpdate { get; set; }

        /// <summary>
        /// 更新後
        /// </summary>
        [JsonPropertyName("AfterUpdate")]
        public bool? AfterUpdate { get; set; }

        /// <summary>
        /// 削除前
        /// </summary>
        [JsonPropertyName("BeforeDelete")]
        public bool? BeforeDelete { get; set; }

        /// <summary>
        /// 一括削除前
        /// </summary>
        [JsonPropertyName("BeforeBulkDelete")]
        public bool? BeforeBulkDelete { get; set; }

        /// <summary>
        /// 削除後
        /// </summary>
        [JsonPropertyName("AfterDelete")]
        public bool? AfterDelete { get; set; }

        /// <summary>
        /// 一括削除後
        /// </summary>
        [JsonPropertyName("AfterBulkDelete")]
        public bool? AfterBulkDelete { get; set; }

        /// <summary>
        /// ページ表示前
        /// </summary>
        [JsonPropertyName("BeforeOpeningPage")]
        public bool? BeforeOpeningPage { get; set; }

        /// <summary>
        /// 行表示前
        /// </summary>
        [JsonPropertyName("BeforeOpeningRow")]
        public bool? BeforeOpeningRow { get; set; }

        /// <summary>
        /// 共有
        /// </summary>
        [JsonPropertyName("Shared")]
        public bool? Shared { get; set; }

        /// <summary>
        /// 関数化
        /// </summary>
        [JsonPropertyName("Functionalize")]
        public bool? Functionalize { get; set; }

        /// <summary>
        /// try-catch
        /// </summary>
        [JsonPropertyName("TryCatch")]
        public bool? TryCatch { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }
    }
}
