using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common
{
    /// <summary>
    /// コメントデータ
    /// </summary>
    public class Comment
    {
        [JsonPropertyName("CommentId")]
        public long CommentId { get; set; }

        [JsonPropertyName("CreatedTime")]
        public string? CreatedTime { get; set; }

        [JsonPropertyName("UpdatedTime")]
        public string? UpdatedTime { get; set; }

        [JsonPropertyName("Creator")]
        public int Creator { get; set; }

        [JsonPropertyName("Body")]
        public string? Body { get; set; }
    }

    /// <summary>
    /// 添付ファイルデータ
    /// </summary>
    public class AttachmentData
    {
        [JsonPropertyName("Guid")]
        public string? Guid { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Size")]
        public long Size { get; set; }

        [JsonPropertyName("HashCode")]
        public string? HashCode { get; set; }

        [JsonPropertyName("Deleted")]
        public bool? Deleted { get; set; }

        [JsonPropertyName("ContentType")]
        public string? ContentType { get; set; }

        [JsonPropertyName("Base64")]
        public string? Base64 { get; set; }
    }

    /// <summary>
    /// サイト設定
    /// </summary>
    public class SiteSettings
    {
        [JsonPropertyName("Version")]
        public decimal? Version { get; set; }

        [JsonPropertyName("GridColumns")]
        public List<string>? GridColumns { get; set; }

        [JsonPropertyName("EditorColumnHash")]
        public Dictionary<string, List<string>>? EditorColumnHash { get; set; }

        [JsonPropertyName("Columns")]
        public List<ColumnDefinition>? Columns { get; set; }

        [JsonPropertyName("Links")]
        public List<object>? Links { get; set; }

        [JsonPropertyName("Summaries")]
        public List<object>? Summaries { get; set; }

        [JsonPropertyName("Formulas")]
        public List<object>? Formulas { get; set; }

        [JsonPropertyName("Processes")]
        public List<object>? Processes { get; set; }

        [JsonPropertyName("Views")]
        public List<object>? Views { get; set; }

        [JsonPropertyName("Notifications")]
        public List<object>? Notifications { get; set; }

        [JsonPropertyName("Reminders")]
        public List<object>? Reminders { get; set; }

        [JsonPropertyName("Scripts")]
        public List<object>? Scripts { get; set; }

        [JsonPropertyName("Styles")]
        public List<object>? Styles { get; set; }

        [JsonPropertyName("ServerScripts")]
        public List<object>? ServerScripts { get; set; }
    }

    /// <summary>
    /// 列定義
    /// </summary>
    public class ColumnDefinition
    {
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }

        [JsonPropertyName("LabelText")]
        public string? LabelText { get; set; }

        [JsonPropertyName("EditorFormat")]
        public string? EditorFormat { get; set; }

        [JsonPropertyName("ChoicesText")]
        public string? ChoicesText { get; set; }

        [JsonPropertyName("DefaultInput")]
        public string? DefaultInput { get; set; }

        [JsonPropertyName("ValidateRequired")]
        public bool? ValidateRequired { get; set; }
    }

    /// <summary>
    /// 画像挿入設定
    /// </summary>
    public class ImageSettings
    {
        [JsonPropertyName("Base64")]
        public string? Base64 { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }
    }

    /// <summary>
    /// レコードデータ
    /// </summary>
    public class RecordData
    {
        [JsonPropertyName("SiteId")]
        public long SiteId { get; set; }

        [JsonPropertyName("UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }

        [JsonPropertyName("IssueId")]
        public long? IssueId { get; set; }

        [JsonPropertyName("ResultId")]
        public long? ResultId { get; set; }

        [JsonPropertyName("WikiId")]
        public long? WikiId { get; set; }

        [JsonPropertyName("Ver")]
        public int? Ver { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        [JsonPropertyName("StartTime")]
        public DateTime? StartTime { get; set; }

        [JsonPropertyName("CompletionTime")]
        public DateTime? CompletionTime { get; set; }

        [JsonPropertyName("WorkValue")]
        public decimal? WorkValue { get; set; }

        [JsonPropertyName("ProgressRate")]
        public decimal? ProgressRate { get; set; }

        [JsonPropertyName("RemainingWorkValue")]
        public decimal? RemainingWorkValue { get; set; }

        [JsonPropertyName("Status")]
        public int? Status { get; set; }

        [JsonPropertyName("Manager")]
        public int? Manager { get; set; }

        [JsonPropertyName("Owner")]
        public int? Owner { get; set; }

        [JsonPropertyName("Locked")]
        public bool? Locked { get; set; }

        [JsonPropertyName("Comments")]
        public string? Comments { get; set; }

        [JsonPropertyName("Creator")]
        public int? Creator { get; set; }

        [JsonPropertyName("Updator")]
        public int? Updator { get; set; }

        [JsonPropertyName("CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonPropertyName("ItemTitle")]
        public string? ItemTitle { get; set; }

        [JsonPropertyName("ClassHash")]
        public Dictionary<string, string>? ClassHash { get; set; }

        [JsonPropertyName("NumHash")]
        public Dictionary<string, decimal>? NumHash { get; set; }

        [JsonPropertyName("DateHash")]
        public Dictionary<string, DateTime>? DateHash { get; set; }

        [JsonPropertyName("DescriptionHash")]
        public Dictionary<string, string>? DescriptionHash { get; set; }

        [JsonPropertyName("CheckHash")]
        public Dictionary<string, bool>? CheckHash { get; set; }

        [JsonPropertyName("AttachmentsHash")]
        public Dictionary<string, List<AttachmentData>>? AttachmentsHash { get; set; }

        /// <summary>
        /// CommentsプロパティをCommentオブジェクトのリストとして取得します
        /// </summary>
        public List<Comment>? CommentList
        {
            get
            {
                if (string.IsNullOrEmpty(Comments))
                    return null;
                try
                {
                    return JsonSerializer.Deserialize<List<Comment>>(Comments);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
