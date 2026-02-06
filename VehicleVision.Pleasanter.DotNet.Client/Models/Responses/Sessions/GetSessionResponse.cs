namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Sessions;

/// <summary>
/// セッション取得レスポンス
/// </summary>
public class GetSessionResponse
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
    /// セッションデータ
    /// </summary>
    public GetSessionResponseData? Response { get; set; }
}

/// <summary>
/// セッション取得レスポンスデータ
/// </summary>
public class GetSessionResponseData
{
    /// <summary>
    /// ユーザーID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// セッションキー
    /// </summary>
    public string? Key { get; set; }

    /// <summary>
    /// セッション値
    /// </summary>
    public string? Value { get; set; }
}
