using System;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Users;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient のユーザ操作に関する機能を提供する部分クラス
    /// </summary>
    public partial class PleasanterClient
    {
        #region GetUsers (ユーザ取得)

        /// <summary>
        /// ユーザ一覧を取得します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ユーザ取得レスポンス</returns>
        public async Task<ApiResponse<GetUsersResponse>> GetUsersAsync(
            GetUsersRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<GetUsersResponse>(
                "/api/users/get", request, timeout);
        }

        /// <summary>
        /// ユーザ一覧を取得します
        /// </summary>
        /// <param name="offset">取得開始位置</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ユーザ取得レスポンス</returns>
        public async Task<ApiResponse<GetUsersResponse>> GetUsersAsync(
            int? offset = null,
            TimeSpan? timeout = null)
        {
            var request = new GetUsersRequest
            {
                Offset = offset
            };
            return await GetUsersAsync(request, timeout);
        }

        #endregion

        #region CreateUser (ユーザ作成)

        /// <summary>
        /// ユーザを作成します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ユーザ作成レスポンス</returns>
        public async Task<ApiResponse<CreateUserResponse>> CreateUserAsync(
            CreateUserRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<CreateUserResponse>(
                "/api/users/create", request, timeout);
        }

        /// <summary>
        /// ユーザを作成します
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="name">名前</param>
        /// <param name="password">パスワード</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ユーザ作成レスポンス</returns>
        public async Task<ApiResponse<CreateUserResponse>> CreateUserAsync(
            string loginId,
            string name,
            string password,
            TimeSpan? timeout = null)
        {
            var request = new CreateUserRequest
            {
                LoginId = loginId ?? throw new ArgumentNullException(nameof(loginId)),
                Name = name ?? throw new ArgumentNullException(nameof(name)),
                Password = password ?? throw new ArgumentNullException(nameof(password))
            };
            return await CreateUserAsync(request, timeout);
        }

        #endregion

        #region UpdateUser (ユーザ更新)

        /// <summary>
        /// ユーザを更新します（リクエストモデル版）
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ユーザ更新レスポンス</returns>
        public async Task<ApiResponse<UpdateUserResponse>> UpdateUserAsync(
            long userId,
            UpdateUserRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<UpdateUserResponse>(
                $"/api/users/{userId}/update", request, timeout);
        }

        /// <summary>
        /// ユーザを更新します
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="name">名前</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ユーザ更新レスポンス</returns>
        public async Task<ApiResponse<UpdateUserResponse>> UpdateUserAsync(
            long userId,
            string? name = null,
            TimeSpan? timeout = null)
        {
            var request = new UpdateUserRequest
            {
                Name = name
            };
            return await UpdateUserAsync(userId, request, timeout);
        }

        #endregion

        #region DeleteUser (ユーザ削除)

        /// <summary>
        /// ユーザを削除します（リクエストモデル版）
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ユーザ削除レスポンス</returns>
        public async Task<ApiResponse<DeleteUserResponse>> DeleteUserAsync(
            long userId,
            DeleteUserRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<DeleteUserResponse>(
                $"/api/users/{userId}/delete", request, timeout);
        }

        /// <summary>
        /// ユーザを削除します
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>ユーザ削除レスポンス</returns>
        public async Task<ApiResponse<DeleteUserResponse>> DeleteUserAsync(
            long userId,
            TimeSpan? timeout = null)
        {
            var request = new DeleteUserRequest();
            return await DeleteUserAsync(userId, request, timeout);
        }

        #endregion
    }
}
