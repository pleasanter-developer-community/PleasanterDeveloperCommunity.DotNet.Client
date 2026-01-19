using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Resources;
using PleasanterDeveloperCommunity.DotNet.Client.Validation;
using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード操作リクエストの共通基底クラス（ApiRequestとRecordDataBaseを統合）
/// </summary>
public abstract class RecordRequestBase : ApiRequest
{
    /// <summary>
    /// タイトル
    /// </summary>
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonPropertyName("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// 状況
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
    /// プロセスID
    /// </summary>
    [JsonPropertyName("ProcessId")]
    public int? ProcessId { get; set; }

    /// <summary>
    /// 複数のプロセスID
    /// </summary>
    [JsonPropertyName("ProcessIds")]
    public List<int>? ProcessIds { get; set; }

    /// <summary>
    /// 分類項目（ClassA〜ClassZ, Class001〜Class999）
    /// </summary>
    [JsonPropertyName("ClassHash")]
    [RegexKeyDictionary(ColumnPatterns.ClassHashKeyPattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.ClassHashKeyError))]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目（NumA〜NumZ, Num001〜Num999）
    /// </summary>
    [JsonPropertyName("NumHash")]
    [RegexKeyDictionary(ColumnPatterns.NumHashKeyPattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.NumHashKeyError))]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目（DateA〜DateZ, Date001〜Date999）
    /// </summary>
    [JsonPropertyName("DateHash")]
    [RegexKeyDictionary(ColumnPatterns.DateHashKeyPattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.DateHashKeyError))]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目（DescriptionA〜DescriptionZ, Description001〜Description999）
    /// </summary>
    [JsonPropertyName("DescriptionHash")]
    [RegexKeyDictionary(ColumnPatterns.DescriptionHashKeyPattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.DescriptionHashKeyError))]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目（CheckA〜CheckZ, Check001〜Check999）
    /// </summary>
    [JsonPropertyName("CheckHash")]
    [RegexKeyDictionary(ColumnPatterns.CheckHashKeyPattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.CheckHashKeyError))]
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 添付ファイル項目（AttachmentsA〜AttachmentsZ, Attachments001〜Attachments999）
    /// </summary>
    [JsonPropertyName("AttachmentsHash")]
    [RegexKeyDictionary(ColumnPatterns.AttachmentsHashKeyPattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.AttachmentsHashKeyError))]
    public Dictionary<string, List<AttachmentData>>? AttachmentsHash { get; set; }

    /// <summary>
    /// 画像挿入設定（Body, Comments, DescriptionA〜DescriptionZ, Description001〜Description999）
    /// </summary>
    [JsonPropertyName("ImageHash")]
    [RegexKeyDictionary(ColumnPatterns.ImageHashKeyPattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.ImageHashKeyError))]
    public Dictionary<string, ImageSettings>? ImageHash { get; set; }
}
