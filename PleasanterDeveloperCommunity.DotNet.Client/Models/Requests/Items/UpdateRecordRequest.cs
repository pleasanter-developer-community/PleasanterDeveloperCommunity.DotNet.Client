using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード更新リクエスト
/// </summary>
public class UpdateRecordRequest : ApiRequestBase
{
    /// <summary>
    /// タイトル
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 本文
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// 状態
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 管理者
    /// </summary>
    public int? Manager { get; set; }

    /// <summary>
    /// 担当者
    /// </summary>
    public int? Owner { get; set; }

    /// <summary>
    /// 完了日時
    /// </summary>
    public string? CompletionTime { get; set; }

    /// <summary>
    /// 分類項目
    /// </summary>
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 添付ファイル
    /// </summary>
    public Dictionary<string, List<AttachmentData>>? AttachmentsHash { get; set; }

    /// <summary>
    /// プロセスID
    /// </summary>
    public int? ProcessId { get; set; }

    /// <summary>
    /// プロセスID一覧
    /// </summary>
    public List<int>? ProcessIds { get; set; }

    /// <summary>
    /// 画像設定
    /// </summary>
    public Dictionary<string, ImageSettings>? ImageHash { get; set; }

    /// <summary>
    /// レコード権限
    /// </summary>
    public List<string>? RecordPermissions { get; set; }
}
