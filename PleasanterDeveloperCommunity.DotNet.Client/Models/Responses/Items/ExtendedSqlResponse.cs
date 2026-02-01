using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 拡張SQL実行レスポンス
/// </summary>
public class ExtendedSqlResponse
{
    [JsonProperty("Data")]
    public List<Dictionary<string, object>>? Data { get; set; }
}
