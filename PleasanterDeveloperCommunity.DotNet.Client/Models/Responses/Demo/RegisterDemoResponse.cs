using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Demo;

/// <summary>
/// デモ登録レスポンス
/// </summary>
public class RegisterDemoResponse
{
    [JsonProperty("Id")]
    public long Id { get; set; }

    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    [JsonProperty("Message")]
    public string? Message { get; set; }
}
