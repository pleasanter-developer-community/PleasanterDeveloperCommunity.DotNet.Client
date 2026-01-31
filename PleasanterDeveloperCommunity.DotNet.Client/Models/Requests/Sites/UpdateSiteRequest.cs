using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites
{
    /// <summary>
    /// サイト更新リクエスト
    /// </summary>
    public class UpdateSiteRequest : ApiRequestBase
    {
        /// <summary>
        /// タイトル
        /// </summary>
        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        /// <summary>
        /// 参照タイプ
        /// </summary>
        [JsonPropertyName("ReferenceType")]
        public string? ReferenceType { get; set; }

        /// <summary>
        /// テナントID
        /// </summary>
        [JsonPropertyName("TenantId")]
        public int? TenantId { get; set; }

        /// <summary>
        /// 親サイトID
        /// </summary>
        [JsonPropertyName("ParentId")]
        public long? ParentId { get; set; }

        /// <summary>
        /// 権限継承元サイトID
        /// </summary>
        [JsonPropertyName("InheritPermission")]
        public long? InheritPermission { get; set; }

        /// <summary>
        /// サイト設定
        /// </summary>
        [JsonPropertyName("SiteSettings")]
        public SiteSettings? SiteSettings { get; set; }
    }
}
