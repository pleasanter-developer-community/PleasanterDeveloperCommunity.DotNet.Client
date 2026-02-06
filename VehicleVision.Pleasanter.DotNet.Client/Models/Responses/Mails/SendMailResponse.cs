namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Mails;

/// <summary>
/// メール送信レスポンス
/// </summary>
public class SendMailResponse
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
    public SendMailResponseData? Response { get; set; }
}

/// <summary>
/// メール送信レスポンスデータ
/// </summary>
public class SendMailResponseData
{
    /// <summary>
    /// 送信結果
    /// </summary>
    public object? Data { get; set; }
}
