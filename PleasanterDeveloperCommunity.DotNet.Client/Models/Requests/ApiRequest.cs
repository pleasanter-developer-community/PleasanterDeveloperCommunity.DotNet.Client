using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// APIリクエストの基底クラス
/// </summary>
public class ApiRequest
{
    /// <summary>
    /// APIバージョン（1.1固定）
    /// </summary>
    [JsonProperty("ApiVersion")]
    public string ApiVersion { get; } = "1.1";

    /// <summary>
    /// APIキー
    /// </summary>
    [JsonProperty("ApiKey")]
    public string? ApiKey { get; set; }
}
