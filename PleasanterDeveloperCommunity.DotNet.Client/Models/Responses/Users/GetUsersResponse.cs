using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

/// <summary>
/// ユーザ取得レスポンス
/// </summary>
public class GetUsersResponse
{
    public List<UserData>? Data { get; set; }

    public int TotalCount { get; set; }
}

/// <summary>
/// ユーザデータ
/// </summary>
public class UserData
{
    public int TenantId { get; set; }

    public int UserId { get; set; }

    public int Ver { get; set; }

    public string? LoginId { get; set; }

    public string? GlobalId { get; set; }

    public string? Name { get; set; }

    public string? UserCode { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? Language { get; set; }

    public string? TimeZone { get; set; }

    public int DeptId { get; set; }

    public string? Dept { get; set; }

    public int FirstAndLastNameOrder { get; set; }

    public string? Body { get; set; }

    public DateTime? LastLoginTime { get; set; }

    public DateTime? PasswordExpirationTime { get; set; }

    public DateTime? PasswordChangeTime { get; set; }

    public int NumberOfLogins { get; set; }

    public int NumberOfDenial { get; set; }

    public bool TenantManager { get; set; }

    public bool ServiceManager { get; set; }

    public bool AllowCreationAtTopSite { get; set; }

    public bool AllowGroupAdministration { get; set; }

    public bool AllowGroupCreation { get; set; }

    public bool AllowApi { get; set; }

    public bool EnableSecondaryAuthentication { get; set; }

    public bool Disabled { get; set; }

    public bool Lockout { get; set; }

    public int LockoutCounter { get; set; }

    public bool Developer { get; set; }

    public string? Comments { get; set; }

    public int Creator { get; set; }

    public int Updator { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public List<string>? MailAddresses { get; set; }

    public Dictionary<string, string>? ClassHash { get; set; }

    public Dictionary<string, decimal>? NumHash { get; set; }

    public Dictionary<string, DateTime>? DateHash { get; set; }

    public Dictionary<string, string>? DescriptionHash { get; set; }

    public Dictionary<string, bool>? CheckHash { get; set; }
}