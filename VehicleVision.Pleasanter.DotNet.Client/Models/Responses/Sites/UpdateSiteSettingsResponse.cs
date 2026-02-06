namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト設定更新レスポンス
/// </summary>
public class UpdateSiteSettingsResponse
{
    /// <summary>
    /// 更新されたサイトID
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
