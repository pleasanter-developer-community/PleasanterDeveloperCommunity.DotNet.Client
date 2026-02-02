using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sessions;

/// <summary>
/// セッション取得レスポンス
/// </summary>
public class GetSessionResponse
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
    /// セッションデータ
    /// </summary>
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
    public string? Name { get; set; }

    /// <summary>
    /// 値
    /// </summary>
    public string? Value { get; set; }
}
