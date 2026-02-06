using System.Collections.Generic;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Sites;

/// <summary>
/// 最も近いサイトID取得リクエスト
/// </summary>
public class GetClosestSiteIdRequest : ApiRequestBase
{
    /// <summary>
    /// 検索するサイト名一覧
    /// </summary>
    public List<string>? FindSiteNames { get; set; }
}
