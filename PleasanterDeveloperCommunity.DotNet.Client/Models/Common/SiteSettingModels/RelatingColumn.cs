using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// 関連列設定を表すクラスです。
    /// </summary>
    public class RelatingColumn
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [JsonProperty("Title")]
        public string? Title { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [JsonProperty("Columns")]
        public List<string>? Columns { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
