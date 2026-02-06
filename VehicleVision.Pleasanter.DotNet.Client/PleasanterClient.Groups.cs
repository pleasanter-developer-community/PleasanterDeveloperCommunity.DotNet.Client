using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Groups;
using VehicleVision.Pleasanter.DotNet.Client.Models.Responses;
using VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Groups;

namespace VehicleVision.Pleasanter.DotNet.Client;
/// <summary>
/// PleasanterClient のグループ操作に関する機能を提供する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region GetGroups (グループ取得)

    /// <summary>
    /// グループ一覧を取得します
    /// </summary>
    /// <seealso href="../docs/wiki/04-グループ操作-01-グループ-取得.md">Wiki: 04-グループ操作-01-グループ-取得</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ取得レスポンス</returns>
    public async Task<ApiResponse<GetGroupsResponse>> GetGroupsAsync(
        GetGroupsRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<GetGroupsResponse>(
            "/api/groups/get", request, timeout, cancellationToken);
    }

    #endregion

    #region CreateGroup (グループ作成)

    /// <summary>
    /// グループを作成します
    /// </summary>
    /// <seealso href="../docs/wiki/04-グループ操作-02-グループ-作成.md">Wiki: 04-グループ操作-02-グループ-作成</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>グループ作成レスポンス</returns>
    public async Task<ApiResponse<CreateGroupResponse>> CreateGroupAsync(
        CreateGroupRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<CreateGroupResponse>(
            "/api/groups/create", request, timeout, cancellationToken);
    }

    #endregion

    #region UpdateGroup (グループ更新)

    /// <summary>
    /// グループを更新します
    /// </summary>
    /// <seealso href="../docs/wiki/04-グループ操作-03-グループ-更新.md">Wiki: 04-グループ操作-03-グループ-更新</seealso>
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
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateGroupResponse>(
            $"/api/groups/{groupId}/update", request, timeout, cancellationToken);
    }

    #endregion

    #region DeleteGroup (グループ削除)

    /// <summary>
    /// グループを削除します
    /// </summary>
    /// <seealso href="../docs/wiki/04-グループ操作-04-グループ-削除.md">Wiki: 04-グループ操作-04-グループ-削除</seealso>
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
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteGroupResponse>(
            $"/api/groups/{groupId}/delete", request, timeout, cancellationToken);
    }

    #endregion

    #region ImportGroups (グループインポート)

    /// <summary>
    /// CSVデータからグループをインポートします（byte[]版）
    /// </summary>
    /// <seealso href="../docs/wiki/04-グループ操作-05-グループ-インポート.md">Wiki: 04-グループ操作-05-グループ-インポート</seealso>
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
    /// <seealso href="../docs/wiki/04-グループ操作-05-グループ-インポート.md">Wiki: 04-グループ操作-05-グループ-インポート</seealso>
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
    /// <seealso href="../docs/wiki/04-グループ操作-05-グループ-インポート.md">Wiki: 04-グループ操作-05-グループ-インポート</seealso>
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
