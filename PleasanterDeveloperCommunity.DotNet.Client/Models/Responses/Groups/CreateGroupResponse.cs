namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループ作成レスポンス
/// </summary>
public class CreateGroupResponse : ApiResponse<CreateGroupData>;

/// <summary>
/// グループ作成データ
/// </summary>
public class CreateGroupData
{
    /// <summary>
    /// 作成されたグループID
    /// </summary>
    public long Id { get; set; }
}
