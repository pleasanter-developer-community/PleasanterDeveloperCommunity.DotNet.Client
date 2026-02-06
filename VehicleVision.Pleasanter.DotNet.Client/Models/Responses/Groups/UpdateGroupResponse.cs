namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループ更新レスポンス
/// </summary>
public class UpdateGroupResponse : ApiResponse<UpdateGroupData>;

/// <summary>
/// グループ更新データ
/// </summary>
public class UpdateGroupData
{
    /// <summary>
    /// 更新されたグループID
    /// </summary>
    public long Id { get; set; }
}
