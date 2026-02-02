using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループ取得レスポンス
/// </summary>
public class GetGroupsResponse
{
    public List<GroupData>? Data { get; set; }

    public int TotalCount { get; set; }
}

/// <summary>
/// グループデータ
/// </summary>
public class GroupData
{
    public int TenantId { get; set; }

    public int GroupId { get; set; }

    public int Ver { get; set; }

    public string? GroupName { get; set; }

    public string? Body { get; set; }

    public bool Disabled { get; set; }

    public string? Comments { get; set; }

    public int Creator { get; set; }

    public int Updator { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public List<GroupMemberData>? GroupMembers { get; set; }
}

/// <summary>
/// グループメンバーデータ
/// </summary>
public class GroupMemberData
{
    public int GroupId { get; set; }

    public int DeptId { get; set; }

    public int UserId { get; set; }

    public bool Admin { get; set; }
}
