using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleVision.Pleasanter.DotNet.Client.Models.Requests.BackgroundTasks;
using VehicleVision.Pleasanter.DotNet.Client.Models.Responses;
using VehicleVision.Pleasanter.DotNet.Client.Models.Responses.BackgroundTasks;

namespace VehicleVision.Pleasanter.DotNet.Client;
/// <summary>
/// PleasanterClient - バックグラウンドタスクAPI
/// </summary>
public partial class PleasanterClient
{
    #region RebuildSearchIndexes (検索インデックス再構築)

    /// <summary>
    /// 検索インデックスを再構築します
    /// </summary>
    /// <seealso href="../docs/wiki/12-バックグラウンドタスク-01-検索インデックス-再構築.md">Wiki: 12-バックグラウンドタスク-01-検索インデックス-再構築</seealso>
    /// <param name="siteId">サイトID（nullの場合は全サイトが対象）</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検索インデックス再構築レスポンス</returns>
    /// <remarks>
    /// この機能には BackgroundTask.Enabled パラメータの有効化が必要です。
    /// </remarks>
    public async Task<ApiResponse<RebuildSearchIndexesResponse>> RebuildSearchIndexesAsync(
        long? siteId,
        RebuildSearchIndexesRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        var endpoint = siteId.HasValue
            ? $"/api/backgroundtasks/{siteId.Value}/rebuildsearchindexes"
            : "/api/backgroundtasks/rebuildsearchindexes";
        return await SendRequestAsync<RebuildSearchIndexesResponse>(
            endpoint, request, timeout, cancellationToken);
    }

    #endregion
}
