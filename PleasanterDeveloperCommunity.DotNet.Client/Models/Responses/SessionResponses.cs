using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses
{
    /// <summary>
    /// セッション取得レスポンス
    /// </summary>
    public class GetSessionResponse
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
        /// セッションデータ
        /// </summary>
        [JsonPropertyName("Response")]
        public SessionResponseData? Response { get; set; }
    }

    /// <summary>
    /// セッションレスポンスデータ
    /// </summary>
    public class SessionResponseData
    {
        /// <summary>
        /// データ
        /// </summary>
        [JsonPropertyName("Data")]
        public List<SessionData>? Data { get; set; }
    }

    /// <summary>
    /// セッションデータ
    /// </summary>
    public class SessionData
    {
        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// 値
        /// </summary>
        [JsonPropertyName("Value")]
        public string? Value { get; set; }
    }

    /// <summary>
    /// セッション設定レスポンス
    /// </summary>
    public class SetSessionResponse
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
    }

    /// <summary>
    /// セッション削除レスポンス
    /// </summary>
    public class DeleteSessionResponse
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
    }
}
