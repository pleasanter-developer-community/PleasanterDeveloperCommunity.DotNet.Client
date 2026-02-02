using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Mails;

/// <summary>
/// メール送信リクエスト
/// </summary>
public class SendMailRequest : ApiRequestBase
{
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
}
