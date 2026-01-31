using System;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Demo;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Demo;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient のデモ操作に関する機能を提供する部分クラス
    /// </summary>
    public partial class PleasanterClient
    {
        #region RegisterDemo (デモ登録)

        /// <summary>
        /// デモ環境を登録します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>デモ登録レスポンス</returns>
        /// <remarks>
        /// この機能を使用するには、サーバー側で Service.DemoApi パラメータが有効になっている必要があります。
        /// </remarks>
        public async Task<ApiResponse<RegisterDemoResponse>> RegisterDemoAsync(
            RegisterDemoRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<RegisterDemoResponse>(
                "/api/demo/register", request, timeout);
        }

        /// <summary>
        /// デモ環境を登録します
        /// </summary>
        /// <param name="mailAddress">メールアドレス</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>デモ登録レスポンス</returns>
        /// <remarks>
        /// この機能を使用するには、サーバー側で Service.DemoApi パラメータが有効になっている必要があります。
        /// </remarks>
        public async Task<ApiResponse<RegisterDemoResponse>> RegisterDemoAsync(
            string mailAddress,
            TimeSpan? timeout = null)
        {
            var request = new RegisterDemoRequest
            {
                MailAddress = mailAddress ?? throw new ArgumentNullException(nameof(mailAddress))
            };
            return await RegisterDemoAsync(request, timeout);
        }

        #endregion
    }
}
