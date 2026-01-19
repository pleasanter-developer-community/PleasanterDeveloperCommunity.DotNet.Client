using System.Text.Json.Serialization;
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
    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// SQLに渡すパラメータ
    /// </summary>
    [JsonPropertyName("Params")]
    public Dictionary<string, object>? Params { get; set; }
}
