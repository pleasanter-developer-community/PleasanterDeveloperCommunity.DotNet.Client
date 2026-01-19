using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコードデータ（API 1.1対応）
/// </summary>
public class RecordData
{
    private string? _comments;
    private List<Comment>? _commentList;
    /// <summary>
    /// サイトID
    /// </summary>
    [JsonPropertyName("SiteId")]
    public long SiteId { get; set; }

    /// <summary>
    /// レコードID（Issues）
    /// </summary>
    [JsonPropertyName("IssueId")]
    public long? IssueId { get; set; }

    /// <summary>
    /// レコードID（Results）
    /// </summary>
    [JsonPropertyName("ResultId")]
    public long? ResultId { get; set; }

    /// <summary>
    /// レコードIDを取得します（IssueIdまたはResultId）
    /// </summary>
    public long? RecordId => IssueId ?? ResultId;

    /// <summary>
    /// 更新日時
    /// </summary>
    [JsonPropertyName("UpdatedTime")]
    public string? UpdatedTime { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    [JsonPropertyName("Ver")]
    public int? Ver { get; set; }

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
    /// コメント（JSON文字列）
    /// </summary>
    [JsonPropertyName("Comments")]
    public string? Comments
    {
        get => _comments;
        set
        {
            _comments = value;
            _commentList = null; // キャッシュをクリア
        }
    }

    /// <summary>
    /// コメントのリスト（Comments プロパティをデシリアライズしたもの）
    /// </summary>
    [JsonIgnore]
    public List<Comment>? CommentList
    {
        get
        {
            if (_commentList != null)
            {
                return _commentList;
            }

            if (string.IsNullOrWhiteSpace(_comments))
            {
                return null;
            }

            try
            {
                _commentList = JsonSerializer.Deserialize<List<Comment>>(_comments);
            }
            catch
            {
                _commentList = null;
            }

            return _commentList;
        }
    }

    /// <summary>
    /// 作成者
    /// </summary>
    [JsonPropertyName("Creator")]
    public int? Creator { get; set; }

    /// <summary>
    /// 更新者
    /// </summary>
    [JsonPropertyName("Updator")]
    public int? Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    [JsonPropertyName("CreatedTime")]
    public string? CreatedTime { get; set; }

    /// <summary>
    /// 分類項目（API 1.1: ClassA〜ClassZ, Class001〜Class999）
    /// </summary>
    [JsonPropertyName("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目（API 1.1: NumA〜NumZ, Num001〜Num999）
    /// </summary>
    [JsonPropertyName("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目（API 1.1: DateA〜DateZ, Date001〜Date999）
    /// </summary>
    [JsonPropertyName("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目（API 1.1: DescriptionA〜DescriptionZ, Description001〜Description999）
    /// </summary>
    [JsonPropertyName("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目（API 1.1: CheckA〜CheckZ, Check001〜Check999）
    /// </summary>
    [JsonPropertyName("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 分類項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: ClassA, Class001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public string? GetClass(string columnName)
    {
        if (ClassHash is null)
        {
            return null;
        }

        return ClassHash.TryGetValue(columnName, out var value) ? value : null;
    }

    /// <summary>
    /// 数値項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: NumA, Num001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public decimal? GetNum(string columnName)
    {
        if (NumHash is null)
        {
            return null;
        }

        return NumHash.TryGetValue(columnName, out var value) ? value : null;
    }

    /// <summary>
    /// 日付項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: DateA, Date001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public DateTime? GetDate(string columnName)
    {
        if (DateHash is null)
        {
            return null;
        }

        return DateHash.TryGetValue(columnName, out var value) ? value : null;
    }

    /// <summary>
    /// 説明項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: DescriptionA, Description001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public string? GetDescription(string columnName)
    {
        if (DescriptionHash is null)
        {
            return null;
        }

        return DescriptionHash.TryGetValue(columnName, out var value) ? value : null;
    }

    /// <summary>
    /// チェック項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: CheckA, Check001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public bool? GetCheck(string columnName)
    {
        if (CheckHash is null)
        {
            return null;
        }

        return CheckHash.TryGetValue(columnName, out var value) ? value : null;
    }
}
