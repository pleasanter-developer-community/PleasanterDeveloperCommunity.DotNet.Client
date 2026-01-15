using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Validation;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード作成・更新（Upsert）リクエスト
/// </summary>
public class UpsertRecordRequest : ApiRequest
{
    /// <summary>
    /// キーとなる項目名の配列
    /// </summary>
    [JsonProperty("Keys")]
    [RegexList(View.ColumnNamePattern, ErrorMessage = "Keys の要素はプリザンターの有効な列名である必要があります。")]
    public List<string>? Keys { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// 状況
    /// </summary>
    [JsonProperty("Status")]
    public int? Status { get; set; }

    /// <summary>
    /// 管理者
    /// </summary>
    [JsonProperty("Manager")]
    public int? Manager { get; set; }

    /// <summary>
    /// 担当者
    /// </summary>
    [JsonProperty("Owner")]
    public int? Owner { get; set; }

    /// <summary>
    /// 完了日時
    /// </summary>
    [JsonProperty("CompletionTime")]
    public string? CompletionTime { get; set; }

    /// <summary>
    /// プロセスID
    /// </summary>
    [JsonProperty("ProcessId")]
    public int? ProcessId { get; set; }

    /// <summary>
    /// 複数のプロセスID
    /// </summary>
    [JsonProperty("ProcessIds")]
    public List<int>? ProcessIds { get; set; }

    /// <summary>
    /// 分類項目（ClassA〜ClassZ, Class001〜Class999）
    /// </summary>
    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目（NumA〜NumZ, Num001〜Num999）
    /// </summary>
    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目（DateA〜DateZ, Date001〜Date999）
    /// </summary>
    [JsonProperty("DateHash")]
    public Dictionary<string, string>? DateHash { get; set; }

    /// <summary>
    /// 説明項目（DescriptionA〜DescriptionZ, Description001〜Description999）
    /// </summary>
    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目（CheckA〜CheckZ, Check001〜Check999）
    /// </summary>
    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 画像挿入設定
    /// </summary>
    [JsonProperty("ImageHash")]
    public Dictionary<string, ImageSettings>? ImageHash { get; set; }
}
