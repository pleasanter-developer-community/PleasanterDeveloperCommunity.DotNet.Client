using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Sessions;
using VehicleVision.Pleasanter.DotNet.Client.Models.Responses;
using VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Sessions;

namespace VehicleVision.Pleasanter.DotNet.Client;
/// <summary>
/// PleasanterClient のセッション操作に関する機能を提供する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region GetSession (セッション取得)

    /// <summary>
    /// セッションを取得します
    /// </summary>
    /// <seealso href="../docs/wiki/06-セッション操作-01-セッション-取得.md">Wiki: 06-セッション操作-01-セッション-取得</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>セッション取得レスポンス</returns>
    public async Task<ApiResponse<GetSessionResponse>> GetSessionAsync(
        GetSessionRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<GetSessionResponse>(
            "/api/sessions/get", request, timeout, cancellationToken);
    }

    #endregion

    #region SetSession (セッション設定)

    /// <summary>
    /// セッションを設定します
    /// </summary>
    /// <seealso href="../docs/wiki/06-セッション操作-02-セッション-設定.md">Wiki: 06-セッション操作-02-セッション-設定</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>セッション設定レスポンス</returns>
    public async Task<ApiResponse<SetSessionResponse>> SetSessionAsync(
        SetSessionRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<SetSessionResponse>(
            "/api/sessions/set", request, timeout, cancellationToken);
    }

    #endregion

    #region DeleteSession (セッション削除)

    /// <summary>
    /// セッションを削除します
    /// </summary>
    /// <seealso href="../docs/wiki/06-セッション操作-03-セッション-削除.md">Wiki: 06-セッション操作-03-セッション-削除</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>セッション削除レスポンス</returns>
    public async Task<ApiResponse<DeleteSessionResponse>> DeleteSessionAsync(
        DeleteSessionRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteSessionResponse>(
            "/api/sessions/delete", request, timeout, cancellationToken);
    }

    #endregion
}
