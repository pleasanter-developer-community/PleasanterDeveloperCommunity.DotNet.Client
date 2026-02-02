using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Mails;

/// <summary>
/// メール送信リクエスト
/// </summary>
public class SendMailRequest : ApiRequestBase
{
    /// <summary>
    /// 送信元（Mail.jsonのFixedFrom値）
    /// </summary>
    [JsonProperty("From")]
    public string? From { get; set; }

    /// <summary>
    /// 宛先
    /// </summary>
    public string? To { get; set; }

    /// <summary>
    /// CC
    /// </summary>
    public string? Cc { get; set; }

    /// <summary>
    /// BCC
    /// </summary>
    public string? Bcc { get; set; }

    /// <summary>
    /// 件名
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 本文
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// 添付ファイル
    /// </summary>
    /// <remarks>
    /// プリザンター 1.2.4.0以降で対応
    /// </remarks>
    [JsonProperty("Attachments")]
    public List<MailAttachment>? Attachments { get; set; }
}

/// <summary>
/// メール添付ファイル
/// </summary>
public class MailAttachment
{
    /// <summary>
    /// ファイル名
    /// </summary>
    [JsonProperty("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// Base64エンコードされたファイル内容
    /// </summary>
    [JsonProperty("Base64")]
    public string? Base64 { get; set; }

    /// <summary>
    /// コンテンツタイプ
    /// </summary>
    [JsonProperty("ContentType")]
    public string? ContentType { get; set; }
}
