using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Users
{
    /// <summary>
    /// ユーザ取得リクエスト
    /// </summary>
    public class GetUsersRequest : ApiRequestBase
    {
        /// <summary>
        /// ビュー設定
        /// </summary>
        [JsonPropertyName("View")]
        public View? View { get; set; }

        /// <summary>
        /// 取得開始位置
        /// </summary>
        [JsonPropertyName("Offset")]
        public int? Offset { get; set; }
    }

    /// <summary>
    /// ユーザ作成リクエスト
    /// </summary>
    public class CreateUserRequest : ApiRequestBase
    {
        /// <summary>
        /// ログインID
        /// </summary>
        [JsonPropertyName("LoginId")]
        public string? LoginId { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        [JsonPropertyName("Password")]
        public string? Password { get; set; }

        /// <summary>
        /// ユーザコード
        /// </summary>
        [JsonPropertyName("UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// 生年月日
        /// </summary>
        [JsonPropertyName("Birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        [JsonPropertyName("Gender")]
        public string? Gender { get; set; }

        /// <summary>
        /// 言語
        /// </summary>
        [JsonPropertyName("Language")]
        public string? Language { get; set; }

        /// <summary>
        /// タイムゾーン
        /// </summary>
        [JsonPropertyName("TimeZone")]
        public string? TimeZone { get; set; }

        /// <summary>
        /// 組織ID
        /// </summary>
        [JsonPropertyName("DeptId")]
        public int? DeptId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        /// <summary>
        /// テナント管理者
        /// </summary>
        [JsonPropertyName("TenantManager")]
        public bool? TenantManager { get; set; }

        /// <summary>
        /// サービス管理者
        /// </summary>
        [JsonPropertyName("ServiceManager")]
        public bool? ServiceManager { get; set; }

        /// <summary>
        /// APIを許可
        /// </summary>
        [JsonPropertyName("AllowApi")]
        public bool? AllowApi { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        [JsonPropertyName("MailAddresses")]
        public List<string>? MailAddresses { get; set; }

        /// <summary>
        /// 分類項目
        /// </summary>
        [JsonPropertyName("ClassHash")]
        public Dictionary<string, string>? ClassHash { get; set; }

        /// <summary>
        /// 数値項目
        /// </summary>
        [JsonPropertyName("NumHash")]
        public Dictionary<string, decimal>? NumHash { get; set; }

        /// <summary>
        /// 日付項目
        /// </summary>
        [JsonPropertyName("DateHash")]
        public Dictionary<string, DateTime>? DateHash { get; set; }

        /// <summary>
        /// 説明項目
        /// </summary>
        [JsonPropertyName("DescriptionHash")]
        public Dictionary<string, string>? DescriptionHash { get; set; }

        /// <summary>
        /// チェック項目
        /// </summary>
        [JsonPropertyName("CheckHash")]
        public Dictionary<string, bool>? CheckHash { get; set; }
    }

    /// <summary>
    /// ユーザ更新リクエスト
    /// </summary>
    public class UpdateUserRequest : ApiRequestBase
    {
        /// <summary>
        /// ログインID
        /// </summary>
        [JsonPropertyName("LoginId")]
        public string? LoginId { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        [JsonPropertyName("Password")]
        public string? Password { get; set; }

        /// <summary>
        /// ユーザコード
        /// </summary>
        [JsonPropertyName("UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// 生年月日
        /// </summary>
        [JsonPropertyName("Birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        [JsonPropertyName("Gender")]
        public string? Gender { get; set; }

        /// <summary>
        /// 言語
        /// </summary>
        [JsonPropertyName("Language")]
        public string? Language { get; set; }

        /// <summary>
        /// タイムゾーン
        /// </summary>
        [JsonPropertyName("TimeZone")]
        public string? TimeZone { get; set; }

        /// <summary>
        /// 組織ID
        /// </summary>
        [JsonPropertyName("DeptId")]
        public int? DeptId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        /// <summary>
        /// テナント管理者
        /// </summary>
        [JsonPropertyName("TenantManager")]
        public bool? TenantManager { get; set; }

        /// <summary>
        /// サービス管理者
        /// </summary>
        [JsonPropertyName("ServiceManager")]
        public bool? ServiceManager { get; set; }

        /// <summary>
        /// APIを許可
        /// </summary>
        [JsonPropertyName("AllowApi")]
        public bool? AllowApi { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }

        /// <summary>
        /// ロックアウト
        /// </summary>
        [JsonPropertyName("Lockout")]
        public bool? Lockout { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        [JsonPropertyName("MailAddresses")]
        public List<string>? MailAddresses { get; set; }

        /// <summary>
        /// 分類項目
        /// </summary>
        [JsonPropertyName("ClassHash")]
        public Dictionary<string, string>? ClassHash { get; set; }

        /// <summary>
        /// 数値項目
        /// </summary>
        [JsonPropertyName("NumHash")]
        public Dictionary<string, decimal>? NumHash { get; set; }

        /// <summary>
        /// 日付項目
        /// </summary>
        [JsonPropertyName("DateHash")]
        public Dictionary<string, DateTime>? DateHash { get; set; }

        /// <summary>
        /// 説明項目
        /// </summary>
        [JsonPropertyName("DescriptionHash")]
        public Dictionary<string, string>? DescriptionHash { get; set; }

        /// <summary>
        /// チェック項目
        /// </summary>
        [JsonPropertyName("CheckHash")]
        public Dictionary<string, bool>? CheckHash { get; set; }
    }

    /// <summary>
    /// ユーザ削除リクエスト
    /// </summary>
    public class DeleteUserRequest : ApiRequestBase
    {
    }
}
