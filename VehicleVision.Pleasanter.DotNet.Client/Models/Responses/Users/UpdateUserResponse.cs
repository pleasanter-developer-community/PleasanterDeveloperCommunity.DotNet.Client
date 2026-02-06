namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Users;

/// <summary>
/// ユーザ更新レスポンス
/// </summary>
public class UpdateUserResponse : ApiResponse<UpdateUserData>;

/// <summary>
/// ユーザ更新データ
/// </summary>
public class UpdateUserData
{
    /// <summary>
    /// 更新されたユーザID
    /// </summary>
    public long Id { get; set; }
}
