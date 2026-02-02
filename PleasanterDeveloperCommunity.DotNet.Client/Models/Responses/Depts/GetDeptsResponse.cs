using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織取得レスポンス
/// </summary>
public class GetDeptsResponse
{
    public List<DeptData>? Data { get; set; }

    public int TotalCount { get; set; }
}

/// <summary>
/// 組織データ
/// </summary>
public class DeptData
{
    public int TenantId { get; set; }

    public int DeptId { get; set; }

    public int Ver { get; set; }

    public string? DeptCode { get; set; }

    public string? DeptName { get; set; }

    public string? Body { get; set; }

    public bool Disabled { get; set; }

    public string? Comments { get; set; }

    public int Creator { get; set; }

    public int Updator { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }
}
