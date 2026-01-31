using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses
{
    /// <summary>
    /// メール送信レスポンス
    /// </summary>
    public class SendMailResponse
    {
        /// <summary>
        /// ステータスコード
        /// </summary>
        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        /// <summary>
        /// レスポンスデータ
        /// </summary>
        [JsonPropertyName("Response")]
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
        [JsonPropertyName("Data")]
        public object? Data { get; set; }
    }
}
