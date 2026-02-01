using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイトID取得レスポンス
/// </summary>
public class GetClosestSiteIdResponse
{
    [JsonPropertyName("SiteId")]
    public long SiteId { get; set; }

    [JsonPropertyName("Data")]
    public List<ClosestSiteIdData>? Data { get; set; }
}

/// <summary>
/// 最近接サイトIDデータ
/// </summary>
public class ClosestSiteIdData
{
    [JsonPropertyName("SiteName")]
    public string? SiteName { get; set; }

    [JsonPropertyName("SiteId")]
    public long SiteId { get; set; }
}
