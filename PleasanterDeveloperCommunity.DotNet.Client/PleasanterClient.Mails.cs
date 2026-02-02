using System;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Mails;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Mails;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient のメール操作に関する機能を提供する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region SendMail (メール送信)

    /// <summary>
    /// メールを送信します
    /// </summary>
    /// <seealso href="../docs/wiki/07-メール操作-01-メール-送信.md">Wiki: 07-メール操作-01-メール-送信</seealso>
    /// <param name="itemId">アイテムID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>メール送信レスポンス</returns>
    public async Task<ApiResponse<SendMailResponse>> SendMailAsync(
        long itemId,
        SendMailRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        SetApiCredentials(request);
        return await SendRequestAsync<SendMailResponse>(
            $"/api/items/{itemId}/OutgoingMails/Send", request, timeout, cancellationToken);
    }

    #endregion
}
