using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイトID取得レスポンス（サイト名検索で該当サイトに最も近いサイトIDを取得）
/// </summary>
public class GetClosestSiteIdResponse : ListDataResponseBase<ClosestSiteIdData>
{
    /// <summary>
    /// サイトID（検索を開始したサイトのID）
    /// </summary>
    [JsonProperty("SiteId")]
    public long SiteId { get; set; }
}

/// <summary>
/// サイトID検索結果データ
/// </summary>
public class ClosestSiteIdData
{
    /// <summary>
    /// 検索したサイト名
    /// </summary>
    [JsonProperty("SiteName")]
    public string? SiteName { get; set; }

    /// <summary>
    /// サイトID（見つからなかった場合またはアクセス権が無い場合は-1）
    /// </summary>
    [JsonProperty("SiteId")]
    public long SiteId { get; set; }
}
