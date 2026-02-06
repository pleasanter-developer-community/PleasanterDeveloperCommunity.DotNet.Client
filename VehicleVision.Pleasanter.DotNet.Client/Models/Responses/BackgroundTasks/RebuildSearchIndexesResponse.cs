namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.BackgroundTasks;

/// <summary>
/// 検索インデックス再構築レスポンス
/// </summary>
public class RebuildSearchIndexesResponse
{
    /// <summary>
    /// タスクID
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
}
