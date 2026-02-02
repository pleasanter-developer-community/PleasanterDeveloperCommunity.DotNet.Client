using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイトパッケージコピーレスポンス
/// </summary>
public class CopySitePackageResponse
{
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
    public long OldSiteId { get; set; }

    public long NewSiteId { get; set; }

    public string? ReferenceType { get; set; }

    public string? Title { get; set; }
}
