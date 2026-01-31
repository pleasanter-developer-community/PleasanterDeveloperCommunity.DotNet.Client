using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses
{
    /// <summary>
    /// サイト作成レスポンス
    /// </summary>
    public class CreateSiteResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// サイト更新レスポンス
    /// </summary>
    public class UpdateSiteResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// サイト取得レスポンス
    /// </summary>
    public class GetSiteResponse
    {
        [JsonPropertyName("Data")]
        public GetSiteData? Data { get; set; }
    }

    /// <summary>
    /// サイト取得データ
    /// </summary>
    public class GetSiteData
    {
        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("SiteId")]
        public long SiteId { get; set; }

        [JsonPropertyName("UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }

        [JsonPropertyName("Ver")]
        public int Ver { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        [JsonPropertyName("SiteName")]
        public string? SiteName { get; set; }

        [JsonPropertyName("SiteGroupName")]
        public string? SiteGroupName { get; set; }

        [JsonPropertyName("GridGuide")]
        public string? GridGuide { get; set; }

        [JsonPropertyName("EditorGuide")]
        public string? EditorGuide { get; set; }

        [JsonPropertyName("CalendarGuide")]
        public string? CalendarGuide { get; set; }

        [JsonPropertyName("CrosstabGuide")]
        public string? CrosstabGuide { get; set; }

        [JsonPropertyName("GanttGuide")]
        public string? GanttGuide { get; set; }

        [JsonPropertyName("BurnDownGuide")]
        public string? BurnDownGuide { get; set; }

        [JsonPropertyName("TimeSeriesGuide")]
        public string? TimeSeriesGuide { get; set; }

        [JsonPropertyName("KambanGuide")]
        public string? KambanGuide { get; set; }

        [JsonPropertyName("ImageLibGuide")]
        public string? ImageLibGuide { get; set; }

        [JsonPropertyName("ReferenceType")]
        public string? ReferenceType { get; set; }

        [JsonPropertyName("ParentId")]
        public long ParentId { get; set; }

        [JsonPropertyName("InheritPermission")]
        public long InheritPermission { get; set; }

        [JsonPropertyName("Permissions")]
        public List<object>? Permissions { get; set; }

        [JsonPropertyName("SiteSettings")]
        public SiteSettings? SiteSettings { get; set; }

        [JsonPropertyName("Publish")]
        public bool Publish { get; set; }

        [JsonPropertyName("DisableCrossSearch")]
        public bool DisableCrossSearch { get; set; }

        [JsonPropertyName("LockedTime")]
        public DateTime? LockedTime { get; set; }

        [JsonPropertyName("LockedUser")]
        public int LockedUser { get; set; }

        [JsonPropertyName("ApiCountDate")]
        public DateTime? ApiCountDate { get; set; }

        [JsonPropertyName("ApiCount")]
        public int ApiCount { get; set; }

        [JsonPropertyName("Comments")]
        public string? Comments { get; set; }

        [JsonPropertyName("Creator")]
        public int Creator { get; set; }

        [JsonPropertyName("Updator")]
        public int Updator { get; set; }

        [JsonPropertyName("CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonPropertyName("ApiVersion")]
        public float ApiVersion { get; set; }

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

        [JsonPropertyName("AttachmentsHash")]
        public Dictionary<string, object>? AttachmentsHash { get; set; }
    }

    /// <summary>
    /// サイトID取得レスポンス
    /// </summary>
    public class GetClosestSiteIdResponse
    {
        [JsonPropertyName("SiteId")]
        public long SiteId { get; set; }

        [JsonPropertyName("Data")]
        public List<ClosestSiteIdData>? Data { get; set; }
    }

    /// <summary>
    /// 最近接サイトIDデータ
    /// </summary>
    public class ClosestSiteIdData
    {
        [JsonPropertyName("SiteName")]
        public string? SiteName { get; set; }

        [JsonPropertyName("SiteId")]
        public long SiteId { get; set; }
    }

    /// <summary>
    /// サイトパッケージコピーレスポンス
    /// </summary>
    public class CopySitePackageResponse
    {
        [JsonPropertyName("Data")]
        public string? Data { get; set; }

        /// <summary>
        /// コピーされたサイトの情報を取得
        /// </summary>
        public List<CopiedSiteInfo>? GetCopiedSites()
        {
            if (string.IsNullOrEmpty(Data))
                return null;
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<List<CopiedSiteInfo>>(Data);
            }
            catch
            {
                return null;
            }
        }
    }

    /// <summary>
    /// コピーされたサイト情報
    /// </summary>
    public class CopiedSiteInfo
    {
        [JsonPropertyName("OldSiteId")]
        public long OldSiteId { get; set; }

        [JsonPropertyName("NewSiteId")]
        public long NewSiteId { get; set; }

        [JsonPropertyName("ReferenceType")]
        public string? ReferenceType { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }
    }

    /// <summary>
    /// サイト削除レスポンス
    /// </summary>
    public class DeleteSiteResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// サマリ同期レスポンス
    /// </summary>
    public class SynchronizeSummariesResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// サイト設定更新レスポンス
    /// </summary>
    public class UpdateSiteSettingsResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }
}
