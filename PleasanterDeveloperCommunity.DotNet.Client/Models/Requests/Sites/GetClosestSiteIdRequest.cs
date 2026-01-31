using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites
{
    /// <summary>
    /// 最も近いサイトID取得リクエスト
    /// </summary>
    public class GetClosestSiteIdRequest : ApiRequestBase
    {
        /// <summary>
        /// 検索するサイト名一覧
        /// </summary>
        [JsonPropertyName("FindSiteNames")]
        public List<string>? FindSiteNames { get; set; }
    }
}
