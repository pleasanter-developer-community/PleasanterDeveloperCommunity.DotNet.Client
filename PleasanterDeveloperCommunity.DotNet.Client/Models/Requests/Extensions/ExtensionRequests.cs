using System;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Extensions;

/// <summary>
/// 拡張機能取得リクエスト
/// </summary>
public class GetExtensionsRequest : ApiRequestBase
{
}

/// <summary>
/// 拡張機能作成リクエスト
/// </summary>
public class CreateExtensionRequest : ApiRequestBase
{
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
    public bool? Disabled { get; set; }
}

/// <summary>
/// 拡張機能更新リクエスト
/// </summary>
public class UpdateExtensionRequest : ApiRequestBase
{
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
    public bool? Disabled { get; set; }
}

/// <summary>
/// 拡張機能削除リクエスト
/// </summary>
public class DeleteExtensionRequest : ApiRequestBase
{
}
