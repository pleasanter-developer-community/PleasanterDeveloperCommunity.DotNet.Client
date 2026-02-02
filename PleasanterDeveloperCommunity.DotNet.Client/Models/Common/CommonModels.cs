using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

/// <summary>
/// コメントデータ
/// </summary>
public class Comment
{
    /// <summary>
    /// コメントID
    /// </summary>
    public long CommentId { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public string? CreatedTime { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    public string? UpdatedTime { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    public int Creator { get; set; }

    /// <summary>
    /// コメント本文
    /// </summary>
    public string? Body { get; set; }
}

/// <summary>
/// 添付ファイルデータ
/// </summary>
public class AttachmentData
{
    /// <summary>
    /// 添付ファイルのGUID
    /// </summary>
    [JsonPropertyName("Guid")]
    public string? AttachmentGuid { get; set; }

    /// <summary>
    /// ファイル名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// ファイルサイズ（バイト）
    /// </summary>
    public long Size { get; set; }

    /// <summary>
    /// ハッシュコード
    /// </summary>
    public string? HashCode { get; set; }

    /// <summary>
    /// 削除済みフラグ
    /// </summary>
    public bool? Deleted { get; set; }

    /// <summary>
    /// コンテンツタイプ
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// Base64エンコードされたファイルデータ
    /// </summary>
    public string? Base64 { get; set; }
}

/// <summary>
/// サイト設定
/// </summary>
public class SiteSettings
{
    /// <summary>
    /// バージョン
    /// </summary>
    public decimal? Version { get; set; }

    /// <summary>
    /// グリッド表示列
    /// </summary>
    public List<string>? GridColumns { get; set; }

    /// <summary>
    /// エディタ列ハッシュ
    /// </summary>
    public Dictionary<string, List<string>>? EditorColumnHash { get; set; }

    /// <summary>
    /// 列定義リスト
    /// </summary>
    public List<ColumnDefinition>? Columns { get; set; }

    /// <summary>
    /// リンク設定
    /// </summary>
    public List<object>? Links { get; set; }

    /// <summary>
    /// 集計設定
    /// </summary>
    public List<object>? Summaries { get; set; }

    /// <summary>
    /// 計算式設定
    /// </summary>
    public List<object>? Formulas { get; set; }

    /// <summary>
    /// プロセス設定
    /// </summary>
    public List<object>? Processes { get; set; }

    /// <summary>
    /// ビュー設定
    /// </summary>
    public List<object>? Views { get; set; }

    /// <summary>
    /// 通知設定
    /// </summary>
    public List<object>? Notifications { get; set; }

    /// <summary>
    /// リマインダー設定
    /// </summary>
    public List<object>? Reminders { get; set; }

    /// <summary>
    /// スクリプト設定
    /// </summary>
    public List<object>? Scripts { get; set; }

    /// <summary>
    /// スタイル設定
    /// </summary>
    public List<object>? Styles { get; set; }

    /// <summary>
    /// サーバースクリプト設定
    /// </summary>
    public List<object>? ServerScripts { get; set; }
}

/// <summary>
/// 列定義
/// </summary>
public class ColumnDefinition
{
    /// <summary>
    /// 列名
    /// </summary>
    public string? ColumnName { get; set; }

    /// <summary>
    /// ラベルテキスト
    /// </summary>
    public string? LabelText { get; set; }

    /// <summary>
    /// エディタ形式
    /// </summary>
    public string? EditorFormat { get; set; }

    /// <summary>
    /// 選択肢テキスト
    /// </summary>
    public string? ChoicesText { get; set; }

    /// <summary>
    /// 既定値
    /// </summary>
    public string? DefaultInput { get; set; }

    /// <summary>
    /// 必須入力フラグ
    /// </summary>
    public bool? ValidateRequired { get; set; }
}

/// <summary>
/// 画像挿入設定
/// </summary>
public class ImageSettings
{
    /// <summary>
    /// Base64エンコードされた画像データ
    /// </summary>
    public string? Base64 { get; set; }

    /// <summary>
    /// 画像ファイル名
    /// </summary>
    public string? Name { get; set; }
}

/// <summary>
/// レコードデータ
/// </summary>
public class RecordData
{
    /// <summary>
    /// サイトID
    /// </summary>
    public long SiteId { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// 課題ID
    /// </summary>
    public long? IssueId { get; set; }

    /// <summary>
    /// 結果ID
    /// </summary>
    public long? ResultId { get; set; }

    /// <summary>
    /// WikiID
    /// </summary>
    public long? WikiId { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    public int? Ver { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 本文
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// 開始日時
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// 完了日時
    /// </summary>
    public DateTime? CompletionTime { get; set; }

    /// <summary>
    /// 作業量
    /// </summary>
    public decimal? WorkValue { get; set; }

    /// <summary>
    /// 進捗率
    /// </summary>
    public decimal? ProgressRate { get; set; }

    /// <summary>
    /// 残作業量
    /// </summary>
    public decimal? RemainingWorkValue { get; set; }

    /// <summary>
    /// 状況
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 管理者ID
    /// </summary>
    public int? Manager { get; set; }

    /// <summary>
    /// 担当者ID
    /// </summary>
    public int? Owner { get; set; }

    /// <summary>
    /// ロック状態
    /// </summary>
    public bool? Locked { get; set; }

    /// <summary>
    /// コメント（JSON文字列）
    /// </summary>
    public string? Comments { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    public int? Creator { get; set; }

    /// <summary>
    /// 更新者ID
    /// </summary>
    public int? Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// アイテムタイトル
    /// </summary>
    public string? ItemTitle { get; set; }

    /// <summary>
    /// 分類項目ハッシュ
    /// </summary>
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目ハッシュ
    /// </summary>
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目ハッシュ
    /// </summary>
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目ハッシュ
    /// </summary>
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目ハッシュ
    /// </summary>
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 添付ファイルハッシュ
    /// </summary>
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
