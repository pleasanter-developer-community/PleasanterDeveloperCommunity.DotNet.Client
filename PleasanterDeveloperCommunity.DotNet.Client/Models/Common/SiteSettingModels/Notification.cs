using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// 通知設定を表すクラスです。
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonPropertyName("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// プレフィックス
        /// </summary>
        [JsonPropertyName("Prefix")]
        public string? Prefix { get; set; }

        /// <summary>
        /// 宛先
        /// </summary>
        [JsonPropertyName("Address")]
        public string? Address { get; set; }

        /// <summary>
        /// トークン
        /// </summary>
        [JsonPropertyName("Token")]
        public string? Token { get; set; }

        /// <summary>
        /// 監視対象の列
        /// </summary>
        [JsonPropertyName("MonitorChangesColumns")]
        public List<string>? MonitorChangesColumns { get; set; }

        /// <summary>
        /// 作成後に通知
        /// </summary>
        [JsonPropertyName("AfterCreate")]
        public bool? AfterCreate { get; set; }

        /// <summary>
        /// 更新後に通知
        /// </summary>
        [JsonPropertyName("AfterUpdate")]
        public bool? AfterUpdate { get; set; }

        /// <summary>
        /// 削除後に通知
        /// </summary>
        [JsonPropertyName("AfterDelete")]
        public bool? AfterDelete { get; set; }

        /// <summary>
        /// コピー後に通知
        /// </summary>
        [JsonPropertyName("AfterCopy")]
        public bool? AfterCopy { get; set; }

        /// <summary>
        /// 一括更新後に通知
        /// </summary>
        [JsonPropertyName("AfterBulkUpdate")]
        public bool? AfterBulkUpdate { get; set; }

        /// <summary>
        /// 一括削除後に通知
        /// </summary>
        [JsonPropertyName("AfterBulkDelete")]
        public bool? AfterBulkDelete { get; set; }

        /// <summary>
        /// インポート後に通知
        /// </summary>
        [JsonPropertyName("AfterImport")]
        public bool? AfterImport { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonPropertyName("Condition")]
        public int? Condition { get; set; }

        /// <summary>
        /// 式
        /// </summary>
        [JsonPropertyName("Expression")]
        public string? Expression { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }
    }
}
