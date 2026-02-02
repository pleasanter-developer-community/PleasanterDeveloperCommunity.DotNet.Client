using System;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Extensions;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Extensions;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient の拡張機能操作に関する機能を提供する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region GetExtensions (拡張機能取得)

    /// <summary>
    /// 拡張機能一覧を取得します
    /// </summary>
    /// <seealso href="../docs/wiki/10-拡張機能操作-01-拡張機能-取得.md">Wiki: 10-拡張機能操作-01-拡張機能-取得</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能取得レスポンス</returns>
    public async Task<ApiResponse<GetExtensionsResponse>> GetExtensionsAsync(
        GetExtensionsRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<GetExtensionsResponse>(
            "/api/extensions/get", request, timeout, cancellationToken);
    }

    #endregion

    #region CreateExtension (拡張機能作成)

    /// <summary>
    /// 拡張機能を作成します
    /// </summary>
    /// <seealso href="../docs/wiki/10-拡張機能操作-02-拡張機能-作成.md">Wiki: 10-拡張機能操作-02-拡張機能-作成</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能作成レスポンス</returns>
    public async Task<ApiResponse<CreateExtensionResponse>> CreateExtensionAsync(
        CreateExtensionRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<CreateExtensionResponse>(
            "/api/extensions/create", request, timeout, cancellationToken);
    }

    #endregion

    #region UpdateExtension (拡張機能更新)

    /// <summary>
    /// 拡張機能を更新します
    /// </summary>
    /// <seealso href="../docs/wiki/10-拡張機能操作-03-拡張機能-更新.md">Wiki: 10-拡張機能操作-03-拡張機能-更新</seealso>
    /// <param name="extensionId">拡張機能ID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能更新レスポンス</returns>
    public async Task<ApiResponse<UpdateExtensionResponse>> UpdateExtensionAsync(
        long extensionId,
        UpdateExtensionRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateExtensionResponse>(
            $"/api/extensions/{extensionId}/update", request, timeout, cancellationToken);
    }

    #endregion

    #region DeleteExtension (拡張機能削除)

    /// <summary>
    /// 拡張機能を削除します
    /// </summary>
    /// <seealso href="../docs/wiki/10-拡張機能操作-04-拡張機能-削除.md">Wiki: 10-拡張機能操作-04-拡張機能-削除</seealso>
    /// <param name="extensionId">拡張機能ID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能削除レスポンス</returns>
    public async Task<ApiResponse<DeleteExtensionResponse>> DeleteExtensionAsync(
        long extensionId,
        DeleteExtensionRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteExtensionResponse>(
            $"/api/extensions/{extensionId}/delete", request, timeout, cancellationToken);
    }

    #endregion
}
