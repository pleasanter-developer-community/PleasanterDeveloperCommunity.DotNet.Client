namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Sessions;

/// <summary>
/// セッション削除レスポンス
/// </summary>
public class DeleteSessionResponse
{
    /// <summary>
    /// ステータスコード
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    public DeleteSessionResponseData? Response { get; set; }
}

/// <summary>
/// セッション削除レスポンスデータ
/// </summary>
public class DeleteSessionResponseData
{
    /// <summary>
    /// ユーザーID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// セッションキー
    /// </summary>
    public string? Key { get; set; }
}
