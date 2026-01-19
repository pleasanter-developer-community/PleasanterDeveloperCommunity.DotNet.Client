using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// 列アクセス制御設定を表すクラスです。
    /// </summary>
    public class ColumnAccessControl
    {
        /// <summary>
        /// 列名
        /// </summary>
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// 許可種類
        /// </summary>
        [JsonPropertyName("AllowedType")]
        public long? AllowedType { get; set; }

        /// <summary>
        /// 許可ユーザー
        /// </summary>
        [JsonPropertyName("AllowedUsers")]
        public List<int>? AllowedUsers { get; set; }

        /// <summary>
        /// 許可部署
        /// </summary>
        [JsonPropertyName("Depts")]
        public List<int>? Depts { get; set; }

        /// <summary>
        /// 許可グループ
        /// </summary>
        [JsonPropertyName("Groups")]
        public List<int>? Groups { get; set; }

        /// <summary>
        /// 許可ユーザー（ユーザーID）
        /// </summary>
        [JsonPropertyName("Users")]
        public List<int>? Users { get; set; }

        /// <summary>
        /// 記録許可種類
        /// </summary>
        [JsonPropertyName("RecordUsers")]
        public List<string>? RecordUsers { get; set; }
    }
}
