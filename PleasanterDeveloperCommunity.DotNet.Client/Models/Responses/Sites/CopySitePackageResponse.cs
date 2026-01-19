using System.Text.Json;
using System.Text.Json.Serialization;
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
    [JsonPropertyName("Data")]
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

        return JsonSerializer.Deserialize<List<CopiedSiteData>>(Data);
    }
}
