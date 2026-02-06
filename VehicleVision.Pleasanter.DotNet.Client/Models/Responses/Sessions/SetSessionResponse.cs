namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Sessions;

/// <summary>
/// セッション設定レスポンス
/// </summary>
public class SetSessionResponse
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
    public SetSessionResponseData? Response { get; set; }
}

/// <summary>
/// セッション設定レスポンスデータ
/// </summary>
public class SetSessionResponseData
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
