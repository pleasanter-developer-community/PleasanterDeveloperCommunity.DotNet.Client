using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Extended
{
    /// <summary>
    /// 拡張SQLリクエスト
    /// </summary>
    public class ExtendedSqlRequest : ApiRequestBase
    {
        /// <summary>
        /// 拡張SQL名
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// 追加パラメータ（動的に追加されるプロパティ用）
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object>? AdditionalParameters { get; set; }
    }
}
