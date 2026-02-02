using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

/// <summary>
/// ユーザ取得レスポンス
/// </summary>
public class GetUsersResponse
{
    /// <summary>
    /// ユーザデータリスト
    /// </summary>
    public List<UserData>? Data { get; set; }

    /// <summary>
    /// 総件数
    /// </summary>
    public int TotalCount { get; set; }
}

/// <summary>
/// ユーザデータ
/// </summary>
public class UserData
{
    /// <summary>
    /// テナントID
    /// </summary>
    public int TenantId { get; set; }

    /// <summary>
    /// ユーザID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    public int Ver { get; set; }

    /// <summary>
    /// ログインID
    /// </summary>
    public string? LoginId { get; set; }

    /// <summary>
    /// グローバルID
    /// </summary>
    public string? GlobalId { get; set; }

    /// <summary>
    /// 名前
    /// </summary>
    public string? Name { get; set; }

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
    public int DeptId { get; set; }

    /// <summary>
    /// 組織名
    /// </summary>
    public string? Dept { get; set; }

    /// <summary>
    /// 氏名の表示順序
    /// </summary>
    public int FirstAndLastNameOrder { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// 最終ログイン日時
    /// </summary>
    public DateTime? LastLoginTime { get; set; }

    /// <summary>
    /// パスワード有効期限
    /// </summary>
    public DateTime? PasswordExpirationTime { get; set; }

    /// <summary>
    /// パスワード変更日時
    /// </summary>
    public DateTime? PasswordChangeTime { get; set; }

    /// <summary>
    /// ログイン回数
    /// </summary>
    public int NumberOfLogins { get; set; }

    /// <summary>
    /// 認証失敗回数
    /// </summary>
    public int NumberOfDenial { get; set; }

    /// <summary>
    /// テナント管理者フラグ
    /// </summary>
    public bool TenantManager { get; set; }

    /// <summary>
    /// サービス管理者フラグ
    /// </summary>
    public bool ServiceManager { get; set; }

    /// <summary>
    /// トップレベルサイト作成許可フラグ
    /// </summary>
    public bool AllowCreationAtTopSite { get; set; }

    /// <summary>
    /// グループ管理許可フラグ
    /// </summary>
    public bool AllowGroupAdministration { get; set; }

    /// <summary>
    /// グループ作成許可フラグ
    /// </summary>
    public bool AllowGroupCreation { get; set; }

    /// <summary>
    /// API許可フラグ
    /// </summary>
    public bool AllowApi { get; set; }

    /// <summary>
    /// 二要素認証有効フラグ
    /// </summary>
    public bool EnableSecondaryAuthentication { get; set; }

    /// <summary>
    /// 無効フラグ
    /// </summary>
    public bool Disabled { get; set; }

    /// <summary>
    /// ロックアウトフラグ
    /// </summary>
    public bool Lockout { get; set; }

    /// <summary>
    /// ロックアウトカウンタ
    /// </summary>
    public int LockoutCounter { get; set; }

    /// <summary>
    /// 開発者フラグ
    /// </summary>
    public bool Developer { get; set; }

    /// <summary>
    /// コメント
    /// </summary>
    public string? Comments { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    public int Creator { get; set; }

    /// <summary>
    /// 更新者ID
    /// </summary>
    public int Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// メールアドレスリスト
    /// </summary>
    public List<string>? MailAddresses { get; set; }

    /// <summary>
    /// 分類項目ハッシュ
    /// </summary>
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目ハッシュ
    /// </summary>
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目ハッシュ
    /// </summary>
    public Dictionary<string, DateTime>? DateHash { get; set; }

    /// <summary>
    /// 説明項目ハッシュ
    /// </summary>
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目ハッシュ
    /// </summary>
    public Dictionary<string, bool>? CheckHash { get; set; }
}
