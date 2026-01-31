using System;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Binaries;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient - 添付ファイルAPI
    /// </summary>
    public partial class PleasanterClient
    {
        #region GetAttachment (添付ファイル取得)

        /// <summary>
        /// 添付ファイルを取得します（リクエストモデル版）
        /// </summary>
        public async Task<ApiResponse<AttachmentResponse>> GetAttachmentAsync(
            string guid,
            GetAttachmentRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<AttachmentResponse>(
                $"/api/binaries/{guid}/get", request, timeout);
        }

        /// <summary>
        /// 添付ファイルを取得します
        /// </summary>
        public async Task<ApiResponse<AttachmentResponse>> GetAttachmentAsync(
            string guid,
            TimeSpan? timeout = null)
        {
            var request = new GetAttachmentRequest();
            return await GetAttachmentAsync(guid, request, timeout);
        }

        #endregion

        #region GetBinaryStream (バイナリストリーム取得)

        /// <summary>
        /// バイナリストリームを取得します（リクエストモデル版）
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>バイナリストリーム取得レスポンス</returns>
        public async Task<ApiResponse<GetBinaryStreamResponse>> GetBinaryStreamAsync(
            string guid,
            GetBinaryStreamRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<GetBinaryStreamResponse>(
                $"/api/binaries/{guid}/getstream", request, timeout);
        }

        /// <summary>
        /// バイナリストリームを取得します
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>バイナリストリーム取得レスポンス</returns>
        public async Task<ApiResponse<GetBinaryStreamResponse>> GetBinaryStreamAsync(
            string guid,
            TimeSpan? timeout = null)
        {
            var request = new GetBinaryStreamRequest();
            return await GetBinaryStreamAsync(guid, request, timeout);
        }

        #endregion

        #region UploadBinary (バイナリアップロード)

        /// <summary>
        /// バイナリをアップロードします（リクエストモデル版）
        /// </summary>
        /// <param name="siteId">サイトID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>バイナリアップロードレスポンス</returns>
        public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryAsync(
            long siteId,
            UploadBinaryRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<UploadBinaryResponse>(
                $"/api/binaries/{siteId}/upload", request, timeout);
        }

        /// <summary>
        /// バイナリをアップロードします
        /// </summary>
        /// <param name="siteId">サイトID</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="base64Data">Base64エンコードされたファイルデータ</param>
        /// <param name="contentType">コンテンツタイプ</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>バイナリアップロードレスポンス</returns>
        public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryAsync(
            long siteId,
            string fileName,
            string base64Data,
            string? contentType = null,
            TimeSpan? timeout = null)
        {
            var request = new UploadBinaryRequest
            {
                FileName = fileName ?? throw new ArgumentNullException(nameof(fileName)),
                Base64 = base64Data ?? throw new ArgumentNullException(nameof(base64Data)),
                ContentType = contentType
            };
            return await UploadBinaryAsync(siteId, request, timeout);
        }

        /// <summary>
        /// バイナリをアップロードします（バイト配列版）
        /// </summary>
        /// <param name="siteId">サイトID</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="fileData">ファイルデータ</param>
        /// <param name="contentType">コンテンツタイプ</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>バイナリアップロードレスポンス</returns>
        public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryAsync(
            long siteId,
            string fileName,
            byte[] fileData,
            string? contentType = null,
            TimeSpan? timeout = null)
        {
            if (fileData == null) throw new ArgumentNullException(nameof(fileData));
            var base64Data = Convert.ToBase64String(fileData);
            return await UploadBinaryAsync(siteId, fileName, base64Data, contentType, timeout);
        }

        #endregion
    }
}
