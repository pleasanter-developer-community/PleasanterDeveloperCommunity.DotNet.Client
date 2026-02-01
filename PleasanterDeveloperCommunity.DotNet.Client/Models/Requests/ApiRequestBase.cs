using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// APIリクエストの基底クラス
/// </summary>
public abstract class ApiRequestBase
{
    /// <summary>
    /// APIバージョン
    /// </summary>
    [JsonProperty("ApiVersion")]
    public string? ApiVersion { get; set; }

    /// <summary>
    /// APIキー
    /// </summary>
    [JsonProperty("ApiKey")]
    public string? ApiKey { get; set; }
}
