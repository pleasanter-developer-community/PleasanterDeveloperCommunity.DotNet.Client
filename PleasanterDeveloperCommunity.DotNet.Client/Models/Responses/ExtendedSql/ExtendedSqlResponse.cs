using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.ExtendedSql;

/// <summary>
/// 拡張SQL APIレスポンス
/// </summary>
public class ExtendedSqlResponse
{
    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonProperty("Data")]
    public ExtendedSqlData? Data { get; set; }
}


