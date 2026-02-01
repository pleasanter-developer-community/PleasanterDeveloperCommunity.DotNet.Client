using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

/// <summary>
/// コメントデータ
/// </summary>
public class Comment
{
    [JsonProperty("CommentId")]
    public long CommentId { get; set; }

    [JsonProperty("CreatedTime")]
    public string? CreatedTime { get; set; }

    [JsonProperty("UpdatedTime")]
    public string? UpdatedTime { get; set; }

    [JsonProperty("Creator")]
    public int Creator { get; set; }

    [JsonProperty("Body")]
    public string? Body { get; set; }
}

/// <summary>
/// 添付ファイルデータ
/// </summary>
public class AttachmentData
{
    [JsonProperty("Guid")]
    public string? Guid { get; set; }

    [JsonProperty("Name")]
    public string? Name { get; set; }

    [JsonProperty("Size")]
    public long Size { get; set; }

    [JsonProperty("HashCode")]
    public string? HashCode { get; set; }

    [JsonProperty("Deleted")]
    public bool? Deleted { get; set; }

    [JsonProperty("ContentType")]
    public string? ContentType { get; set; }

    [JsonProperty("Base64")]
    public string? Base64 { get; set; }
}

/// <summary>
/// サイト設定
/// </summary>
public class SiteSettings
{
    [JsonProperty("Version")]
    public decimal? Version { get; set; }

    [JsonProperty("GridColumns")]
    public List<string>? GridColumns { get; set; }

    [JsonProperty("EditorColumnHash")]
    public Dictionary<string, List<string>>? EditorColumnHash { get; set; }

    [JsonProperty("Columns")]
    public List<ColumnDefinition>? Columns { get; set; }

    [JsonProperty("Links")]
    public List<object>? Links { get; set; }

    [JsonProperty("Summaries")]
    public List<object>? Summaries { get; set; }

    [JsonProperty("Formulas")]
    public List<object>? Formulas { get; set; }

    [JsonProperty("Processes")]
    public List<object>? Processes { get; set; }

    [JsonProperty("Views")]
    public List<object>? Views { get; set; }

    [JsonProperty("Notifications")]
    public List<object>? Notifications { get; set; }

    [JsonProperty("Reminders")]
    public List<object>? Reminders { get; set; }

    [JsonProperty("Scripts")]
    public List<object>? Scripts { get; set; }

    [JsonProperty("Styles")]
    public List<object>? Styles { get; set; }

    [JsonProperty("ServerScripts")]
    public List<object>? ServerScripts { get; set; }
}

/// <summary>
/// 列定義
/// </summary>
public class ColumnDefinition
{
    [JsonProperty("ColumnName")]
    public string? ColumnName { get; set; }

    [JsonProperty("LabelText")]
    public string? LabelText { get; set; }

    [JsonProperty("EditorFormat")]
    public string? EditorFormat { get; set; }

    [JsonProperty("ChoicesText")]
    public string? ChoicesText { get; set; }

    [JsonProperty("DefaultInput")]
    public string? DefaultInput { get; set; }

    [JsonProperty("ValidateRequired")]
    public bool? ValidateRequired { get; set; }
}

/// <summary>
/// 画像挿入設定
/// </summary>
public class ImageSettings
{
    [JsonProperty("Base64")]
    public string? Base64 { get; set; }

    [JsonProperty("Name")]
    public string? Name { get; set; }
}

/// <summary>
/// レコードデータ
/// </summary>
public class RecordData
{
    [JsonProperty("SiteId")]
    public long SiteId { get; set; }

    [JsonProperty("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }

    [JsonProperty("IssueId")]
    public long? IssueId { get; set; }

    [JsonProperty("ResultId")]
    public long? ResultId { get; set; }

    [JsonProperty("WikiId")]
    public long? WikiId { get; set; }

    [JsonProperty("Ver")]
    public int? Ver { get; set; }

    [JsonProperty("Title")]
    public string? Title { get; set; }

    [JsonProperty("Body")]
    public string? Body { get; set; }

    [JsonProperty("StartTime")]
    public DateTime? StartTime { get; set; }

    [JsonProperty("CompletionTime")]
    public DateTime? CompletionTime { get; set; }

    [JsonProperty("WorkValue")]
    public decimal? WorkValue { get; set; }

    [JsonProperty("ProgressRate")]
    public decimal? ProgressRate { get; set; }

    [JsonProperty("RemainingWorkValue")]
    public decimal? RemainingWorkValue { get; set; }

    [JsonProperty("Status")]
    public int? Status { get; set; }

    [JsonProperty("Manager")]
    public int? Manager { get; set; }

    [JsonProperty("Owner")]
    public int? Owner { get; set; }

    [JsonProperty("Locked")]
    public bool? Locked { get; set; }

    [JsonProperty("Comments")]
    public string? Comments { get; set; }

    [JsonProperty("Creator")]
    public int? Creator { get; set; }

    [JsonProperty("Updator")]
    public int? Updator { get; set; }

    [JsonProperty("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonProperty("ItemTitle")]
    public string? ItemTitle { get; set; }

    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    [JsonProperty("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }

    [JsonProperty("AttachmentsHash")]
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
                return JsonConvert.DeserializeObject<List<Comment>>(Comments);
            }
            catch
            {
                return null;
            }
        }
    }
}
