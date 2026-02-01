using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Depts;

/// <summary>
/// 組織取得リクエスト
/// </summary>
public class GetDeptsRequest : ApiRequestBase
{
    /// <summary>
    /// ビュー設定
    /// </summary>
    [JsonPropertyName("View")]
    public View? View { get; set; }

    /// <summary>
    /// 取得開始位置
    /// </summary>
    [JsonPropertyName("Offset")]
    public int? Offset { get; set; }
}

/// <summary>
/// 組織作成リクエスト
/// </summary>
public class CreateDeptRequest : ApiRequestBase
{
    /// <summary>
    /// 組織コード
    /// </summary>
    [JsonPropertyName("DeptCode")]
    public string? DeptCode { get; set; }

    /// <summary>
    /// 組織名
    /// </summary>
    [JsonPropertyName("DeptName")]
    public string? DeptName { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonPropertyName("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    [JsonPropertyName("Disabled")]
    public bool? Disabled { get; set; }
}

/// <summary>
/// 組織更新リクエスト
/// </summary>
public class UpdateDeptRequest : ApiRequestBase
{
    /// <summary>
    /// 組織コード
    /// </summary>
    [JsonPropertyName("DeptCode")]
    public string? DeptCode { get; set; }

    /// <summary>
    /// 組織名
    /// </summary>
    [JsonPropertyName("DeptName")]
    public string? DeptName { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonPropertyName("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    [JsonPropertyName("Disabled")]
    public bool? Disabled { get; set; }
}

/// <summary>
/// 組織削除リクエスト
/// </summary>
public class DeleteDeptRequest : ApiRequestBase
{
}
