using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 拡張SQL実行レスポンス
/// </summary>
public class ExtendedSqlResponse
{
    [JsonPropertyName("Data")]
    public List<Dictionary<string, object>>? Data { get; set; }
}
