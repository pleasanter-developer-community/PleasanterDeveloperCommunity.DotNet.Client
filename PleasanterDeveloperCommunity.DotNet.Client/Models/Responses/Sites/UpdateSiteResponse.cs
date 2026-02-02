using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト更新レスポンス
/// </summary>
public class UpdateSiteResponse
{
    public long Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}
