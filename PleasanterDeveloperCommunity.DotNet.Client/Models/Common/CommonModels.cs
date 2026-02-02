using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

/// <summary>
/// コメントデータ
/// </summary>
public class Comment
{
    public long CommentId { get; set; }

    public string? CreatedTime { get; set; }

    public string? UpdatedTime { get; set; }

    public int Creator { get; set; }

    public string? Body { get; set; }
}

/// <summary>
/// 添付ファイルデータ
/// </summary>
public class AttachmentData
{
    [JsonProperty("Guid")]
    public string? AttachmentGuid { get; set; }

    public string? Name { get; set; }

    public long Size { get; set; }

    public string? HashCode { get; set; }

    public bool? Deleted { get; set; }

    public string? ContentType { get; set; }

    public string? Base64 { get; set; }
}

/// <summary>
/// サイト設定
/// </summary>
public class SiteSettings
{
    public decimal? Version { get; set; }

    public List<string>? GridColumns { get; set; }

    public Dictionary<string, List<string>>? EditorColumnHash { get; set; }

    public List<ColumnDefinition>? Columns { get; set; }

    public List<object>? Links { get; set; }

    public List<object>? Summaries { get; set; }

    public List<object>? Formulas { get; set; }

    public List<object>? Processes { get; set; }

    public List<object>? Views { get; set; }

    public List<object>? Notifications { get; set; }

    public List<object>? Reminders { get; set; }

    public List<object>? Scripts { get; set; }

    public List<object>? Styles { get; set; }

    public List<object>? ServerScripts { get; set; }
}

/// <summary>
/// 列定義
/// </summary>
public class ColumnDefinition
{
    public string? ColumnName { get; set; }

    public string? LabelText { get; set; }

    public string? EditorFormat { get; set; }

    public string? ChoicesText { get; set; }

    public string? DefaultInput { get; set; }

    public bool? ValidateRequired { get; set; }
}

/// <summary>
/// 画像挿入設定
/// </summary>
public class ImageSettings
{
    public string? Base64 { get; set; }

    public string? Name { get; set; }
}

/// <summary>
/// レコードデータ
/// </summary>
public class RecordData
{
    public long SiteId { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public long? IssueId { get; set; }

    public long? ResultId { get; set; }

    public long? WikiId { get; set; }

    public int? Ver { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? CompletionTime { get; set; }

    public decimal? WorkValue { get; set; }

    public decimal? ProgressRate { get; set; }

    public decimal? RemainingWorkValue { get; set; }

    public int? Status { get; set; }

    public int? Manager { get; set; }

    public int? Owner { get; set; }

    public bool? Locked { get; set; }

    public string? Comments { get; set; }

    public int? Creator { get; set; }

    public int? Updator { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ItemTitle { get; set; }

    public Dictionary<string, string>? ClassHash { get; set; }

    public Dictionary<string, decimal>? NumHash { get; set; }

    public Dictionary<string, DateTime>? DateHash { get; set; }

    public Dictionary<string, string>? DescriptionHash { get; set; }

    public Dictionary<string, bool>? CheckHash { get; set; }

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
