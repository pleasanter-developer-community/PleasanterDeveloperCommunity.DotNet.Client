using System;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Groups;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient のグループ操作に関する機能を提供する部分クラス
    /// </summary>
    public partial class PleasanterClient
    {
        #region GetGroups (グループ取得)

        /// <summary>
        /// グループ一覧を取得します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>グループ取得レスポンス</returns>
        public async Task<ApiResponse<GetGroupsResponse>> GetGroupsAsync(
            GetGroupsRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<GetGroupsResponse>(
                "/api/groups/get", request, timeout);
        }

        /// <summary>
        /// グループ一覧を取得します
        /// </summary>
        /// <param name="offset">取得開始位置</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>グループ取得レスポンス</returns>
        public async Task<ApiResponse<GetGroupsResponse>> GetGroupsAsync(
            int? offset = null,
            TimeSpan? timeout = null)
        {
            var request = new GetGroupsRequest
            {
                Offset = offset
            };
            return await GetGroupsAsync(request, timeout);
        }

        #endregion

        #region CreateGroup (グループ作成)

        /// <summary>
        /// グループを作成します（リクエストモデル版）
        /// </summary>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>グループ作成レスポンス</returns>
        public async Task<ApiResponse<CreateGroupResponse>> CreateGroupAsync(
            CreateGroupRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<CreateGroupResponse>(
                "/api/groups/create", request, timeout);
        }

        /// <summary>
        /// グループを作成します
        /// </summary>
        /// <param name="groupName">グループ名</param>
        /// <param name="body">内容</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>グループ作成レスポンス</returns>
        public async Task<ApiResponse<CreateGroupResponse>> CreateGroupAsync(
            string groupName,
            string? body = null,
            TimeSpan? timeout = null)
        {
            var request = new CreateGroupRequest
            {
                GroupName = groupName ?? throw new ArgumentNullException(nameof(groupName)),
                Body = body
            };
            return await CreateGroupAsync(request, timeout);
        }

        #endregion

        #region UpdateGroup (グループ更新)

        /// <summary>
        /// グループを更新します（リクエストモデル版）
        /// </summary>
        /// <param name="groupId">グループID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>グループ更新レスポンス</returns>
        public async Task<ApiResponse<UpdateGroupResponse>> UpdateGroupAsync(
            long groupId,
            UpdateGroupRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<UpdateGroupResponse>(
                $"/api/groups/{groupId}/update", request, timeout);
        }

        /// <summary>
        /// グループを更新します
        /// </summary>
        /// <param name="groupId">グループID</param>
        /// <param name="groupName">グループ名</param>
        /// <param name="body">内容</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>グループ更新レスポンス</returns>
        public async Task<ApiResponse<UpdateGroupResponse>> UpdateGroupAsync(
            long groupId,
            string? groupName = null,
            string? body = null,
            TimeSpan? timeout = null)
        {
            var request = new UpdateGroupRequest
            {
                GroupName = groupName,
                Body = body
            };
            return await UpdateGroupAsync(groupId, request, timeout);
        }

        #endregion

        #region DeleteGroup (グループ削除)

        /// <summary>
        /// グループを削除します（リクエストモデル版）
        /// </summary>
        /// <param name="groupId">グループID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>グループ削除レスポンス</returns>
        public async Task<ApiResponse<DeleteGroupResponse>> DeleteGroupAsync(
            long groupId,
            DeleteGroupRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<DeleteGroupResponse>(
                $"/api/groups/{groupId}/delete", request, timeout);
        }

        /// <summary>
        /// グループを削除します
        /// </summary>
        /// <param name="groupId">グループID</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>グループ削除レスポンス</returns>
        public async Task<ApiResponse<DeleteGroupResponse>> DeleteGroupAsync(
            long groupId,
            TimeSpan? timeout = null)
        {
            var request = new DeleteGroupRequest();
            return await DeleteGroupAsync(groupId, request, timeout);
        }

        #endregion
    }
}
