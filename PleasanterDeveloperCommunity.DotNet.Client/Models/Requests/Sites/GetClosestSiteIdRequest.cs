using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイトID取得リクエスト（サイト名検索で該当サイトに最も近いサイトIDを取得）
/// </summary>
public class GetClosestSiteIdRequest : ApiRequest
{
    /// <summary>
    /// 検索対象のサイト名の配列
    /// </summary>
    [JsonProperty("FindSiteNames")]
    public List<string>? FindSiteNames { get; set; }
}
