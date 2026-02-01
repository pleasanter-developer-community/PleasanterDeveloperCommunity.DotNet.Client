using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Extended;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient - 拡張SQL API
/// </summary>
public partial class PleasanterClient
{
    /// <summary>
    /// 拡張SQLを実行します（リクエストモデル版）
    /// </summary>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張SQLレスポンス</returns>
    public async Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(
        ExtendedSqlRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Name is required", nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<ExtendedSqlResponse>(
            "/api/extended/sql", request, timeout, cancellationToken);
    }

    /// <summary>
    /// 拡張SQLを実行します
    /// </summary>
    /// <param name="name">拡張SQL名</param>
    /// <param name="parameters">パラメータ</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>拡張SQLレスポンス</returns>
    public async Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(
        string name,
        Dictionary<string, object>? parameters = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new ExtendedSqlRequest
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)),
            AdditionalParameters = parameters
        };
        return await ExecuteExtendedSqlAsync(request, timeout, cancellationToken);
    }
}