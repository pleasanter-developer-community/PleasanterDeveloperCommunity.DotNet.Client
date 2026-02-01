using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient - インポート/エクスポートAPI
/// </summary>
public partial class PleasanterClient
{
    #region Import

    /// <summary>
    /// CSVデータをインポートします（byte[]版）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="csvData">CSVデータ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="key">キー</param>
    /// <param name="migrationMode">マイグレーションモード</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    public async Task<ApiResponse<ImportResponse>> ImportAsync(
        long siteId,
        byte[] csvData,
        string fileName,
        Encoding? encoding = null,
        string? key = null,
        bool? migrationMode = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        using var stream = new MemoryStream(csvData);
        return await ImportAsync(siteId, stream, fileName, encoding, key, migrationMode, timeout, cancellationToken);
    }

    /// <summary>
    /// CSVデータをインポートします（Stream版）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="csvStream">CSVストリーム</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="key">キー</param>
    /// <param name="migrationMode">マイグレーションモード</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    public async Task<ApiResponse<ImportResponse>> ImportAsync(
        long siteId,
        Stream csvStream,
        string fileName,
        Encoding? encoding = null,
        string? key = null,
        bool? migrationMode = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var enc = encoding ?? Encoding.UTF8;
        var encodingName = enc.WebName == "utf-8" ? "utf-8" : "shift-jis";

        var parameters = new Dictionary<string, object>
        {
            ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
            ["ApiKey"] = _apiKey,
            ["Encoding"] = encodingName,
            ["UpdatableImport"] = !string.IsNullOrEmpty(key)
        };

        if (!string.IsNullOrEmpty(key))
            parameters["Key"] = key;

        if (migrationMode.HasValue)
            parameters["MigrationMode"] = migrationMode.Value;

        return await SendMultipartRequestAsync<ImportResponse>(
            $"/api/items/{siteId}/import", csvStream, fileName, parameters, timeout, cancellationToken);
    }

    /// <summary>
    /// ファイルパスを指定してCSVデータをインポートします
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="key">キー</param>
    /// <param name="migrationMode">マイグレーションモード</param>
    /// <param name="autoConvertToUtf8">UTF-8へ自動変換</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>インポートレスポンス</returns>
    public async Task<ApiResponse<ImportResponse>> ImportFromFileAsync(
        long siteId,
        string filePath,
        Encoding? encoding = null,
        string? key = null,
        bool? migrationMode = null,
        bool autoConvertToUtf8 = false,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var detectedEncoding = encoding ?? DetectFileEncoding(filePath);
        var fileName = Path.GetFileName(filePath);

        byte[] csvData;
        if (autoConvertToUtf8 && detectedEncoding.WebName != "utf-8" && detectedEncoding.WebName != "shift_jis")
        {
            var content = File.ReadAllText(filePath, detectedEncoding);
            csvData = Encoding.UTF8.GetBytes(content);
            detectedEncoding = Encoding.UTF8;
        }
        else
        {
            csvData = File.ReadAllBytes(filePath);
        }

        return await ImportAsync(siteId, csvData, fileName, detectedEncoding, key, migrationMode, timeout, cancellationToken);
    }

    #endregion

    #region Export

    /// <summary>
    /// テーブルをエクスポートします（リクエストモデル版）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>エクスポートレスポンス</returns>
    public async Task<ApiResponse<ExportResponse>> ExportAsync(
        long siteId,
        ExportRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<ExportResponse>(
            $"/api/items/{siteId}/export", request, timeout, cancellationToken);
    }

    /// <summary>
    /// テーブルをエクスポートします
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="exportId">エクスポートID</param>
    /// <param name="export">エクスポート設定</param>
    /// <param name="view">ビュー</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>エクスポートレスポンス</returns>
    public async Task<ApiResponse<ExportResponse>> ExportAsync(
        long siteId,
        int? exportId = null,
        ExportSetting? export = null,
        View? view = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new ExportRequest
        {
            ExportId = exportId,
            Export = export,
            View = view
        };
        return await ExportAsync(siteId, request, timeout, cancellationToken);
    }

    #endregion
}