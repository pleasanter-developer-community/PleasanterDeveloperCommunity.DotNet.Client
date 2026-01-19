using System.Text.Json.Serialization;
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
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 件名
        /// </summary>
        [JsonPropertyName("Subject")]
        public string? Subject { get; set; }

        /// <summary>
        /// 本文
        /// </summary>
        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        [JsonPropertyName("Line")]
        public string? Line { get; set; }

        /// <summary>
        /// 宛先
        /// </summary>
        [JsonPropertyName("To")]
        public string? To { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [JsonPropertyName("Column")]
        public string? Column { get; set; }

        /// <summary>
        /// 開始日時
        /// </summary>
        [JsonPropertyName("StartDateTime")]
        public string? StartDateTime { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [JsonPropertyName("Type")]
        public int? Type { get; set; }

        /// <summary>
        /// 範囲
        /// </summary>
        [JsonPropertyName("Range")]
        public int? Range { get; set; }

        /// <summary>
        /// 繰り返しを送信
        /// </summary>
        [JsonPropertyName("SendCompletedInPast")]
        public bool? SendCompletedInPast { get; set; }

        /// <summary>
        /// 未変更を含まない
        /// </summary>
        [JsonPropertyName("NotSendIfNotApplicable")]
        public bool? NotSendIfNotApplicable { get; set; }

        /// <summary>
        /// 通知のタイミング
        /// </summary>
        [JsonPropertyName("NotSendHyperLink")]
        public bool? NotSendHyperLink { get; set; }

        /// <summary>
        /// メールアドレスを除外
        /// </summary>
        [JsonPropertyName("ExcludeOverdue")]
        public bool? ExcludeOverdue { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonPropertyName("Condition")]
        public int? Condition { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }
    }
}
