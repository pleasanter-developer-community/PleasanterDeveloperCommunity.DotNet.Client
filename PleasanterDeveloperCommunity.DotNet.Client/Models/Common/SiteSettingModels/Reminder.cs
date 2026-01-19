using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// リマインダ設定を表すクラスです。
    /// </summary>
    public class Reminder
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 件名
        /// </summary>
        [JsonProperty("Subject")]
        public string? Subject { get; set; }

        /// <summary>
        /// 本文
        /// </summary>
        [JsonProperty("Body")]
        public string? Body { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        [JsonProperty("Line")]
        public string? Line { get; set; }

        /// <summary>
        /// 宛先
        /// </summary>
        [JsonProperty("To")]
        public string? To { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [JsonProperty("Column")]
        public string? Column { get; set; }

        /// <summary>
        /// 開始日時
        /// </summary>
        [JsonProperty("StartDateTime")]
        public string? StartDateTime { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonProperty("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// 範囲
        /// </summary>
        [JsonProperty("Range")]
        public int? Range { get; set; }

        /// <summary>
        /// 繰り返しを送信
        /// </summary>
        [JsonProperty("SendCompletedInPast")]
        public bool? SendCompletedInPast { get; set; }

        /// <summary>
        /// 未変更を含まない
        /// </summary>
        [JsonProperty("NotSendIfNotApplicable")]
        public bool? NotSendIfNotApplicable { get; set; }

        /// <summary>
        /// 通知のタイミング
        /// </summary>
        [JsonProperty("NotSendHyperLink")]
        public bool? NotSendHyperLink { get; set; }

        /// <summary>
        /// メールアドレスを除外
        /// </summary>
        [JsonProperty("ExcludeOverdue")]
        public bool? ExcludeOverdue { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonProperty("Condition")]
        public int? Condition { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
