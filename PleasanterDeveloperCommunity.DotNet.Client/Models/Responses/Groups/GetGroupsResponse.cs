using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループ取得レスポンス
/// </summary>
public class GetGroupsResponse
{
    /// <summary>
    /// グループデータリスト
    /// </summary>
    public List<GroupData>? Data { get; set; }

    /// <summary>
    /// 総件数
    /// </summary>
    public int TotalCount { get; set; }
}

/// <summary>
/// グループデータ
/// </summary>
public class GroupData
{
    /// <summary>
    /// テナントID
    /// </summary>
    public int TenantId { get; set; }

    /// <summary>
    /// グループID
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    public int Ver { get; set; }

    /// <summary>
    /// グループ名
    /// </summary>
    public string? GroupName { get; set; }

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

    /// <summary>
    /// グループメンバーリスト
    /// </summary>
    public List<GroupMemberData>? GroupMembers { get; set; }
}

/// <summary>
/// グループメンバーデータ
/// </summary>
public class GroupMemberData
{
    /// <summary>
    /// グループID
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    /// 組織ID
    /// </summary>
    public int DeptId { get; set; }

    /// <summary>
    /// ユーザID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 管理者フラグ
    /// </summary>
    public bool Admin { get; set; }
}
