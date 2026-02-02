using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// 最近接サイトIDレスポンスデータ
/// </summary>
/// <remarks>
/// <see cref="ApiResponse{T}"/> の <c>Response</c> プロパティとして使用されます。
/// </remarks>
public class GetClosestSiteIdResponseData
{
    /// <summary>
    /// 検索起点のサイトID
    /// </summary>
    public long SiteId { get; set; }

    /// <summary>
    /// 最近接サイトIDデータのリスト
    /// </summary>
    public List<ClosestSiteIdData>? Data { get; set; }
}

/// <summary>
/// 最近接サイトIDデータ
/// </summary>
public class ClosestSiteIdData
{
    /// <summary>
    /// 検索対象のサイト名
    /// </summary>
    public string? SiteName { get; set; }

    /// <summary>
    /// 見つかったサイトID
    /// </summary>
    /// <remarks>
    /// サイトが見つからなかった場合は <c>-1</c> が返却されます。
    /// </remarks>
    public long SiteId { get; set; }
}
