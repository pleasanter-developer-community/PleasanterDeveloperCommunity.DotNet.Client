using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites
{
    /// <summary>
    /// コピー対象サイト
    /// </summary>
    public class SelectedSite
    {
        [JsonPropertyName("SiteId")]
        public long SiteId { get; set; }

        [JsonPropertyName("IncludeData")]
        public bool? IncludeData { get; set; }
    }
}
