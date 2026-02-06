namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Users;

/// <summary>
/// ユーザインポートレスポンス
/// </summary>
public class ImportUsersResponse : ApiResponse<ImportUsersData>;

/// <summary>
/// ユーザインポートデータ
/// </summary>
public class ImportUsersData
{
    /// <summary>
    /// インポート件数
    /// </summary>
    public int Imported { get; set; }

    /// <summary>
    /// 更新件数
    /// </summary>
    public int Updated { get; set; }
}
