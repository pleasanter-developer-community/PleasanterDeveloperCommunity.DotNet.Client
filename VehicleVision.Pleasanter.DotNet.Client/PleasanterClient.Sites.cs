using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleVision.Pleasanter.DotNet.Client.Models.Common;
using VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Sites;
using VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Types;
using VehicleVision.Pleasanter.DotNet.Client.Models.Responses;
using VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Sites;

namespace VehicleVision.Pleasanter.DotNet.Client;
/// <summary>
/// PleasanterClient - サイト操作API
/// </summary>
public partial class PleasanterClient
{
    #region Create Site

    /// <summary>
    /// サイトを作成します
    /// </summary>
    /// <seealso href="../docs/wiki/02-サイト操作-01-サイト-作成.md">Wiki: 02-サイト操作-01-サイト-作成</seealso>
    /// <param name="parentSiteId">親サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>サイト作成レスポンス</returns>
    public async Task<ApiResponse<CreateSiteResponse>> CreateSiteAsync(
        long parentSiteId,
        CreateSiteRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (string.IsNullOrEmpty(request.Title))
        {
            throw new ArgumentException("Title is required", nameof(request));
        }
        if (string.IsNullOrEmpty(request.ReferenceType))
        {
            throw new ArgumentException("ReferenceType is required", nameof(request));
        }
        SetApiCredentials(request);
        return await SendRequestAsync<CreateSiteResponse>(
            $"/api/items/{parentSiteId}/createsite", request, timeout, cancellationToken);
    }

    #endregion

    #region Get Site

    /// <summary>
    /// サイトを取得します
    /// </summary>
    /// <seealso href="../docs/wiki/02-サイト操作-03-サイト-取得.md">Wiki: 02-サイト操作-03-サイト-取得</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>サイト取得レスポンス</returns>
    public async Task<ApiResponse<GetSiteResponse>> GetSiteAsync(
        long siteId,
        GetSiteRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<GetSiteResponse>(
            $"/api/items/{siteId}/getsite", request, timeout, cancellationToken);
    }

    #endregion

    #region Get Closest Site Id

    /// <summary>
    /// サイト名検索で最も近いサイトIDを取得します
    /// </summary>
    /// <seealso href="../docs/wiki/02-サイト操作-04-サイト-サイトID取得.md">Wiki: 02-サイト操作-04-サイト-サイトID取得</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>サイトID取得レスポンス</returns>
    public async Task<ApiResponse<GetClosestSiteIdResponseData>> GetClosestSiteIdAsync(
        long siteId,
        GetClosestSiteIdRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.FindSiteNames is null)
        {
            throw new ArgumentException("FindSiteNames is required", nameof(request));
        }
        SetApiCredentials(request);
        return await SendRequestAsync<GetClosestSiteIdResponseData>(
            $"/api/items/{siteId}/getclosestsiteid", request, timeout, cancellationToken);
    }

    #endregion

    #region Update Site

    /// <summary>
    /// サイトを更新します
    /// </summary>
    /// <seealso href="../docs/wiki/02-サイト操作-05-サイト-更新.md">Wiki: 02-サイト操作-05-サイト-更新</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>サイト更新レスポンス</returns>
    public async Task<ApiResponse<UpdateSiteResponse>> UpdateSiteAsync(
        long siteId,
        UpdateSiteRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateSiteResponse>(
            $"/api/items/{siteId}/updatesite", request, timeout, cancellationToken);
    }

    #endregion

    #region Copy Site Package

    /// <summary>
    /// サイトパッケージをコピーします
    /// </summary>
    /// <seealso href="../docs/wiki/02-サイト操作-02-サイト-コピー.md">Wiki: 02-サイト操作-02-サイト-コピー</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>サイトパッケージコピーレスポンス</returns>
    public async Task<ApiResponse<CopySitePackageResponse>> CopySitePackageAsync(
        long siteId,
        CopySitePackageRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.SelectedSites is null)
        {
            throw new ArgumentException("SelectedSites is required", nameof(request));
        }
        SetApiCredentials(request);
        return await SendRequestAsync<CopySitePackageResponse>(
            $"/api/items/{siteId}/copysitepackage", request, timeout, cancellationToken);
    }

    #endregion

    #region Delete Site

    /// <summary>
    /// サイトを削除します
    /// </summary>
    /// <seealso href="../docs/wiki/02-サイト操作-06-サイト-削除.md">Wiki: 02-サイト操作-06-サイト-削除</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>サイト削除レスポンス</returns>
    public async Task<ApiResponse<DeleteSiteResponse>> DeleteSiteAsync(
        long siteId,
        DeleteSiteRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteSiteResponse>(
            $"/api/items/{siteId}/deletesite", request, timeout, cancellationToken);
    }

    #endregion

    #region Synchronize Summaries

    /// <summary>
    /// サマリを同期します
    /// </summary>
    /// <seealso href="../docs/wiki/02-サイト操作-07-集計-同期.md">Wiki: 02-サイト操作-07-集計-同期</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>サマリ同期レスポンス</returns>
    public async Task<ApiResponse<SynchronizeSummariesResponse>> SynchronizeSummariesAsync(
        long siteId,
        SynchronizeSummariesRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<SynchronizeSummariesResponse>(
            $"/api/items/{siteId}/synchronizesummaries", request, timeout, cancellationToken);
    }

    #endregion

    #region Update Site Settings

    /// <summary>
    /// サイト設定を更新します（部分追加/更新/削除）
    /// </summary>
    /// <seealso href="../docs/wiki/02-サイト操作-08-サイト設定-更新.md">Wiki: 02-サイト操作-08-サイト設定-更新</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>サイト設定更新レスポンス</returns>
    public async Task<ApiResponse<UpdateSiteSettingsResponse>> UpdateSiteSettingsAsync(
        long siteId,
        UpdateSiteSettingsRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateSiteSettingsResponse>(
            $"/api/items/{siteId}/updatesitesettings", request, timeout, cancellationToken);
    }

    #endregion
}
