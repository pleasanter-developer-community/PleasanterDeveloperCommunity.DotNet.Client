using System;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Mails;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Mails;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient のメール操作に関する機能を提供する部分クラス
    /// </summary>
    public partial class PleasanterClient
    {
        #region SendMail (メール送信)

        /// <summary>
        /// メールを送信します（リクエストモデル版）
        /// </summary>
        /// <param name="itemId">アイテムID</param>
        /// <param name="request">リクエストモデル</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>メール送信レスポンス</returns>
        public async Task<ApiResponse<SendMailResponse>> SendMailAsync(
            long itemId,
            SendMailRequest request,
            TimeSpan? timeout = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SetApiCredentials(request);
            return await SendRequestAsync<SendMailResponse>(
                $"/api/items/{itemId}/mails/send", request, timeout);
        }

        /// <summary>
        /// メールを送信します
        /// </summary>
        /// <param name="itemId">アイテムID</param>
        /// <param name="to">宛先</param>
        /// <param name="title">件名</param>
        /// <param name="body">本文</param>
        /// <param name="cc">CC</param>
        /// <param name="bcc">BCC</param>
        /// <param name="timeout">タイムアウト</param>
        /// <returns>メール送信レスポンス</returns>
        public async Task<ApiResponse<SendMailResponse>> SendMailAsync(
            long itemId,
            string to,
            string title,
            string body,
            string? cc = null,
            string? bcc = null,
            TimeSpan? timeout = null)
        {
            var request = new SendMailRequest
            {
                To = to ?? throw new ArgumentNullException(nameof(to)),
                Title = title ?? throw new ArgumentNullException(nameof(title)),
                Body = body ?? throw new ArgumentNullException(nameof(body)),
                Cc = cc,
                Bcc = bcc
            };
            return await SendMailAsync(itemId, request, timeout);
        }

        #endregion
    }
}
