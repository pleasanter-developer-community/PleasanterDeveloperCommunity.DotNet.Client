namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

/// <summary>
/// ユーザ削除レスポンス
/// </summary>
public class DeleteUserResponse : ApiResponse<DeleteUserData>;

/// <summary>
/// ユーザ削除データ
/// </summary>
public class DeleteUserData
{
    /// <summary>
    /// 削除されたユーザID
    /// </summary>
    public long Id { get; set; }
}
