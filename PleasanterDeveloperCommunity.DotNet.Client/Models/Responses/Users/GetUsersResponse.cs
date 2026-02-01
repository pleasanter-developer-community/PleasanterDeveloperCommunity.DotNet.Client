using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

/// <summary>
/// ユーザ取得レスポンス
/// </summary>
public class GetUsersResponse
{
    [JsonProperty("Data")]
    public List<UserData>? Data { get; set; }

    [JsonProperty("TotalCount")]
    public int TotalCount { get; set; }
}

/// <summary>
/// ユーザデータ
/// </summary>
public class UserData
{
    [JsonProperty("TenantId")]
    public int TenantId { get; set; }

    [JsonProperty("UserId")]
    public int UserId { get; set; }

    [JsonProperty("Ver")]
    public int Ver { get; set; }

    [JsonProperty("LoginId")]
    public string? LoginId { get; set; }

    [JsonProperty("GlobalId")]
    public string? GlobalId { get; set; }

    [JsonProperty("Name")]
    public string? Name { get; set; }

    [JsonProperty("UserCode")]
    public string? UserCode { get; set; }

    [JsonProperty("Birthday")]
    public DateTime? Birthday { get; set; }

    [JsonProperty("Gender")]
    public string? Gender { get; set; }

    [JsonProperty("Language")]
    public string? Language { get; set; }

    [JsonProperty("TimeZone")]
    public string? TimeZone { get; set; }

    [JsonProperty("DeptId")]
    public int DeptId { get; set; }

    [JsonProperty("Dept")]
    public string? Dept { get; set; }

    [JsonProperty("FirstAndLastNameOrder")]
    public int FirstAndLastNameOrder { get; set; }

    [JsonProperty("Body")]
    public string? Body { get; set; }

    [JsonProperty("LastLoginTime")]
    public DateTime? LastLoginTime { get; set; }

    [JsonProperty("PasswordExpirationTime")]
    public DateTime? PasswordExpirationTime { get; set; }

    [JsonProperty("PasswordChangeTime")]
    public DateTime? PasswordChangeTime { get; set; }

    [JsonProperty("NumberOfLogins")]
    public int NumberOfLogins { get; set; }

    [JsonProperty("NumberOfDenial")]
    public int NumberOfDenial { get; set; }

    [JsonProperty("TenantManager")]
    public bool TenantManager { get; set; }

    [JsonProperty("ServiceManager")]
    public bool ServiceManager { get; set; }

    [JsonProperty("AllowCreationAtTopSite")]
    public bool AllowCreationAtTopSite { get; set; }

    [JsonProperty("AllowGroupAdministration")]
    public bool AllowGroupAdministration { get; set; }

    [JsonProperty("AllowGroupCreation")]
    public bool AllowGroupCreation { get; set; }

    [JsonProperty("AllowApi")]
    public bool AllowApi { get; set; }

    [JsonProperty("EnableSecondaryAuthentication")]
    public bool EnableSecondaryAuthentication { get; set; }

    [JsonProperty("Disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("Lockout")]
    public bool Lockout { get; set; }

    [JsonProperty("LockoutCounter")]
    public int LockoutCounter { get; set; }

    [JsonProperty("Developer")]
    public bool Developer { get; set; }

    [JsonProperty("Comments")]
    public string? Comments { get; set; }

    [JsonProperty("Creator")]
    public int Creator { get; set; }

    [JsonProperty("Updator")]
    public int Updator { get; set; }

    [JsonProperty("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonProperty("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }

    [JsonProperty("MailAddresses")]
    public List<string>? MailAddresses { get; set; }

    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    [JsonProperty("DateHash")]
    public Dictionary<string, DateTime>? DateHash { get; set; }

    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }
}
