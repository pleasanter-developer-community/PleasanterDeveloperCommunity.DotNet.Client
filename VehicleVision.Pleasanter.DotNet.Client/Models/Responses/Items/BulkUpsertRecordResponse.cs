namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 一括Upsertレスポンス
/// </summary>
public class BulkUpsertRecordResponse
{
    /// <summary>
    /// ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// ステータスコード
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 作成件数
    /// </summary>
    public int? Created { get; set; }

    /// <summary>
    /// 更新件数
    /// </summary>
    public int? Updated { get; set; }
}
