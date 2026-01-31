using System;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Sessions;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sessions;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient のセッション操作に関する機能を提供する部分クラス
    /// </summary>
    public partial class PleasanterClient
    {
        #region GetSession (セッション取得)

        /// <summary>
        /// セッションを取得します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>セッション取得レスポンス</returns>
        public async Task<ApiResponse<GetSessionResponse>> GetSessionAsync(
            GetSessionRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<GetSessionResponse>(
                "/api/sessions/get", request, timeout);
        }

        /// <summary>
        /// セッションを取得します
        /// </summary>
        /// <param name="name">セッション名</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>セッション取得レスポンス</returns>
        public async Task<ApiResponse<GetSessionResponse>> GetSessionAsync(
            string? name = null,
            TimeSpan? timeout = null)
        {
            var request = new GetSessionRequest
            {
                Name = name
            };
            return await GetSessionAsync(request, timeout);
        }

        #endregion

        #region SetSession (セッション設定)

        /// <summary>
        /// セッションを設定します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>セッション設定レスポンス</returns>
        public async Task<ApiResponse<SetSessionResponse>> SetSessionAsync(
            SetSessionRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<SetSessionResponse>(
                "/api/sessions/set", request, timeout);
        }

        /// <summary>
        /// セッションを設定します
        /// </summary>
        /// <param name="name">セッション名</param>
        /// <param name="value">値</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>セッション設定レスポンス</returns>
        public async Task<ApiResponse<SetSessionResponse>> SetSessionAsync(
            string name,
            string value,
            TimeSpan? timeout = null)
        {
            var request = new SetSessionRequest
            {
                Name = name ?? throw new ArgumentNullException(nameof(name)),
                Value = value ?? throw new ArgumentNullException(nameof(value))
            };
            return await SetSessionAsync(request, timeout);
        }

        #endregion

        #region DeleteSession (セッション削除)

        /// <summary>
        /// セッションを削除します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>セッション削除レスポンス</returns>
        public async Task<ApiResponse<DeleteSessionResponse>> DeleteSessionAsync(
            DeleteSessionRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<DeleteSessionResponse>(
                "/api/sessions/delete", request, timeout);
        }

        /// <summary>
        /// セッションを削除します
        /// </summary>
        /// <param name="name">セッション名</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>セッション削除レスポンス</returns>
        public async Task<ApiResponse<DeleteSessionResponse>> DeleteSessionAsync(
            string name,
            TimeSpan? timeout = null)
        {
            var request = new DeleteSessionRequest
            {
                Name = name ?? throw new ArgumentNullException(nameof(name))
            };
            return await DeleteSessionAsync(request, timeout);
        }

        #endregion
    }
}
