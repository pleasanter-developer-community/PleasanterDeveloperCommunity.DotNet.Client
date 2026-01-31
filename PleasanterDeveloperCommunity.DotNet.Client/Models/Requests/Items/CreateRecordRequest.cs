using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items
{
    /// <summary>
    /// レコード作成リクエスト
    /// </summary>
    public class CreateRecordRequest : ApiRequestBase
    {
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
        /// 状態
        /// </summary>
        [JsonPropertyName("Status")]
        public int? Status { get; set; }

        /// <summary>
        /// 管理者
        /// </summary>
        [JsonPropertyName("Manager")]
        public int? Manager { get; set; }

        /// <summary>
        /// 担当者
        /// </summary>
        [JsonPropertyName("Owner")]
        public int? Owner { get; set; }

        /// <summary>
        /// 完了日時
        /// </summary>
        [JsonPropertyName("CompletionTime")]
        public string? CompletionTime { get; set; }

        /// <summary>
        /// 分類項目
        /// </summary>
        [JsonPropertyName("ClassHash")]
        public Dictionary<string, string>? ClassHash { get; set; }

        /// <summary>
        /// 数値項目
        /// </summary>
        [JsonPropertyName("NumHash")]
        public Dictionary<string, decimal>? NumHash { get; set; }

        /// <summary>
        /// 日付項目
        /// </summary>
        [JsonPropertyName("DateHash")]
        public Dictionary<string, DateTime>? DateHash { get; set; }

        /// <summary>
        /// 説明項目
        /// </summary>
        [JsonPropertyName("DescriptionHash")]
        public Dictionary<string, string>? DescriptionHash { get; set; }

        /// <summary>
        /// チェック項目
        /// </summary>
        [JsonPropertyName("CheckHash")]
        public Dictionary<string, bool>? CheckHash { get; set; }

        /// <summary>
        /// 添付ファイル
        /// </summary>
        [JsonPropertyName("AttachmentsHash")]
        public Dictionary<string, List<AttachmentData>>? AttachmentsHash { get; set; }

        /// <summary>
        /// プロセスID
        /// </summary>
        [JsonPropertyName("ProcessId")]
        public int? ProcessId { get; set; }

        /// <summary>
        /// プロセスID一覧
        /// </summary>
        [JsonPropertyName("ProcessIds")]
        public List<int>? ProcessIds { get; set; }

        /// <summary>
        /// 画像設定
        /// </summary>
        [JsonPropertyName("ImageHash")]
        public Dictionary<string, ImageSettings>? ImageHash { get; set; }
    }
}
