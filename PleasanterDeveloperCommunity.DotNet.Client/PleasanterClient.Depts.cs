using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Depts;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient の組織操作に関する機能を提供する部分クラス
    /// </summary>
    public partial class PleasanterClient
    {
        #region GetDepts (組織取得)

        /// <summary>
        /// 組織一覧を取得します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>組織取得レスポンス</returns>
        public async Task<ApiResponse<GetDeptsResponse>> GetDeptsAsync(
            GetDeptsRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<GetDeptsResponse>(
                "/api/depts/get", request, timeout);
        }

        /// <summary>
        /// 組織一覧を取得します
        /// </summary>
        /// <param name="offset">取得開始位置</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>組織取得レスポンス</returns>
        public async Task<ApiResponse<GetDeptsResponse>> GetDeptsAsync(
            int? offset = null,
            TimeSpan? timeout = null)
        {
            var request = new GetDeptsRequest
            {
                Offset = offset
            };
            return await GetDeptsAsync(request, timeout);
        }

        #endregion

        #region CreateDept (組織作成)

        /// <summary>
        /// 組織を作成します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>組織作成レスポンス</returns>
        public async Task<ApiResponse<CreateDeptResponse>> CreateDeptAsync(
            CreateDeptRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<CreateDeptResponse>(
                "/api/depts/create", request, timeout);
        }

        /// <summary>
        /// 組織を作成します
        /// </summary>
        /// <param name="deptCode">組織コード</param>
        /// <param name="deptName">組織名</param>
        /// <param name="body">内容</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>組織作成レスポンス</returns>
        public async Task<ApiResponse<CreateDeptResponse>> CreateDeptAsync(
            string deptCode,
            string deptName,
            string? body = null,
            TimeSpan? timeout = null)
        {
            var request = new CreateDeptRequest
            {
                DeptCode = deptCode ?? throw new ArgumentNullException(nameof(deptCode)),
                DeptName = deptName ?? throw new ArgumentNullException(nameof(deptName)),
                Body = body
            };
            return await CreateDeptAsync(request, timeout);
        }

        #endregion

        #region UpdateDept (組織更新)

        /// <summary>
        /// 組織を更新します（リクエストモデル版）
        /// </summary>
        /// <param name="deptId">組織ID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>組織更新レスポンス</returns>
        public async Task<ApiResponse<UpdateDeptResponse>> UpdateDeptAsync(
            long deptId,
            UpdateDeptRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<UpdateDeptResponse>(
                $"/api/depts/{deptId}/update", request, timeout);
        }

        /// <summary>
        /// 組織を更新します
        /// </summary>
        /// <param name="deptId">組織ID</param>
        /// <param name="deptName">組織名</param>
        /// <param name="body">内容</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>組織更新レスポンス</returns>
        public async Task<ApiResponse<UpdateDeptResponse>> UpdateDeptAsync(
            long deptId,
            string? deptName = null,
            string? body = null,
            TimeSpan? timeout = null)
        {
            var request = new UpdateDeptRequest
            {
                DeptName = deptName,
                Body = body
            };
            return await UpdateDeptAsync(deptId, request, timeout);
        }

        #endregion

        #region DeleteDept (組織削除)

        /// <summary>
        /// 組織を削除します（リクエストモデル版）
        /// </summary>
        /// <param name="deptId">組織ID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>組織削除レスポンス</returns>
        public async Task<ApiResponse<DeleteDeptResponse>> DeleteDeptAsync(
            long deptId,
            DeleteDeptRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<DeleteDeptResponse>(
                $"/api/depts/{deptId}/delete", request, timeout);
        }

        /// <summary>
        /// 組織を削除します
        /// </summary>
        /// <param name="deptId">組織ID</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>組織削除レスポンス</returns>
        public async Task<ApiResponse<DeleteDeptResponse>> DeleteDeptAsync(
            long deptId,
            TimeSpan? timeout = null)
        {
            var request = new DeleteDeptRequest();
            return await DeleteDeptAsync(deptId, request, timeout);
        }

        #endregion

        #region ImportDepts (組織インポート)

        /// <summary>
        /// CSVデータから組織をインポートします（byte[]版）
        /// </summary>
        /// <param name="csvData">CSVデータ</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="encoding">エンコーディング（省略時はUTF-8）</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>インポートレスポンス</returns>
        /// <remarks>
        /// テナント管理者権限が必要です。
        /// </remarks>
        public async Task<ApiResponse<ImportResponse>> ImportDeptsAsync(
            byte[] csvData,
            string fileName,
            Encoding? encoding = null,
            TimeSpan? timeout = null)
        {
            using var stream = new MemoryStream(csvData);
            return await ImportDeptsAsync(stream, fileName, encoding, timeout);
        }

        /// <summary>
        /// CSVデータから組織をインポートします（Stream版）
        /// </summary>
        /// <param name="csvStream">CSVストリーム</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="encoding">エンコーディング（省略時はUTF-8）</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>インポートレスポンス</returns>
        /// <remarks>
        /// テナント管理者権限が必要です。
        /// </remarks>
        public async Task<ApiResponse<ImportResponse>> ImportDeptsAsync(
            Stream csvStream,
            string fileName,
            Encoding? encoding = null,
            TimeSpan? timeout = null)
        {
            var enc = encoding ?? Encoding.UTF8;
            var encodingName = enc.WebName == "utf-8" ? "utf-8" : "shift-jis";

            var parameters = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey,
                ["Encoding"] = encodingName
            };

            return await SendMultipartRequestAsync<ImportResponse>(
                "/api/depts/import", csvStream, fileName, parameters, timeout);
        }

        /// <summary>
        /// ファイルパスを指定して組織をインポートします
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="encoding">エンコーディング（省略時は自動検出）</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>インポートレスポンス</returns>
        /// <remarks>
        /// テナント管理者権限が必要です。
        /// </remarks>
        public async Task<ApiResponse<ImportResponse>> ImportDeptsFromFileAsync(
            string filePath,
            Encoding? encoding = null,
            TimeSpan? timeout = null)
        {
            var detectedEncoding = encoding ?? DetectFileEncoding(filePath);
            var fileName = Path.GetFileName(filePath);
            var csvData = File.ReadAllBytes(filePath);

            return await ImportDeptsAsync(csvData, fileName, detectedEncoding, timeout);
        }

        #endregion
    }
}
