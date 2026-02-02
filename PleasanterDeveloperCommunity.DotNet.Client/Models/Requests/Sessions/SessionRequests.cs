using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sessions;

/// <summary>
/// セッション取得リクエスト
/// </summary>
public class GetSessionRequest : ApiRequestBase
{
    /// <summary>
    /// セッション名
    /// </summary>
    public string? Name { get; set; }
}

/// <summary>
/// セッション設定リクエスト
/// </summary>
public class SetSessionRequest : ApiRequestBase
{
    /// <summary>
    /// セッション名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 値
    /// </summary>
    public string? Value { get; set; }
}

/// <summary>
/// セッション削除リクエスト
/// </summary>
public class DeleteSessionRequest : ApiRequestBase
{
    /// <summary>
    /// セッション名
    /// </summary>
    public string? Name { get; set; }
}
