using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient - インポート/エクスポートAPI
    /// </summary>
    public partial class PleasanterClient
    {
        /// <summary>
        /// CSVデータをインポートします（byte[]版）
        /// </summary>
        public async Task<ApiResponse<ImportResponse>> ImportAsync(
            long siteId,
            byte[] csvData,
            string fileName,
            Encoding? encoding = null,
            string? key = null,
            bool? migrationMode = null,
            TimeSpan? timeout = null)
        {
            using var stream = new MemoryStream(csvData);
            return await ImportAsync(siteId, stream, fileName, encoding, key, migrationMode, timeout);
        }

        /// <summary>
        /// CSVデータをインポートします（Stream版）
        /// </summary>
        public async Task<ApiResponse<ImportResponse>> ImportAsync(
            long siteId,
            Stream csvStream,
            string fileName,
            Encoding? encoding = null,
            string? key = null,
            bool? migrationMode = null,
            TimeSpan? timeout = null)
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
                $"/api/items/{siteId}/import", csvStream, fileName, parameters, timeout);
        }

        /// <summary>
        /// ファイルパスを指定してCSVデータをインポートします
        /// </summary>
        public async Task<ApiResponse<ImportResponse>> ImportFromFileAsync(
            long siteId,
            string filePath,
            Encoding? encoding = null,
            string? key = null,
            bool? migrationMode = null,
            bool autoConvertToUtf8 = false,
            TimeSpan? timeout = null)
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

            return await ImportAsync(siteId, csvData, fileName, detectedEncoding, key, migrationMode, timeout);
        }

        /// <summary>
        /// テーブルをエクスポートします
        /// </summary>
        public async Task<ApiResponse<ExportResponse>> ExportAsync(
            long siteId,
            int? exportId = null,
            ExportSetting? export = null,
            View? view = null,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey
            };

            if (exportId.HasValue)
                request["ExportId"] = exportId.Value;

            if (export != null)
                request["Export"] = export;

            if (view != null)
                request["View"] = view;

            return await SendRequestAsync<ExportResponse>(
                $"/api/items/{siteId}/export", request, timeout);
        }
    }
}
