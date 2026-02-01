using System;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Demo;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Demo;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient のデモ操作に関する機能を提供する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region RegisterDemo (デモ登録)

    /// <summary>
    /// デモ環境を登録します
    /// </summary>
    /// <seealso href="../docs/wiki/13-デモ-01-デモ環境-登録.md">Wiki: 13-デモ-01-デモ環境-登録</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>デモ登録レスポンス</returns>
    /// <remarks>
    /// この機能を使用するには、サーバー側で Service.DemoApi パラメータが有効になっている必要があります。
    /// </remarks>
    public async Task<ApiResponse<RegisterDemoResponse>> RegisterDemoAsync(
        RegisterDemoRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        SetApiCredentials(request);
        return await SendRequestAsync<RegisterDemoResponse>(
            "/api/demo/register", request, timeout, cancellationToken);
    }

    #endregion
}
