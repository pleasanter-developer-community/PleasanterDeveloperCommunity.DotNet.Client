using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト設定更新レスポンス
/// </summary>
public class UpdateSiteSettingsResponse
{
    [JsonProperty("Id")]
    public long Id { get; set; }

    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    [JsonProperty("Message")]
    public string? Message { get; set; }
}
