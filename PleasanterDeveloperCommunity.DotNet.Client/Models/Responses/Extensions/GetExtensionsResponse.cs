using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions;

/// <summary>
/// 拡張機能取得レスポンス
/// </summary>
public class GetExtensionsResponse
{
    /// <summary>
    /// ステータスコード
    /// </summary>
    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonProperty("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonProperty("Response")]
    public ExtensionsResponseData? Response { get; set; }
}

/// <summary>
/// 拡張機能レスポンスデータ
/// </summary>
public class ExtensionsResponseData
{
    /// <summary>
    /// データ
    /// </summary>
    [JsonProperty("Data")]
    public List<ExtensionData>? Data { get; set; }
}

/// <summary>
/// 拡張機能データ
/// </summary>
public class ExtensionData
{
    /// <summary>
    /// 拡張機能ID
    /// </summary>
    [JsonProperty("ExtensionId")]
    public long ExtensionId { get; set; }

    /// <summary>
    /// 種類
    /// </summary>
    [JsonProperty("ExtensionType")]
    public string? ExtensionType { get; set; }

    /// <summary>
    /// 拡張機能名
    /// </summary>
    [JsonProperty("ExtensionName")]
    public string? ExtensionName { get; set; }

    /// <summary>
    /// 説明
    /// </summary>
    [JsonProperty("ExtensionDescription")]
    public string? ExtensionDescription { get; set; }

    /// <summary>
    /// 設定
    /// </summary>
    [JsonProperty("ExtensionSettings")]
    public string? ExtensionSettings { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    [JsonProperty("Disabled")]
    public bool Disabled { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    [JsonProperty("Creator")]
    public long Creator { get; set; }

    /// <summary>
    /// 更新者
    /// </summary>
    [JsonProperty("Updator")]
    public long Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    [JsonProperty("CreatedTime")]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    [JsonProperty("UpdatedTime")]
    public DateTime UpdatedTime { get; set; }
}
