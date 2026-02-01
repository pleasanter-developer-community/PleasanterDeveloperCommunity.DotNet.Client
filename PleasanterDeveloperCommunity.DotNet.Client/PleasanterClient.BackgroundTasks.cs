using System;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.BackgroundTasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.BackgroundTasks;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient - バックグラウンドタスクAPI
/// </summary>
public partial class PleasanterClient
{
    #region RebuildSearchIndexes (検索インデックス再構築)

    /// <summary>
    /// 全サイトの検索インデックスを再構築します（リクエストモデル版）
    /// </summary>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>検索インデックス再構築レスポンス</returns>
    /// <remarks>
    /// この機能には BackgroundTask.Enabled パラメータの有効化が必要です。
    /// </remarks>
    public async Task<ApiResponse<RebuildSearchIndexesResponse>> RebuildAllSearchIndexesAsync(
        RebuildSearchIndexesRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<RebuildSearchIndexesResponse>(
            "/api/backgroundtasks/rebuildsearchindexes", request, timeout);
    }

    /// <summary>
    /// 全サイトの検索インデックスを再構築します
    /// </summary>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>検索インデックス再構築レスポンス</returns>
    /// <remarks>
    /// この機能には BackgroundTask.Enabled パラメータの有効化が必要です。
    /// </remarks>
    public async Task<ApiResponse<RebuildSearchIndexesResponse>> RebuildAllSearchIndexesAsync(
        TimeSpan? timeout = null)
    {
        var request = new RebuildSearchIndexesRequest();
        return await RebuildAllSearchIndexesAsync(request, timeout);
    }

    /// <summary>
    /// 特定サイトの検索インデックスを再構築します（リクエストモデル版）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>検索インデックス再構築レスポンス</returns>
    /// <remarks>
    /// この機能には BackgroundTask.Enabled パラメータの有効化が必要です。
    /// </remarks>
    public async Task<ApiResponse<RebuildSearchIndexesResponse>> RebuildSearchIndexesAsync(
        long siteId,
        RebuildSearchIndexesRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<RebuildSearchIndexesResponse>(
            $"/api/backgroundtasks/{siteId}/rebuildsearchindexes", request, timeout);
    }

    /// <summary>
    /// 特定サイトの検索インデックスを再構築します
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>検索インデックス再構築レスポンス</returns>
    /// <remarks>
    /// この機能には BackgroundTask.Enabled パラメータの有効化が必要です。
    /// </remarks>
    public async Task<ApiResponse<RebuildSearchIndexesResponse>> RebuildSearchIndexesAsync(
        long siteId,
        TimeSpan? timeout = null)
    {
        var request = new RebuildSearchIndexesRequest();
        return await RebuildSearchIndexesAsync(siteId, request, timeout);
    }

    #endregion
}