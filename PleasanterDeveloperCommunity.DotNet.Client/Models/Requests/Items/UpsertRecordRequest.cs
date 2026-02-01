using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコードUpsertリクエスト
/// </summary>
public class UpsertRecordRequest : ApiRequestBase
{
    /// <summary>
    /// キー項目
    /// </summary>
    [JsonProperty("Keys")]
    public List<string>? Keys { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 本文
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// 状態
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
    /// 分類項目
    /// </summary>
    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    [JsonProperty("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// プロセスID
    /// </summary>
    [JsonProperty("ProcessId")]
    public int? ProcessId { get; set; }

    /// <summary>
    /// プロセスID一覧
    /// </summary>
    [JsonProperty("ProcessIds")]
    public List<int>? ProcessIds { get; set; }

    /// <summary>
    /// 画像設定
    /// </summary>
    [JsonProperty("ImageHash")]
    public Dictionary<string, ImageSettings>? ImageHash { get; set; }
}
