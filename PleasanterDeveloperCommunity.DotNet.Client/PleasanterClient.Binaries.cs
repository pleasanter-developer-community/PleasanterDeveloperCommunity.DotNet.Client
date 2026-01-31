using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient - 添付ファイルAPI
    /// </summary>
    public partial class PleasanterClient
    {
        /// <summary>
        /// 添付ファイルを取得します
        /// </summary>
        public async Task<ApiResponse<AttachmentResponse>> GetAttachmentAsync(
            string guid,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey
            };

            return await SendRequestAsync<AttachmentResponse>(
                $"/api/binaries/{guid}/get", request, timeout);
        }
    }
}
