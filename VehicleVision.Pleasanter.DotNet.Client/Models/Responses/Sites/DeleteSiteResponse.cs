namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト削除レスポンス
/// </summary>
public class DeleteSiteResponse
{
    /// <summary>
    /// 削除されたサイトID
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
