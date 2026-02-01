using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織削除レスポンス
/// </summary>
public class DeleteDeptResponse
{
    [JsonProperty("Id")]
    public int Id { get; set; }

    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    [JsonProperty("Message")]
    public string? Message { get; set; }
}
