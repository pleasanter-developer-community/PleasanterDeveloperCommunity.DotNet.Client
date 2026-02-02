using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Depts;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient の組織操作に関する機能を提供する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region GetDepts (組織取得)

    /// <summary>
    /// 組織一覧を取得します
    /// </summary>
    /// <seealso href="../docs/wiki/05-組織操作-01-組織-取得.md">Wiki: 05-組織操作-01-組織-取得</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>組織取得レスポンス</returns>
    public async Task<ApiResponse<GetDeptsResponse>> GetDeptsAsync(
        GetDeptsRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<GetDeptsResponse>(
            "/api/depts/get", request, timeout, cancellationToken);
    }

    #endregion

    #region CreateDept (組織作成)

    /// <summary>
    /// 組織を作成します
    /// </summary>
    /// <seealso href="../docs/wiki/05-組織操作-02-組織-作成.md">Wiki: 05-組織操作-02-組織-作成</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>組織作成レスポンス</returns>
    public async Task<ApiResponse<CreateDeptResponse>> CreateDeptAsync(
        CreateDeptRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<CreateDeptResponse>(
            "/api/depts/create", request, timeout, cancellationToken);
    }

    #endregion

    #region UpdateDept (組織更新)

    /// <summary>
    /// 組織を更新します
    /// </summary>
    /// <seealso href="../docs/wiki/05-組織操作-03-組織-更新.md">Wiki: 05-組織操作-03-組織-更新</seealso>
    /// <param name="deptId">組織ID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>組織更新レスポンス</returns>
    public async Task<ApiResponse<UpdateDeptResponse>> UpdateDeptAsync(
        long deptId,
        UpdateDeptRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateDeptResponse>(
            $"/api/depts/{deptId}/update", request, timeout, cancellationToken);
    }

    #endregion

    #region DeleteDept (組織削除)

    /// <summary>
    /// 組織を削除します
    /// </summary>
    /// <seealso href="../docs/wiki/05-組織操作-04-組織-削除.md">Wiki: 05-組織操作-04-組織-削除</seealso>
    /// <param name="deptId">組織ID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>組織削除レスポンス</returns>
    public async Task<ApiResponse<DeleteDeptResponse>> DeleteDeptAsync(
        long deptId,
        DeleteDeptRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteDeptResponse>(
            $"/api/depts/{deptId}/delete", request, timeout, cancellationToken);
    }

    #endregion

    #region ImportDepts (組織インポート)

    /// <summary>
    /// CSVデータから組織をインポートします（byte[]版）
    /// </summary>
    /// <seealso href="../docs/wiki/05-組織操作-05-組織-インポート.md">Wiki: 05-組織操作-05-組織-インポート</seealso>
    /// <param name="csvData">CSVデータ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="encoding">エンコーディング（省略時はUTF-8）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportDeptsResponse>> ImportDeptsAsync(
        byte[] csvData,
        string fileName,
        Encoding? encoding = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        using var stream = new MemoryStream(csvData);
        return await ImportDeptsAsync(stream, fileName, encoding, timeout, cancellationToken);
    }

    /// <summary>
    /// CSVデータから組織をインポートします（Stream版）
    /// </summary>
    /// <seealso href="../docs/wiki/05-組織操作-05-組織-インポート.md">Wiki: 05-組織操作-05-組織-インポート</seealso>
    /// <param name="csvStream">CSVストリーム</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="encoding">エンコーディング（省略時はUTF-8）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportDeptsResponse>> ImportDeptsAsync(
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

        return await SendMultipartRequestAsync<ImportDeptsResponse>(
            "/api/depts/import", csvStream, fileName, parameters, timeout, cancellationToken);
    }

    /// <summary>
    /// ファイルパスを指定して組織をインポートします
    /// </summary>
    /// <seealso href="../docs/wiki/05-組織操作-05-組織-インポート.md">Wiki: 05-組織操作-05-組織-インポート</seealso>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="encoding">エンコーディング（省略時は自動検出）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    /// <remarks>
    /// テナント管理者権限が必要です。
    /// </remarks>
    public async Task<ApiResponse<ImportDeptsResponse>> ImportDeptsFromFileAsync(
        string filePath,
        Encoding? encoding = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var detectedEncoding = encoding ?? DetectFileEncoding(filePath);
        var fileName = Path.GetFileName(filePath);
        var csvData = File.ReadAllBytes(filePath);

        return await ImportDeptsAsync(csvData, fileName, detectedEncoding, timeout, cancellationToken);
    }

    #endregion
}
