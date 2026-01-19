using Newtonsoft.Json;
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
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonProperty("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// プレフィックス
        /// </summary>
        [JsonProperty("Prefix")]
        public string? Prefix { get; set; }

        /// <summary>
        /// 宛先
        /// </summary>
        [JsonProperty("Address")]
        public string? Address { get; set; }

        /// <summary>
        /// トークン
        /// </summary>
        [JsonProperty("Token")]
        public string? Token { get; set; }

        /// <summary>
        /// 監視対象の列
        /// </summary>
        [JsonProperty("MonitorChangesColumns")]
        public List<string>? MonitorChangesColumns { get; set; }

        /// <summary>
        /// 作成後に通知
        /// </summary>
        [JsonProperty("AfterCreate")]
        public bool? AfterCreate { get; set; }

        /// <summary>
        /// 更新後に通知
        /// </summary>
        [JsonProperty("AfterUpdate")]
        public bool? AfterUpdate { get; set; }

        /// <summary>
        /// 削除後に通知
        /// </summary>
        [JsonProperty("AfterDelete")]
        public bool? AfterDelete { get; set; }

        /// <summary>
        /// コピー後に通知
        /// </summary>
        [JsonProperty("AfterCopy")]
        public bool? AfterCopy { get; set; }

        /// <summary>
        /// 一括更新後に通知
        /// </summary>
        [JsonProperty("AfterBulkUpdate")]
        public bool? AfterBulkUpdate { get; set; }

        /// <summary>
        /// 一括削除後に通知
        /// </summary>
        [JsonProperty("AfterBulkDelete")]
        public bool? AfterBulkDelete { get; set; }

        /// <summary>
        /// インポート後に通知
        /// </summary>
        [JsonProperty("AfterImport")]
        public bool? AfterImport { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonProperty("Condition")]
        public int? Condition { get; set; }

        /// <summary>
        /// 式
        /// </summary>
        [JsonProperty("Expression")]
        public string? Expression { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
