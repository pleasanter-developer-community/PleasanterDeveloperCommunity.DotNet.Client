using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// サイト作成リクエスト
/// </summary>
public class CreateSiteRequest : ApiRequestBase
{
    /// <summary>
    /// タイトル
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 参照タイプ
    /// </summary>
    [JsonProperty("ReferenceType")]
    public string? ReferenceType { get; set; }

    /// <summary>
    /// テナントID
    /// </summary>
    [JsonProperty("TenantId")]
    public int? TenantId { get; set; }

    /// <summary>
    /// 権限継承元サイトID
    /// </summary>
    [JsonProperty("InheritPermission")]
    public long? InheritPermission { get; set; }

    /// <summary>
    /// サイト設定
    /// </summary>
    [JsonProperty("SiteSettings")]
    public SiteSettings? SiteSettings { get; set; }
}
