using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.ExtendedSql;

/// <summary>
/// 拡張SQL APIリクエスト
/// </summary>
public class ExtendedSqlRequest : ApiRequest
{
    /// <summary>
    /// 拡張SQLの名前（JSONファイルで定義したName）
    /// </summary>
    [JsonProperty("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// SQLに渡すパラメータ
    /// </summary>
    [JsonProperty("Params")]
    public Dictionary<string, object>? Params { get; set; }
}
