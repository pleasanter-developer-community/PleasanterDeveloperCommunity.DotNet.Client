using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織取得レスポンス
/// </summary>
public class GetDeptsResponse
{
    /// <summary>
    /// 組織データリスト
    /// </summary>
    public List<DeptData>? Data { get; set; }

    /// <summary>
    /// 総件数
    /// </summary>
    public int TotalCount { get; set; }
}

/// <summary>
/// 組織データ
/// </summary>
public class DeptData
{
    /// <summary>
    /// テナントID
    /// </summary>
    public int TenantId { get; set; }

    /// <summary>
    /// 組織ID
    /// </summary>
    public int DeptId { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    public int Ver { get; set; }

    /// <summary>
    /// 組織コード
    /// </summary>
    public string? DeptCode { get; set; }

    /// <summary>
    /// 組織名
    /// </summary>
    public string? DeptName { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// 無効フラグ
    /// </summary>
    public bool Disabled { get; set; }

    /// <summary>
    /// コメント
    /// </summary>
    public string? Comments { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    public int Creator { get; set; }

    /// <summary>
    /// 更新者ID
    /// </summary>
    public int Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    public DateTime? UpdatedTime { get; set; }
}
