using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions;

/// <summary>
/// 拡張機能取得レスポンス
/// </summary>
public class GetExtensionsResponse
{
    /// <summary>
    /// ステータスコード
    /// </summary>
    [JsonPropertyName("StatusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonPropertyName("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonPropertyName("Response")]
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
    [JsonPropertyName("Data")]
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
    [JsonPropertyName("ExtensionId")]
    public long ExtensionId { get; set; }

    /// <summary>
    /// 種類
    /// </summary>
    [JsonPropertyName("ExtensionType")]
    public string? ExtensionType { get; set; }

    /// <summary>
    /// 拡張機能名
    /// </summary>
    [JsonPropertyName("ExtensionName")]
    public string? ExtensionName { get; set; }

    /// <summary>
    /// 説明
    /// </summary>
    [JsonPropertyName("ExtensionDescription")]
    public string? ExtensionDescription { get; set; }

    /// <summary>
    /// 設定
    /// </summary>
    [JsonPropertyName("ExtensionSettings")]
    public string? ExtensionSettings { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    [JsonPropertyName("Disabled")]
    public bool Disabled { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    [JsonPropertyName("Creator")]
    public long Creator { get; set; }

    /// <summary>
    /// 更新者
    /// </summary>
    [JsonPropertyName("Updator")]
    public long Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    [JsonPropertyName("CreatedTime")]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    [JsonPropertyName("UpdatedTime")]
    public DateTime UpdatedTime { get; set; }
}
