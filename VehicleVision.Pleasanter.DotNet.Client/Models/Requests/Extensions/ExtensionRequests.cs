using System;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Extensions;

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
    public string? ExtensionType { get; set; }

    /// <summary>
    /// 拡張機能名
    /// </summary>
    public string? ExtensionName { get; set; }

    /// <summary>
    /// 説明
    /// </summary>
    public string? ExtensionDescription { get; set; }

    /// <summary>
    /// 設定
    /// </summary>
    public string? ExtensionSettings { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
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
    public string? ExtensionType { get; set; }

    /// <summary>
    /// 拡張機能名
    /// </summary>
    public string? ExtensionName { get; set; }

    /// <summary>
    /// 説明
    /// </summary>
    public string? ExtensionDescription { get; set; }

    /// <summary>
    /// 設定
    /// </summary>
    public string? ExtensionSettings { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    public bool? Disabled { get; set; }
}

/// <summary>
/// 拡張機能削除リクエスト
/// </summary>
public class DeleteExtensionRequest : ApiRequestBase
{
}
