using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Groups
{
    /// <summary>
    /// グループ取得リクエスト
    /// </summary>
    public class GetGroupsRequest : ApiRequestBase
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
    /// グループ作成リクエスト
    /// </summary>
    public class CreateGroupRequest : ApiRequestBase
    {
        /// <summary>
        /// グループ名
        /// </summary>
        [JsonPropertyName("GroupName")]
        public string? GroupName { get; set; }

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

        /// <summary>
        /// グループメンバー
        /// </summary>
        [JsonPropertyName("GroupMembers")]
        public List<GroupMemberRequest>? GroupMembers { get; set; }
    }

    /// <summary>
    /// グループ更新リクエスト
    /// </summary>
    public class UpdateGroupRequest : ApiRequestBase
    {
        /// <summary>
        /// グループ名
        /// </summary>
        [JsonPropertyName("GroupName")]
        public string? GroupName { get; set; }

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

        /// <summary>
        /// グループメンバー
        /// </summary>
        [JsonPropertyName("GroupMembers")]
        public List<GroupMemberRequest>? GroupMembers { get; set; }
    }

    /// <summary>
    /// グループメンバーリクエスト
    /// </summary>
    public class GroupMemberRequest
    {
        /// <summary>
        /// 組織ID
        /// </summary>
        [JsonPropertyName("DeptId")]
        public int? DeptId { get; set; }

        /// <summary>
        /// ユーザID
        /// </summary>
        [JsonPropertyName("UserId")]
        public int? UserId { get; set; }

        /// <summary>
        /// 管理者
        /// </summary>
        [JsonPropertyName("Admin")]
        public bool? Admin { get; set; }
    }

    /// <summary>
    /// グループ削除リクエスト
    /// </summary>
    public class DeleteGroupRequest : ApiRequestBase
    {
    }
}
