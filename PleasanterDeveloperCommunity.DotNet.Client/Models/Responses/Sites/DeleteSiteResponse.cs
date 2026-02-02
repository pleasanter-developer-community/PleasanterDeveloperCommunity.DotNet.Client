using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト削除レスポンス
/// </summary>
public class DeleteSiteResponse
{
    public long Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}
