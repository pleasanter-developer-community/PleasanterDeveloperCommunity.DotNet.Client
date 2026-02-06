namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織削除レスポンス
/// </summary>
public class DeleteDeptResponse
{
    /// <summary>
    /// 削除された組織ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ステータスコード
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    public string? Message { get; set; }
}
