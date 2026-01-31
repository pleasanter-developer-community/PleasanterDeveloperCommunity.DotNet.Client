using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織更新レスポンス
/// </summary>
public class UpdateDeptResponse
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("StatusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("Message")]
    public string? Message { get; set; }
}
