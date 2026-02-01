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
    /// <remarks>
    /// この値はPleasanterClient作成時に設定され、各メソッドでは変更できません。
    /// </remarks>
    [JsonProperty("ApiVersion")]
    public string? ApiVersion { get; internal set; }

    /// <summary>
    /// APIキー
    /// </summary>
    /// <remarks>
    /// この値はPleasanterClient作成時に設定され、各メソッドでは変更できません。
    /// </remarks>
    [JsonProperty("ApiKey")]
    public string? ApiKey { get; internal set; }
}
