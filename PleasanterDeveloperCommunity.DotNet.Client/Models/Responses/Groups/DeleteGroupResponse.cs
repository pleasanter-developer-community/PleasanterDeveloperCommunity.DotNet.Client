using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループ削除レスポンス
/// </summary>
public class DeleteGroupResponse
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("StatusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("Message")]
    public string? Message { get; set; }
}
