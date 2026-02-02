using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Users;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient のユーザ操作に関する機能を提供する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region GetUsers (ユーザ取得)

    /// <summary>
    /// ユーザ一覧を取得します
    /// </summary>
    /// <seealso href="../docs/wiki/03-ユーザ操作-01-ユーザ-取得.md">Wiki: 03-ユーザ操作-01-ユーザ-取得</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>ユーザ取得レスポンス</returns>
    public async Task<ApiResponse<GetUsersResponse>> GetUsersAsync(
        GetUsersRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<GetUsersResponse>(
            "/api/users/get", request, timeout, cancellationToken);
    }

    #endregion

    #region CreateUser (ユーザ作成)

    /// <summary>
    /// ユーザを作成します
    /// </summary>
    /// <seealso href="../docs/wiki/03-ユーザ操作-02-ユーザ-作成.md">Wiki: 03-ユーザ操作-02-ユーザ-作成</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>ユーザ作成レスポンス</returns>
    public async Task<ApiResponse<CreateUserResponse>> CreateUserAsync(
        CreateUserRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<CreateUserResponse>(
            "/api/users/create", request, timeout, cancellationToken);
    }

    #endregion

    #region UpdateUser (ユーザ更新)

    /// <summary>
    /// ユーザを更新します
    /// </summary>
    /// <seealso href="../docs/wiki/03-ユーザ操作-03-ユーザ-更新.md">Wiki: 03-ユーザ操作-03-ユーザ-更新</seealso>
    /// <param name="userId">ユーザID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>ユーザ更新レスポンス</returns>
    public async Task<ApiResponse<UpdateUserResponse>> UpdateUserAsync(
        long userId,
        UpdateUserRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateUserResponse>(
            $"/api/users/{userId}/update", request, timeout, cancellationToken);
    }

    #endregion

    #region DeleteUser (ユーザ削除)

    /// <summary>
    /// ユーザを削除します
    /// </summary>
    /// <seealso href="../docs/wiki/03-ユーザ操作-04-ユーザ-削除.md">Wiki: 03-ユーザ操作-04-ユーザ-削除</seealso>
    /// <param name="userId">ユーザID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>ユーザ削除レスポンス</returns>
    public async Task<ApiResponse<DeleteUserResponse>> DeleteUserAsync(
        long userId,
        DeleteUserRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteUserResponse>(
            $"/api/users/{userId}/delete", request, timeout, cancellationToken);
    }

    #endregion

    #region ImportUsers (ユーザインポート)

    /// <summary>
    /// CSVデータからユーザをインポートします（byte[]版）
    /// </summary>
    /// <seealso href="../docs/wiki/03-ユーザ操作-05-ユーザ-インポート.md">Wiki: 03-ユーザ操作-05-ユーザ-インポート</seealso>
    /// <param name="csvData">CSVデータ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="encoding">エンコーディング（省略時はUTF-8）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportUsersResponse>> ImportUsersAsync(
        byte[] csvData,
        string fileName,
        Encoding? encoding = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        using var stream = new MemoryStream(csvData);
        return await ImportUsersAsync(stream, fileName, encoding, timeout, cancellationToken);
    }

    /// <summary>
    /// CSVデータからユーザをインポートします（Stream版）
    /// </summary>
    /// <seealso href="../docs/wiki/03-ユーザ操作-05-ユーザ-インポート.md">Wiki: 03-ユーザ操作-05-ユーザ-インポート</seealso>
    /// <param name="csvStream">CSVストリーム</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="encoding">エンコーディング（省略時はUTF-8）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportUsersResponse>> ImportUsersAsync(
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

        return await SendMultipartRequestAsync<ImportUsersResponse>(
            "/api/users/import", csvStream, fileName, parameters, timeout, cancellationToken);
    }

    /// <summary>
    /// ファイルパスを指定してユーザをインポートします
    /// </summary>
    /// <seealso href="../docs/wiki/03-ユーザ操作-05-ユーザ-インポート.md">Wiki: 03-ユーザ操作-05-ユーザ-インポート</seealso>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="encoding">エンコーディング（省略時は自動検出）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportUsersResponse>> ImportUsersFromFileAsync(
        string filePath,
        Encoding? encoding = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var detectedEncoding = encoding ?? DetectFileEncoding(filePath);
        var fileName = Path.GetFileName(filePath);
        var csvData = File.ReadAllBytes(filePath);

        return await ImportUsersAsync(csvData, fileName, detectedEncoding, timeout, cancellationToken);
    }

    #endregion
}
