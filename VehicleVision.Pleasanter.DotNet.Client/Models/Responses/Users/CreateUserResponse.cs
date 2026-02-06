namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Users;

/// <summary>
/// ユーザ作成レスポンス
/// </summary>
public class CreateUserResponse : ApiResponse<CreateUserData>;

/// <summary>
/// ユーザ作成データ
/// </summary>
public class CreateUserData
{
    /// <summary>
    /// 作成されたユーザID
    /// </summary>
    public long Id { get; set; }
}
