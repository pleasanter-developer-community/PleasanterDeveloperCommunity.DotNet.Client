using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Mails;

/// <summary>
/// メール送信リクエスト
/// </summary>
public class SendMailRequest : ApiRequestBase
{
    /// <summary>
    /// 宛先
    /// </summary>
    [JsonProperty("To")]
    public string? To { get; set; }

    /// <summary>
    /// CC
    /// </summary>
    [JsonProperty("Cc")]
    public string? Cc { get; set; }

    /// <summary>
    /// BCC
    /// </summary>
    [JsonProperty("Bcc")]
    public string? Bcc { get; set; }

    /// <summary>
    /// 件名
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 本文
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }
}
