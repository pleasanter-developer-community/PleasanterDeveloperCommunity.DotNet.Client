using Newtonsoft.Json;
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
        [JsonProperty("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// 許可種類
        /// </summary>
        [JsonProperty("AllowedType")]
        public long? AllowedType { get; set; }

        /// <summary>
        /// 許可ユーザー
        /// </summary>
        [JsonProperty("AllowedUsers")]
        public List<int>? AllowedUsers { get; set; }

        /// <summary>
        /// 許可部署
        /// </summary>
        [JsonProperty("Depts")]
        public List<int>? Depts { get; set; }

        /// <summary>
        /// 許可グループ
        /// </summary>
        [JsonProperty("Groups")]
        public List<int>? Groups { get; set; }

        /// <summary>
        /// 許可ユーザー（ユーザーID）
        /// </summary>
        [JsonProperty("Users")]
        public List<int>? Users { get; set; }

        /// <summary>
        /// 記録許可種類
        /// </summary>
        [JsonProperty("RecordUsers")]
        public List<string>? RecordUsers { get; set; }
    }
}
