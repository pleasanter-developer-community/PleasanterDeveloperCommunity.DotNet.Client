using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイトコピーレスポンス
/// </summary>
public class CopySitePackageResponse
{
    /// <summary>
    /// コピーされたサイトのデータ（JSON文字列）
    /// </summary>
    /// <remarks>
    /// Pleasanter APIはこのフィールドをJSON文字列として返すため、
    /// パースが必要な場合は GetCopiedSites() メソッドを使用してください。
    /// </remarks>
    [JsonProperty("Data")]
    public string? Data { get; set; }

    /// <summary>
    /// コピーされたサイトのリストを取得します
    /// </summary>
    /// <returns>コピーされたサイトの情報リスト</returns>
    public List<CopiedSiteData>? GetCopiedSites()
    {
        if (string.IsNullOrEmpty(Data))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<List<CopiedSiteData>>(Data);
    }
}
