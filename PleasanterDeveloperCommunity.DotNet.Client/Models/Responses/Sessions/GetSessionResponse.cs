using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sessions;

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
