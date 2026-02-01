using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイトパッケージコピーレスポンス
/// </summary>
public class CopySitePackageResponse
{
    [JsonProperty("Data")]
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
    [JsonProperty("OldSiteId")]
    public long OldSiteId { get; set; }

    [JsonProperty("NewSiteId")]
    public long NewSiteId { get; set; }

    [JsonProperty("ReferenceType")]
    public string? ReferenceType { get; set; }

    [JsonProperty("Title")]
    public string? Title { get; set; }
}
