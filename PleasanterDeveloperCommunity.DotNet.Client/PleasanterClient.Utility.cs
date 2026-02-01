using System;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Utility;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Utility;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient のユーティリティ機能に関する部分クラス
/// </summary>
public partial class PleasanterClient
{
    #region GetLicenseInfo (ライセンス情報取得)

    /// <summary>
    /// ライセンス情報を取得します
    /// </summary>
    /// <seealso href="../docs/wiki/11-ユーティリティ-01-ライセンス情報取得.md">Wiki: 11-ユーティリティ-01-ライセンス情報取得</seealso>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>ライセンス情報取得レスポンス</returns>
    public async Task<ApiResponse<GetLicenseInfoResponse>> GetLicenseInfoAsync(
        GetLicenseInfoRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        SetApiCredentials(request);
        return await SendRequestAsync<GetLicenseInfoResponse>(
            "/api/utility/getlicenseinfo", request, timeout, cancellationToken);
    }

    #endregion
}
