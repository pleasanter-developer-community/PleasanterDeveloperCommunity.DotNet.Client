using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups
{
    /// <summary>
    /// グループ取得レスポンス
    /// </summary>
    public class GetGroupsResponse
    {
        [JsonPropertyName("Data")]
        public List<GroupData>? Data { get; set; }

        [JsonPropertyName("TotalCount")]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// グループデータ
    /// </summary>
    public class GroupData
    {
        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("GroupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("Ver")]
        public int Ver { get; set; }

        [JsonPropertyName("GroupName")]
        public string? GroupName { get; set; }

        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        [JsonPropertyName("Disabled")]
        public bool Disabled { get; set; }

        [JsonPropertyName("Comments")]
        public string? Comments { get; set; }

        [JsonPropertyName("Creator")]
        public int Creator { get; set; }

        [JsonPropertyName("Updator")]
        public int Updator { get; set; }

        [JsonPropertyName("CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonPropertyName("UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }

        [JsonPropertyName("GroupMembers")]
        public List<GroupMemberData>? GroupMembers { get; set; }
    }

    /// <summary>
    /// グループメンバーデータ
    /// </summary>
    public class GroupMemberData
    {
        [JsonPropertyName("GroupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("DeptId")]
        public int DeptId { get; set; }

        [JsonPropertyName("UserId")]
        public int UserId { get; set; }

        [JsonPropertyName("Admin")]
        public bool Admin { get; set; }
    }
}
