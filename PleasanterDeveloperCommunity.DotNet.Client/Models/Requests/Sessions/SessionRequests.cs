using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sessions;

/// <summary>
/// セッション取得リクエスト
/// </summary>
public class GetSessionRequest : ApiRequestBase
{
    /// <summary>
    /// セッション名
    /// </summary>
    [JsonProperty("Name")]
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
    [JsonProperty("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// 値
    /// </summary>
    [JsonProperty("Value")]
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
    [JsonProperty("Name")]
    public string? Name { get; set; }
}
