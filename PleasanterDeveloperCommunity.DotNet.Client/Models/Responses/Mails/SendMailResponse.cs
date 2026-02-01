using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Mails;

/// <summary>
/// メール送信レスポンス
/// </summary>
public class SendMailResponse
{
    /// <summary>
    /// ステータスコード
    /// </summary>
    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonProperty("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonProperty("Response")]
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
    [JsonProperty("Data")]
    public object? Data { get; set; }
}
