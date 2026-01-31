using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient - サイト操作API
    /// </summary>
    public partial class PleasanterClient
    {
        /// <summary>
        /// サイトを作成します
        /// </summary>
        public async Task<ApiResponse<CreateSiteResponse>> CreateSiteAsync(
            long parentSiteId,
            string title,
            SiteReferenceType referenceType,
            int? tenantId = null,
            long? inheritPermission = null,
            SiteSettings? siteSettings = null,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey,
                ["Title"] = title ?? throw new ArgumentNullException(nameof(title)),
                ["ReferenceType"] = referenceType.ToString()
            };

            if (tenantId.HasValue)
                request["TenantId"] = tenantId.Value;

            if (inheritPermission.HasValue)
                request["InheritPermission"] = inheritPermission.Value;

            if (siteSettings != null)
                request["SiteSettings"] = siteSettings;

            return await SendRequestAsync<CreateSiteResponse>(
                $"/api/items/{parentSiteId}/createsite", request, timeout);
        }

        /// <summary>
        /// サイトを取得します
        /// </summary>
        public async Task<ApiResponse<GetSiteResponse>> GetSiteAsync(
            long siteId,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey
            };

            return await SendRequestAsync<GetSiteResponse>(
                $"/api/items/{siteId}/getsite", request, timeout);
        }

        /// <summary>
        /// サイト名検索で最も近いサイトIDを取得します
        /// </summary>
        public async Task<ApiResponse<GetClosestSiteIdResponse>> GetClosestSiteIdAsync(
            long siteId,
            List<string> findSiteNames,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey,
                ["FindSiteNames"] = findSiteNames ?? throw new ArgumentNullException(nameof(findSiteNames))
            };

            return await SendRequestAsync<GetClosestSiteIdResponse>(
                $"/api/items/{siteId}/getclosestsiteid", request, timeout);
        }

        /// <summary>
        /// サイトを更新します
        /// </summary>
        public async Task<ApiResponse<UpdateSiteResponse>> UpdateSiteAsync(
            long siteId,
            string? title = null,
            SiteReferenceType? referenceType = null,
            int? tenantId = null,
            long? parentId = null,
            long? inheritPermission = null,
            SiteSettings? siteSettings = null,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey
            };

            if (title != null)
                request["Title"] = title;

            if (referenceType.HasValue)
                request["ReferenceType"] = referenceType.Value.ToString();

            if (tenantId.HasValue)
                request["TenantId"] = tenantId.Value;

            if (parentId.HasValue)
                request["ParentId"] = parentId.Value;

            if (inheritPermission.HasValue)
                request["InheritPermission"] = inheritPermission.Value;

            if (siteSettings != null)
                request["SiteSettings"] = siteSettings;

            return await SendRequestAsync<UpdateSiteResponse>(
                $"/api/items/{siteId}/updatesite", request, timeout);
        }

        /// <summary>
        /// サイトパッケージをコピーします
        /// </summary>
        public async Task<ApiResponse<CopySitePackageResponse>> CopySitePackageAsync(
            long siteId,
            List<SelectedSite> selectedSites,
            long? targetSiteId = null,
            string? siteTitle = null,
            bool? includeSitePermission = null,
            bool? includeRecordPermission = null,
            bool? includeColumnPermission = null,
            bool? includeNotifications = null,
            bool? includeReminders = null,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey,
                ["SelectedSites"] = selectedSites ?? throw new ArgumentNullException(nameof(selectedSites))
            };

            if (targetSiteId.HasValue)
                request["TargetSiteId"] = targetSiteId.Value;

            if (siteTitle != null)
                request["SiteTitle"] = siteTitle;

            if (includeSitePermission.HasValue)
                request["IncludeSitePermission"] = includeSitePermission.Value;

            if (includeRecordPermission.HasValue)
                request["IncludeRecordPermission"] = includeRecordPermission.Value;

            if (includeColumnPermission.HasValue)
                request["IncludeColumnPermission"] = includeColumnPermission.Value;

            if (includeNotifications.HasValue)
                request["IncludeNotifications"] = includeNotifications.Value;

            if (includeReminders.HasValue)
                request["IncludeReminders"] = includeReminders.Value;

            return await SendRequestAsync<CopySitePackageResponse>(
                $"/api/items/{siteId}/copysitepackage", request, timeout);
        }
    }
}
