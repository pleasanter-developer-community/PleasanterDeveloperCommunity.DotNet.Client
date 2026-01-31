using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites
{
    /// <summary>
    /// サイトパッケージコピーレスポンス
    /// </summary>
    public class CopySitePackageResponse
    {
        [JsonPropertyName("Data")]
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
                return System.Text.Json.JsonSerializer.Deserialize<List<CopiedSiteInfo>>(Data);
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
        [JsonPropertyName("OldSiteId")]
        public long OldSiteId { get; set; }

        [JsonPropertyName("NewSiteId")]
        public long NewSiteId { get; set; }

        [JsonPropertyName("ReferenceType")]
        public string? ReferenceType { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }
    }
}
