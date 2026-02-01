using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sites;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient - サイト操作API
/// </summary>
public partial class PleasanterClient
{
    #region Create Site

    /// <summary>
    /// サイトを作成します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<CreateSiteResponse>> CreateSiteAsync(
        long parentSiteId,
        CreateSiteRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (string.IsNullOrEmpty(request.Title)) throw new ArgumentException("Title is required", nameof(request));
        if (string.IsNullOrEmpty(request.ReferenceType)) throw new ArgumentException("ReferenceType is required", nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<CreateSiteResponse>(
            $"/api/items/{parentSiteId}/createsite", request, timeout);
    }

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
        var request = new CreateSiteRequest
        {
            Title = title ?? throw new ArgumentNullException(nameof(title)),
            ReferenceType = referenceType.ToString(),
            TenantId = tenantId,
            InheritPermission = inheritPermission,
            SiteSettings = siteSettings
        };
        return await CreateSiteAsync(parentSiteId, request, timeout);
    }

    #endregion

    #region Get Site

    /// <summary>
    /// サイトを取得します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<GetSiteResponse>> GetSiteAsync(
        long siteId,
        GetSiteRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<GetSiteResponse>(
            $"/api/items/{siteId}/getsite", request, timeout);
    }

    /// <summary>
    /// サイトを取得します
    /// </summary>
    public async Task<ApiResponse<GetSiteResponse>> GetSiteAsync(
        long siteId,
        TimeSpan? timeout = null)
    {
        var request = new GetSiteRequest();
        return await GetSiteAsync(siteId, request, timeout);
    }

    #endregion

    #region Get Closest Site Id

    /// <summary>
    /// サイト名検索で最も近いサイトIDを取得します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<GetClosestSiteIdResponse>> GetClosestSiteIdAsync(
        long siteId,
        GetClosestSiteIdRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (request.FindSiteNames == null) throw new ArgumentException("FindSiteNames is required", nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<GetClosestSiteIdResponse>(
            $"/api/items/{siteId}/getclosestsiteid", request, timeout);
    }

    /// <summary>
    /// サイト名検索で最も近いサイトIDを取得します
    /// </summary>
    public async Task<ApiResponse<GetClosestSiteIdResponse>> GetClosestSiteIdAsync(
        long siteId,
        List<string> findSiteNames,
        TimeSpan? timeout = null)
    {
        var request = new GetClosestSiteIdRequest
        {
            FindSiteNames = findSiteNames ?? throw new ArgumentNullException(nameof(findSiteNames))
        };
        return await GetClosestSiteIdAsync(siteId, request, timeout);
    }

    #endregion

    #region Update Site

    /// <summary>
    /// サイトを更新します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<UpdateSiteResponse>> UpdateSiteAsync(
        long siteId,
        UpdateSiteRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateSiteResponse>(
            $"/api/items/{siteId}/updatesite", request, timeout);
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
        var request = new UpdateSiteRequest
        {
            Title = title,
            ReferenceType = referenceType?.ToString(),
            TenantId = tenantId,
            ParentId = parentId,
            InheritPermission = inheritPermission,
            SiteSettings = siteSettings
        };
        return await UpdateSiteAsync(siteId, request, timeout);
    }

    #endregion

    #region Copy Site Package

    /// <summary>
    /// サイトパッケージをコピーします（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<CopySitePackageResponse>> CopySitePackageAsync(
        long siteId,
        CopySitePackageRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (request.SelectedSites == null) throw new ArgumentException("SelectedSites is required", nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<CopySitePackageResponse>(
            $"/api/items/{siteId}/copysitepackage", request, timeout);
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
        var request = new CopySitePackageRequest
        {
            SelectedSites = selectedSites ?? throw new ArgumentNullException(nameof(selectedSites)),
            TargetSiteId = targetSiteId,
            SiteTitle = siteTitle,
            IncludeSitePermission = includeSitePermission,
            IncludeRecordPermission = includeRecordPermission,
            IncludeColumnPermission = includeColumnPermission,
            IncludeNotifications = includeNotifications,
            IncludeReminders = includeReminders
        };
        return await CopySitePackageAsync(siteId, request, timeout);
    }

    #endregion

    #region Delete Site

    /// <summary>
    /// サイトを削除します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<DeleteSiteResponse>> DeleteSiteAsync(
        long siteId,
        DeleteSiteRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteSiteResponse>(
            $"/api/items/{siteId}/deletesite", request, timeout);
    }

    /// <summary>
    /// サイトを削除します
    /// </summary>
    public async Task<ApiResponse<DeleteSiteResponse>> DeleteSiteAsync(
        long siteId,
        TimeSpan? timeout = null)
    {
        var request = new DeleteSiteRequest();
        return await DeleteSiteAsync(siteId, request, timeout);
    }

    #endregion

    #region Synchronize Summaries

    /// <summary>
    /// サマリを同期します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<SynchronizeSummariesResponse>> SynchronizeSummariesAsync(
        long siteId,
        SynchronizeSummariesRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<SynchronizeSummariesResponse>(
            $"/api/items/{siteId}/synchronizesummaries", request, timeout);
    }

    /// <summary>
    /// サマリを同期します
    /// </summary>
    public async Task<ApiResponse<SynchronizeSummariesResponse>> SynchronizeSummariesAsync(
        long siteId,
        TimeSpan? timeout = null)
    {
        var request = new SynchronizeSummariesRequest();
        return await SynchronizeSummariesAsync(siteId, request, timeout);
    }

    #endregion

    #region Update Site Settings

    /// <summary>
    /// サイト設定を更新します（部分追加/更新/削除）（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<UpdateSiteSettingsResponse>> UpdateSiteSettingsAsync(
        long siteId,
        UpdateSiteSettingsRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateSiteSettingsResponse>(
            $"/api/items/{siteId}/updatesitesettings", request, timeout);
    }

    /// <summary>
    /// サイト設定を更新します（部分追加/更新/削除）
    /// </summary>
    public async Task<ApiResponse<UpdateSiteSettingsResponse>> UpdateSiteSettingsAsync(
        long siteId,
        SiteSettings? siteSettings = null,
        TimeSpan? timeout = null)
    {
        var request = new UpdateSiteSettingsRequest
        {
            SiteSettings = siteSettings
        };
        return await UpdateSiteSettingsAsync(siteId, request, timeout);
    }

    #endregion
}