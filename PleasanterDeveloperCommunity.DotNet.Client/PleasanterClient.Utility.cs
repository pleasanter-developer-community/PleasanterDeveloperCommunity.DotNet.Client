using System;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Utility;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Utility;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient のユーティリティ機能に関する部分クラス
    /// </summary>
    public partial class PleasanterClient
    {
        #region GetLicenseInfo (ライセンス情報取得)

        /// <summary>
        /// ライセンス情報を取得します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ライセンス情報取得レスポンス</returns>
        public async Task<ApiResponse<GetLicenseInfoResponse>> GetLicenseInfoAsync(
            GetLicenseInfoRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<GetLicenseInfoResponse>(
                "/api/utility/getlicenseinfo", request, timeout);
        }

        /// <summary>
        /// ライセンス情報を取得します
        /// </summary>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ライセンス情報取得レスポンス</returns>
        public async Task<ApiResponse<GetLicenseInfoResponse>> GetLicenseInfoAsync(
            TimeSpan? timeout = null)
        {
            var request = new GetLicenseInfoRequest();
            return await GetLicenseInfoAsync(request, timeout);
        }

        #endregion
    }
}
