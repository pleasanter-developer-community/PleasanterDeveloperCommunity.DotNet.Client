using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// ルックアップ設定を表すクラスです。
    /// </summary>
    public class Lookup
    {
        /// <summary>
        /// 取得元の列名
        /// </summary>
        [JsonPropertyName("From")]
        public string? From { get; set; }

        /// <summary>
        /// 設定先の列名
        /// </summary>
        [JsonPropertyName("To")]
        public string? To { get; set; }

        /// <summary>
        /// 上書き
        /// </summary>
        [JsonPropertyName("Overwrite")]
        public bool? Overwrite { get; set; }
    }
}
