using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sessions;

/// <summary>
/// セッション取得レスポンス
/// </summary>
public class GetSessionResponse
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
    /// セッションデータ
    /// </summary>
    [JsonProperty("Response")]
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
    [JsonProperty("Data")]
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
    [JsonProperty("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// 値
    /// </summary>
    [JsonProperty("Value")]
    public string? Value { get; set; }
}
