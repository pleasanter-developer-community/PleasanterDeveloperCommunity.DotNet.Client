using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイトID取得レスポンス
/// </summary>
public class GetClosestSiteIdResponse
{
    [JsonProperty("SiteId")]
    public long SiteId { get; set; }

    [JsonProperty("Data")]
    public List<ClosestSiteIdData>? Data { get; set; }
}

/// <summary>
/// 最近接サイトIDデータ
/// </summary>
public class ClosestSiteIdData
{
    [JsonProperty("SiteName")]
    public string? SiteName { get; set; }

    [JsonProperty("SiteId")]
    public long SiteId { get; set; }
}
