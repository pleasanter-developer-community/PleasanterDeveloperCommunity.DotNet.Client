using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト取得レスポンス
/// </summary>
public class GetSiteResponse
{
    [JsonProperty("Data")]
    public GetSiteData? Data { get; set; }
}

/// <summary>
/// サイト取得データ
/// </summary>
public class GetSiteData
{
    [JsonProperty("TenantId")]
    public int TenantId { get; set; }

    [JsonProperty("SiteId")]
    public long SiteId { get; set; }

    [JsonProperty("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }

    [JsonProperty("Ver")]
    public int Ver { get; set; }

    [JsonProperty("Title")]
    public string? Title { get; set; }

    [JsonProperty("Body")]
    public string? Body { get; set; }

    [JsonProperty("SiteName")]
    public string? SiteName { get; set; }

    [JsonProperty("SiteGroupName")]
    public string? SiteGroupName { get; set; }

    [JsonProperty("GridGuide")]
    public string? GridGuide { get; set; }

    [JsonProperty("EditorGuide")]
    public string? EditorGuide { get; set; }

    [JsonProperty("CalendarGuide")]
    public string? CalendarGuide { get; set; }

    [JsonProperty("CrosstabGuide")]
    public string? CrosstabGuide { get; set; }

    [JsonProperty("GanttGuide")]
    public string? GanttGuide { get; set; }

    [JsonProperty("BurnDownGuide")]
    public string? BurnDownGuide { get; set; }

    [JsonProperty("TimeSeriesGuide")]
    public string? TimeSeriesGuide { get; set; }

    [JsonProperty("KambanGuide")]
    public string? KambanGuide { get; set; }

    [JsonProperty("ImageLibGuide")]
    public string? ImageLibGuide { get; set; }

    [JsonProperty("ReferenceType")]
    public string? ReferenceType { get; set; }

    [JsonProperty("ParentId")]
    public long ParentId { get; set; }

    [JsonProperty("InheritPermission")]
    public long InheritPermission { get; set; }

    [JsonProperty("Permissions")]
    public List<object>? Permissions { get; set; }

    [JsonProperty("SiteSettings")]
    public SiteSettings? SiteSettings { get; set; }

    [JsonProperty("Publish")]
    public bool Publish { get; set; }

    [JsonProperty("DisableCrossSearch")]
    public bool DisableCrossSearch { get; set; }

    [JsonProperty("LockedTime")]
    public DateTime? LockedTime { get; set; }

    [JsonProperty("LockedUser")]
    public int LockedUser { get; set; }

    [JsonProperty("ApiCountDate")]
    public DateTime? ApiCountDate { get; set; }

    [JsonProperty("ApiCount")]
    public int ApiCount { get; set; }

    [JsonProperty("Comments")]
    public string? Comments { get; set; }

    [JsonProperty("Creator")]
    public int Creator { get; set; }

    [JsonProperty("Updator")]
    public int Updator { get; set; }

    [JsonProperty("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonProperty("ApiVersion")]
    public float ApiVersion { get; set; }

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

    [JsonProperty("AttachmentsHash")]
    public Dictionary<string, object>? AttachmentsHash { get; set; }
}
