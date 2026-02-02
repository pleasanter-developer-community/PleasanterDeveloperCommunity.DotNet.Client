using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイトパッケージコピーレスポンス
/// </summary>
public class CopySitePackageResponse
{
    /// <summary>
    /// データ（JSON文字列）
    /// </summary>
    public string? Data { get; set; }

    /// <summary>
    /// コピーされたサイトの情報を取得
    /// </summary>
    public List<CopiedSiteInfo>? GetCopiedSites()
    {
        if (string.IsNullOrEmpty(Data))
            return null;
        try
        {
            return JsonConvert.DeserializeObject<List<CopiedSiteInfo>>(Data);
        }
        catch
        {
            return null;
        }
    }
}

/// <summary>
/// コピーされたサイト情報
/// </summary>
public class CopiedSiteInfo
{
    /// <summary>
    /// コピー元サイトID
    /// </summary>
    public long OldSiteId { get; set; }

    /// <summary>
    /// コピー先サイトID
    /// </summary>
    public long NewSiteId { get; set; }

    /// <summary>
    /// 参照タイプ
    /// </summary>
    public string? ReferenceType { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    public string? Title { get; set; }
}
