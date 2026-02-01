using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループ取得レスポンス
/// </summary>
public class GetGroupsResponse
{
    [JsonProperty("Data")]
    public List<GroupData>? Data { get; set; }

    [JsonProperty("TotalCount")]
    public int TotalCount { get; set; }
}

/// <summary>
/// グループデータ
/// </summary>
public class GroupData
{
    [JsonProperty("TenantId")]
    public int TenantId { get; set; }

    [JsonProperty("GroupId")]
    public int GroupId { get; set; }

    [JsonProperty("Ver")]
    public int Ver { get; set; }

    [JsonProperty("GroupName")]
    public string? GroupName { get; set; }

    [JsonProperty("Body")]
    public string? Body { get; set; }

    [JsonProperty("Disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("Comments")]
    public string? Comments { get; set; }

    [JsonProperty("Creator")]
    public int Creator { get; set; }

    [JsonProperty("Updator")]
    public int Updator { get; set; }

    [JsonProperty("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonProperty("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }

    [JsonProperty("GroupMembers")]
    public List<GroupMemberData>? GroupMembers { get; set; }
}

/// <summary>
/// グループメンバーデータ
/// </summary>
public class GroupMemberData
{
    [JsonProperty("GroupId")]
    public int GroupId { get; set; }

    [JsonProperty("DeptId")]
    public int DeptId { get; set; }

    [JsonProperty("UserId")]
    public int UserId { get; set; }

    [JsonProperty("Admin")]
    public bool Admin { get; set; }
}
