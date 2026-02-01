using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Users;

/// <summary>
/// ユーザ取得リクエスト
/// </summary>
public class GetUsersRequest : ApiRequestBase
{
    /// <summary>
    /// ビュー設定
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }

    /// <summary>
    /// 取得開始位置
    /// </summary>
    [JsonProperty("Offset")]
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
    [JsonProperty("LoginId")]
    public string? LoginId { get; set; }

    /// <summary>
    /// 名前
    /// </summary>
    [JsonProperty("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// パスワード
    /// </summary>
    [JsonProperty("Password")]
    public string? Password { get; set; }

    /// <summary>
    /// ユーザコード
    /// </summary>
    [JsonProperty("UserCode")]
    public string? UserCode { get; set; }

    /// <summary>
    /// 生年月日
    /// </summary>
    [JsonProperty("Birthday")]
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    [JsonProperty("Gender")]
    public string? Gender { get; set; }

    /// <summary>
    /// 言語
    /// </summary>
    [JsonProperty("Language")]
    public string? Language { get; set; }

    /// <summary>
    /// タイムゾーン
    /// </summary>
    [JsonProperty("TimeZone")]
    public string? TimeZone { get; set; }

    /// <summary>
    /// 組織ID
    /// </summary>
    [JsonProperty("DeptId")]
    public int? DeptId { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// テナント管理者
    /// </summary>
    [JsonProperty("TenantManager")]
    public bool? TenantManager { get; set; }

    /// <summary>
    /// サービス管理者
    /// </summary>
    [JsonProperty("ServiceManager")]
    public bool? ServiceManager { get; set; }

    /// <summary>
    /// APIを許可
    /// </summary>
    [JsonProperty("AllowApi")]
    public bool? AllowApi { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    [JsonProperty("Disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// メールアドレス
    /// </summary>
    [JsonProperty("MailAddresses")]
    public List<string>? MailAddresses { get; set; }

    /// <summary>
    /// 分類項目
    /// </summary>
    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    [JsonProperty("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
    [JsonProperty("CheckHash")]
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
    [JsonProperty("LoginId")]
    public string? LoginId { get; set; }

    /// <summary>
    /// 名前
    /// </summary>
    [JsonProperty("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// パスワード
    /// </summary>
    [JsonProperty("Password")]
    public string? Password { get; set; }

    /// <summary>
    /// ユーザコード
    /// </summary>
    [JsonProperty("UserCode")]
    public string? UserCode { get; set; }

    /// <summary>
    /// 生年月日
    /// </summary>
    [JsonProperty("Birthday")]
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    [JsonProperty("Gender")]
    public string? Gender { get; set; }

    /// <summary>
    /// 言語
    /// </summary>
    [JsonProperty("Language")]
    public string? Language { get; set; }

    /// <summary>
    /// タイムゾーン
    /// </summary>
    [JsonProperty("TimeZone")]
    public string? TimeZone { get; set; }

    /// <summary>
    /// 組織ID
    /// </summary>
    [JsonProperty("DeptId")]
    public int? DeptId { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// テナント管理者
    /// </summary>
    [JsonProperty("TenantManager")]
    public bool? TenantManager { get; set; }

    /// <summary>
    /// サービス管理者
    /// </summary>
    [JsonProperty("ServiceManager")]
    public bool? ServiceManager { get; set; }

    /// <summary>
    /// APIを許可
    /// </summary>
    [JsonProperty("AllowApi")]
    public bool? AllowApi { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    [JsonProperty("Disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// ロックアウト
    /// </summary>
    [JsonProperty("Lockout")]
    public bool? Lockout { get; set; }

    /// <summary>
    /// メールアドレス
    /// </summary>
    [JsonProperty("MailAddresses")]
    public List<string>? MailAddresses { get; set; }

    /// <summary>
    /// 分類項目
    /// </summary>
    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    [JsonProperty("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }
}

/// <summary>
/// ユーザ削除リクエスト
/// </summary>
public class DeleteUserRequest : ApiRequestBase
{
}
