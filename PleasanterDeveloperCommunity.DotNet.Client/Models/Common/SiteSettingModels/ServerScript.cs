using Newtonsoft.Json;

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
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [JsonProperty("Title")]
        public string? Title { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonProperty("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// 本文
        /// </summary>
        [JsonProperty("Body")]
        public string? Body { get; set; }

        /// <summary>
        /// サイト設定読み込み時
        /// </summary>
        [JsonProperty("WhenloadingSiteSettings")]
        public bool? WhenloadingSiteSettings { get; set; }

        /// <summary>
        /// ビュー処理時
        /// </summary>
        [JsonProperty("WhenViewProcessing")]
        public bool? WhenViewProcessing { get; set; }

        /// <summary>
        /// レコード読み込み時
        /// </summary>
        [JsonProperty("WhenloadingRecord")]
        public bool? WhenloadingRecord { get; set; }

        /// <summary>
        /// 計算式前
        /// </summary>
        [JsonProperty("BeforeFormula")]
        public bool? BeforeFormula { get; set; }

        /// <summary>
        /// 計算式後
        /// </summary>
        [JsonProperty("AfterFormula")]
        public bool? AfterFormula { get; set; }

        /// <summary>
        /// 作成前
        /// </summary>
        [JsonProperty("BeforeCreate")]
        public bool? BeforeCreate { get; set; }

        /// <summary>
        /// 作成後
        /// </summary>
        [JsonProperty("AfterCreate")]
        public bool? AfterCreate { get; set; }

        /// <summary>
        /// 更新前
        /// </summary>
        [JsonProperty("BeforeUpdate")]
        public bool? BeforeUpdate { get; set; }

        /// <summary>
        /// 更新後
        /// </summary>
        [JsonProperty("AfterUpdate")]
        public bool? AfterUpdate { get; set; }

        /// <summary>
        /// 削除前
        /// </summary>
        [JsonProperty("BeforeDelete")]
        public bool? BeforeDelete { get; set; }

        /// <summary>
        /// 一括削除前
        /// </summary>
        [JsonProperty("BeforeBulkDelete")]
        public bool? BeforeBulkDelete { get; set; }

        /// <summary>
        /// 削除後
        /// </summary>
        [JsonProperty("AfterDelete")]
        public bool? AfterDelete { get; set; }

        /// <summary>
        /// 一括削除後
        /// </summary>
        [JsonProperty("AfterBulkDelete")]
        public bool? AfterBulkDelete { get; set; }

        /// <summary>
        /// ページ表示前
        /// </summary>
        [JsonProperty("BeforeOpeningPage")]
        public bool? BeforeOpeningPage { get; set; }

        /// <summary>
        /// 行表示前
        /// </summary>
        [JsonProperty("BeforeOpeningRow")]
        public bool? BeforeOpeningRow { get; set; }

        /// <summary>
        /// 共有
        /// </summary>
        [JsonProperty("Shared")]
        public bool? Shared { get; set; }

        /// <summary>
        /// 関数化
        /// </summary>
        [JsonProperty("Functionalize")]
        public bool? Functionalize { get; set; }

        /// <summary>
        /// try-catch
        /// </summary>
        [JsonProperty("TryCatch")]
        public bool? TryCatch { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
