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
    /// 拡張機能一覧を取得します（リクエストモデル版）
    /// </summary>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能取得レスポンス</returns>
    public async Task<ApiResponse<GetExtensionsResponse>> GetExtensionsAsync(
        GetExtensionsRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<GetExtensionsResponse>(
            "/api/extensions/get", request, timeout, cancellationToken);
    }

    /// <summary>
    /// 拡張機能一覧を取得します
    /// </summary>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能取得レスポンス</returns>
    public async Task<ApiResponse<GetExtensionsResponse>> GetExtensionsAsync(
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new GetExtensionsRequest();
        return await GetExtensionsAsync(request, timeout, cancellationToken);
    }

    #endregion

    #region CreateExtension (拡張機能作成)

    /// <summary>
    /// 拡張機能を作成します（リクエストモデル版）
    /// </summary>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能作成レスポンス</returns>
    public async Task<ApiResponse<CreateExtensionResponse>> CreateExtensionAsync(
        CreateExtensionRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<CreateExtensionResponse>(
            "/api/extensions/create", request, timeout, cancellationToken);
    }

    /// <summary>
    /// 拡張機能を作成します
    /// </summary>
    /// <param name="extensionType">種類</param>
    /// <param name="extensionName">拡張機能名</param>
    /// <param name="extensionSettings">設定</param>
    /// <param name="extensionDescription">説明</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能作成レスポンス</returns>
    public async Task<ApiResponse<CreateExtensionResponse>> CreateExtensionAsync(
        string extensionType,
        string extensionName,
        string extensionSettings,
        string? extensionDescription = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new CreateExtensionRequest
        {
            ExtensionType = extensionType ?? throw new ArgumentNullException(nameof(extensionType)),
            ExtensionName = extensionName ?? throw new ArgumentNullException(nameof(extensionName)),
            ExtensionSettings = extensionSettings ?? throw new ArgumentNullException(nameof(extensionSettings)),
            ExtensionDescription = extensionDescription
        };
        return await CreateExtensionAsync(request, timeout, cancellationToken);
    }

    #endregion

    #region UpdateExtension (拡張機能更新)

    /// <summary>
    /// 拡張機能を更新します（リクエストモデル版）
    /// </summary>
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
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateExtensionResponse>(
            $"/api/extensions/{extensionId}/update", request, timeout, cancellationToken);
    }

    /// <summary>
    /// 拡張機能を更新します
    /// </summary>
    /// <param name="extensionId">拡張機能ID</param>
    /// <param name="extensionName">拡張機能名</param>
    /// <param name="extensionSettings">設定</param>
    /// <param name="extensionDescription">説明</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能更新レスポンス</returns>
    public async Task<ApiResponse<UpdateExtensionResponse>> UpdateExtensionAsync(
        long extensionId,
        string? extensionName = null,
        string? extensionSettings = null,
        string? extensionDescription = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new UpdateExtensionRequest
        {
            ExtensionName = extensionName,
            ExtensionSettings = extensionSettings,
            ExtensionDescription = extensionDescription
        };
        return await UpdateExtensionAsync(extensionId, request, timeout, cancellationToken);
    }

    #endregion

    #region DeleteExtension (拡張機能削除)

    /// <summary>
    /// 拡張機能を削除します（リクエストモデル版）
    /// </summary>
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
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteExtensionResponse>(
            $"/api/extensions/{extensionId}/delete", request, timeout, cancellationToken);
    }

    /// <summary>
    /// 拡張機能を削除します
    /// </summary>
    /// <param name="extensionId">拡張機能ID</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張機能削除レスポンス</returns>
    public async Task<ApiResponse<DeleteExtensionResponse>> DeleteExtensionAsync(
        long extensionId,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteExtensionRequest();
        return await DeleteExtensionAsync(extensionId, request, timeout, cancellationToken);
    }

    #endregion
}
