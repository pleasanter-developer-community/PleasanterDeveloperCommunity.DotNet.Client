using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループ削除レスポンス
/// </summary>
public class DeleteGroupResponse
{
    public int Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}
