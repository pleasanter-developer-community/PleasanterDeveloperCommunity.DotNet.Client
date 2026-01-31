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
    }
}
