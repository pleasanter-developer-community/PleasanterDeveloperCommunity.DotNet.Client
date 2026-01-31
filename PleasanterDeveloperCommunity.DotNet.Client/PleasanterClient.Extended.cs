using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Extended;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient - 拡張SQL API
    /// </summary>
    public partial class PleasanterClient
    {
        /// <summary>
        /// 拡張SQLを実行します（リクエストモデル版）
        /// </summary>
        public async Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(
            ExtendedSqlRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Name is required", nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<ExtendedSqlResponse>(
                "/api/extended/sql", request, timeout);
        }

        /// <summary>
        /// 拡張SQLを実行します
        /// </summary>
        public async Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(
            string name,
            Dictionary<string, object>? parameters = null,
            TimeSpan? timeout = null)
        {
            var request = new ExtendedSqlRequest
            {
                Name = name ?? throw new ArgumentNullException(nameof(name)),
                AdditionalParameters = parameters
            };
            return await ExecuteExtendedSqlAsync(request, timeout);
        }
    }
}
