using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient - 拡張SQL API
    /// </summary>
    public partial class PleasanterClient
    {
        /// <summary>
        /// 拡張SQLを実行します
        /// </summary>
        public async Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(
            string name,
            Dictionary<string, object>? parameters = null,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey,
                ["Name"] = name ?? throw new ArgumentNullException(nameof(name))
            };

            if (parameters != null)
            {
                foreach (var kvp in parameters)
                {
                    request[kvp.Key] = kvp.Value;
                }
            }

            return await SendRequestAsync<ExtendedSqlResponse>(
                "/api/extended/sql", request, timeout);
        }
    }
}
