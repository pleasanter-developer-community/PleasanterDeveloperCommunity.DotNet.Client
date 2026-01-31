using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users
{
    /// <summary>
    /// ユーザ取得レスポンス
    /// </summary>
    public class GetUsersResponse
    {
        [JsonPropertyName("Data")]
        public List<UserData>? Data { get; set; }

        [JsonPropertyName("TotalCount")]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// ユーザデータ
    /// </summary>
    public class UserData
    {
        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("UserId")]
        public int UserId { get; set; }

        [JsonPropertyName("Ver")]
        public int Ver { get; set; }

        [JsonPropertyName("LoginId")]
        public string? LoginId { get; set; }

        [JsonPropertyName("GlobalId")]
        public string? GlobalId { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("UserCode")]
        public string? UserCode { get; set; }

        [JsonPropertyName("Birthday")]
        public DateTime? Birthday { get; set; }

        [JsonPropertyName("Gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("Language")]
        public string? Language { get; set; }

        [JsonPropertyName("TimeZone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("DeptId")]
        public int DeptId { get; set; }

        [JsonPropertyName("Dept")]
        public string? Dept { get; set; }

        [JsonPropertyName("FirstAndLastNameOrder")]
        public int FirstAndLastNameOrder { get; set; }

        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        [JsonPropertyName("LastLoginTime")]
        public DateTime? LastLoginTime { get; set; }

        [JsonPropertyName("PasswordExpirationTime")]
        public DateTime? PasswordExpirationTime { get; set; }

        [JsonPropertyName("PasswordChangeTime")]
        public DateTime? PasswordChangeTime { get; set; }

        [JsonPropertyName("NumberOfLogins")]
        public int NumberOfLogins { get; set; }

        [JsonPropertyName("NumberOfDenial")]
        public int NumberOfDenial { get; set; }

        [JsonPropertyName("TenantManager")]
        public bool TenantManager { get; set; }

        [JsonPropertyName("ServiceManager")]
        public bool ServiceManager { get; set; }

        [JsonPropertyName("AllowCreationAtTopSite")]
        public bool AllowCreationAtTopSite { get; set; }

        [JsonPropertyName("AllowGroupAdministration")]
        public bool AllowGroupAdministration { get; set; }

        [JsonPropertyName("AllowGroupCreation")]
        public bool AllowGroupCreation { get; set; }

        [JsonPropertyName("AllowApi")]
        public bool AllowApi { get; set; }

        [JsonPropertyName("EnableSecondaryAuthentication")]
        public bool EnableSecondaryAuthentication { get; set; }

        [JsonPropertyName("Disabled")]
        public bool Disabled { get; set; }

        [JsonPropertyName("Lockout")]
        public bool Lockout { get; set; }

        [JsonPropertyName("LockoutCounter")]
        public int LockoutCounter { get; set; }

        [JsonPropertyName("Developer")]
        public bool Developer { get; set; }

        [JsonPropertyName("Comments")]
        public string? Comments { get; set; }

        [JsonPropertyName("Creator")]
        public int Creator { get; set; }

        [JsonPropertyName("Updator")]
        public int Updator { get; set; }

        [JsonPropertyName("CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonPropertyName("UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }

        [JsonPropertyName("MailAddresses")]
        public List<string>? MailAddresses { get; set; }

        [JsonPropertyName("ClassHash")]
        public Dictionary<string, string>? ClassHash { get; set; }

        [JsonPropertyName("NumHash")]
        public Dictionary<string, decimal>? NumHash { get; set; }

        [JsonPropertyName("DateHash")]
        public Dictionary<string, DateTime>? DateHash { get; set; }

        [JsonPropertyName("DescriptionHash")]
        public Dictionary<string, string>? DescriptionHash { get; set; }

        [JsonPropertyName("CheckHash")]
        public Dictionary<string, bool>? CheckHash { get; set; }
    }
}
