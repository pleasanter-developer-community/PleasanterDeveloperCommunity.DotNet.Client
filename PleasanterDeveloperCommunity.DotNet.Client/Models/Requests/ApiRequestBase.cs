using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// APIリクエストの基底クラス
/// </summary>
public abstract class ApiRequestBase
{
    /// <summary>
    /// APIバージョン
    /// </summary>
    [JsonPropertyName("ApiVersion")]
    public string? ApiVersion { get; set; }

    /// <summary>
    /// APIキー
    /// </summary>
    [JsonPropertyName("ApiKey")]
    public string? ApiKey { get; set; }
}
