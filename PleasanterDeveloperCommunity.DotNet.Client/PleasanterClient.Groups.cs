using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Groups;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient のグループ操作に関する機能を提供する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region GetGroups (グループ取得)

    /// <summary>
    /// グループ一覧を取得します（リクエストモデル版）
    /// </summary>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ取得レスポンス</returns>
    public async Task<ApiResponse<GetGroupsResponse>> GetGroupsAsync(
        GetGroupsRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<GetGroupsResponse>(
            "/api/groups/get", request, timeout, cancellationToken);
    }

    /// <summary>
    /// グループ一覧を取得します
    /// </summary>
    /// <param name="offset">取得開始位置</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ取得レスポンス</returns>
    public async Task<ApiResponse<GetGroupsResponse>> GetGroupsAsync(
        int? offset = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new GetGroupsRequest
        {
            Offset = offset
        };
        return await GetGroupsAsync(request, timeout, cancellationToken);
    }

    #endregion

    #region CreateGroup (グループ作成)

    /// <summary>
    /// グループを作成します（リクエストモデル版）
    /// </summary>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ作成レスポンス</returns>
    public async Task<ApiResponse<CreateGroupResponse>> CreateGroupAsync(
        CreateGroupRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<CreateGroupResponse>(
            "/api/groups/create", request, timeout, cancellationToken);
    }

    /// <summary>
    /// グループを作成します
    /// </summary>
    /// <param name="groupName">グループ名</param>
    /// <param name="body">内容</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ作成レスポンス</returns>
    public async Task<ApiResponse<CreateGroupResponse>> CreateGroupAsync(
        string groupName,
        string? body = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new CreateGroupRequest
        {
            GroupName = groupName ?? throw new ArgumentNullException(nameof(groupName)),
            Body = body
        };
        return await CreateGroupAsync(request, timeout, cancellationToken);
    }

    #endregion

    #region UpdateGroup (グループ更新)

    /// <summary>
    /// グループを更新します（リクエストモデル版）
    /// </summary>
    /// <param name="groupId">グループID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ更新レスポンス</returns>
    public async Task<ApiResponse<UpdateGroupResponse>> UpdateGroupAsync(
        long groupId,
        UpdateGroupRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateGroupResponse>(
            $"/api/groups/{groupId}/update", request, timeout, cancellationToken);
    }

    /// <summary>
    /// グループを更新します
    /// </summary>
    /// <param name="groupId">グループID</param>
    /// <param name="groupName">グループ名</param>
    /// <param name="body">内容</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ更新レスポンス</returns>
    public async Task<ApiResponse<UpdateGroupResponse>> UpdateGroupAsync(
        long groupId,
        string? groupName = null,
        string? body = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new UpdateGroupRequest
        {
            GroupName = groupName,
            Body = body
        };
        return await UpdateGroupAsync(groupId, request, timeout, cancellationToken);
    }

    #endregion

    #region DeleteGroup (グループ削除)

    /// <summary>
    /// グループを削除します（リクエストモデル版）
    /// </summary>
    /// <param name="groupId">グループID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ削除レスポンス</returns>
    public async Task<ApiResponse<DeleteGroupResponse>> DeleteGroupAsync(
        long groupId,
        DeleteGroupRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteGroupResponse>(
            $"/api/groups/{groupId}/delete", request, timeout, cancellationToken);
    }

    /// <summary>
    /// グループを削除します
    /// </summary>
    /// <param name="groupId">グループID</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ削除レスポンス</returns>
    public async Task<ApiResponse<DeleteGroupResponse>> DeleteGroupAsync(
        long groupId,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteGroupRequest();
        return await DeleteGroupAsync(groupId, request, timeout, cancellationToken);
    }

    #endregion

    #region ImportGroups (グループインポート)

    /// <summary>
    /// CSVデータからグループをインポートします（byte[]版）
    /// </summary>
    /// <param name="csvData">CSVデータ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="encoding">エンコーディング（省略時はUTF-8）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportGroupsResponse>> ImportGroupsAsync(
        byte[] csvData,
        string fileName,
        Encoding? encoding = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        using var stream = new MemoryStream(csvData);
        return await ImportGroupsAsync(stream, fileName, encoding, timeout, cancellationToken);
    }

    /// <summary>
    /// CSVデータからグループをインポートします（Stream版）
    /// </summary>
    /// <param name="csvStream">CSVストリーム</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="encoding">エンコーディング（省略時はUTF-8）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportGroupsResponse>> ImportGroupsAsync(
        Stream csvStream,
        string fileName,
        Encoding? encoding = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var enc = encoding ?? Encoding.UTF8;
        var encodingName = enc.WebName == "utf-8" ? "utf-8" : "shift-jis";

        var parameters = new Dictionary<string, object>
        {
            ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
            ["ApiKey"] = _apiKey,
            ["Encoding"] = encodingName
        };

        return await SendMultipartRequestAsync<ImportGroupsResponse>(
            "/api/groups/import", csvStream, fileName, parameters, timeout, cancellationToken);
    }

    /// <summary>
    /// ファイルパスを指定してグループをインポートします
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="encoding">エンコーディング（省略時は自動検出）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportGroupsResponse>> ImportGroupsFromFileAsync(
        string filePath,
        Encoding? encoding = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var detectedEncoding = encoding ?? DetectFileEncoding(filePath);
        var fileName = Path.GetFileName(filePath);
        var csvData = File.ReadAllBytes(filePath);

        return await ImportGroupsAsync(csvData, fileName, detectedEncoding, timeout, cancellationToken);
    }

    #endregion
}