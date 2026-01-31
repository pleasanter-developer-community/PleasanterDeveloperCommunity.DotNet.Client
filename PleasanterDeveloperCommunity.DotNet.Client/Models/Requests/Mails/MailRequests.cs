using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Mails
{
    /// <summary>
    /// メール送信リクエスト
    /// </summary>
    public class SendMailRequest : ApiRequestBase
    {
        /// <summary>
        /// 宛先
        /// </summary>
        [JsonPropertyName("To")]
        public string? To { get; set; }

        /// <summary>
        /// CC
        /// </summary>
        [JsonPropertyName("Cc")]
        public string? Cc { get; set; }

        /// <summary>
        /// BCC
        /// </summary>
        [JsonPropertyName("Bcc")]
        public string? Bcc { get; set; }

        /// <summary>
        /// 件名
        /// </summary>
        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        /// <summary>
        /// 本文
        /// </summary>
        [JsonPropertyName("Body")]
        public string? Body { get; set; }
    }
}
