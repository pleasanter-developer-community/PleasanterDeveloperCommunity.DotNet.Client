using System;
using System.Collections.Generic;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Users;

/// <summary>
/// ユーザ取得リクエスト
/// </summary>
public class GetUsersRequest : ApiRequestBase
{
    /// <summary>
    /// ビュー設定
    /// </summary>
    public View? View { get; set; }

    /// <summary>
    /// 取得開始位置
    /// </summary>
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
    public string? LoginId { get; set; }

    /// <summary>
    /// 名前
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// パスワード
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// ユーザコード
    /// </summary>
    public string? UserCode { get; set; }

    /// <summary>
    /// 生年月日
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// 言語
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// タイムゾーン
    /// </summary>
    public string? TimeZone { get; set; }

    /// <summary>
    /// 組織ID
    /// </summary>
    public int? DeptId { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// テナント管理者
    /// </summary>
    public bool? TenantManager { get; set; }

    /// <summary>
    /// サービス管理者
    /// </summary>
    public bool? ServiceManager { get; set; }

    /// <summary>
    /// APIを許可
    /// </summary>
    public bool? AllowApi { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    public bool? Disabled { get; set; }

    /// <summary>
    /// メールアドレス
    /// </summary>
    public List<string>? MailAddresses { get; set; }

    /// <summary>
    /// 分類項目
    /// </summary>
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
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
    public string? LoginId { get; set; }

    /// <summary>
    /// 名前
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// パスワード
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// ユーザコード
    /// </summary>
    public string? UserCode { get; set; }

    /// <summary>
    /// 生年月日
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// 言語
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// タイムゾーン
    /// </summary>
    public string? TimeZone { get; set; }

    /// <summary>
    /// 組織ID
    /// </summary>
    public int? DeptId { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// テナント管理者
    /// </summary>
    public bool? TenantManager { get; set; }

    /// <summary>
    /// サービス管理者
    /// </summary>
    public bool? ServiceManager { get; set; }

    /// <summary>
    /// APIを許可
    /// </summary>
    public bool? AllowApi { get; set; }

    /// <summary>
    /// 無効
    /// </summary>
    public bool? Disabled { get; set; }

    /// <summary>
    /// ロックアウト
    /// </summary>
    public bool? Lockout { get; set; }

    /// <summary>
    /// メールアドレス
    /// </summary>
    public List<string>? MailAddresses { get; set; }

    /// <summary>
    /// 分類項目
    /// </summary>
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目
    /// </summary>
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目
    /// </summary>
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目
    /// </summary>
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目
    /// </summary>
    public Dictionary<string, bool>? CheckHash { get; set; }
}

/// <summary>
/// ユーザ削除リクエスト
/// </summary>
public class DeleteUserRequest : ApiRequestBase
{
}
