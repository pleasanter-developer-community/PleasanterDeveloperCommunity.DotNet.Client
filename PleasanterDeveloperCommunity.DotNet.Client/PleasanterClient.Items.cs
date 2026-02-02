using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient - レコード操作API
/// </summary>
public partial class PleasanterClient
{
    #region Create Record

    /// <summary>
    /// レコードを作成します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-01-レコード-作成.md">Wiki: 01-テーブル操作-01-レコード-作成</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>レコード作成レスポンス</returns>
    public async Task<ApiResponse<CreateRecordResponse>> CreateRecordAsync(
        long siteId,
        CreateRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<CreateRecordResponse>(
            $"/api/items/{siteId}/create", request, timeout, cancellationToken);
    }

    #endregion

    #region Get Record

    /// <summary>
    /// 単一レコードを取得します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-03-レコード-取得(単一).md">Wiki: 01-テーブル操作-03-レコード-取得(単一)</seealso>
    /// <param name="recordId">レコードID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>レコード取得レスポンス</returns>
    public async Task<ApiResponse<RecordResponse>> GetRecordAsync(
        long recordId,
        GetRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<RecordResponse>(
            $"/api/items/{recordId}/get", request, timeout, cancellationToken);
    }

    #endregion

    #region Get Records

    /// <summary>
    /// 複数レコードを取得します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-04-テーブル-取得(複数).md">Wiki: 01-テーブル操作-04-テーブル-取得(複数)</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>複数レコード取得レスポンス</returns>
    public async Task<ApiResponse<RecordsResponse>> GetRecordsAsync(
        long siteId,
        GetRecordsRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<RecordsResponse>(
            $"/api/items/{siteId}/get", request, timeout, cancellationToken);
    }

    /// <summary>
    /// ページングを自動処理して全レコードを取得します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-04-テーブル-取得(複数).md">Wiki: 01-テーブル操作-04-テーブル-取得(複数)</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="view">ビュー</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>全レコード取得レスポンス</returns>
    public async Task<ApiResponse<RecordsResponse>> GetAllRecordsAsync(
        long siteId,
        View? view = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var allData = new List<RecordData>();
        int offset = 0;
        int? totalCount = null;

        while (true)
        {
            var request = new GetRecordsRequest { Offset = offset, View = view };
            var response = await GetRecordsAsync(siteId, request, timeout, cancellationToken);

            if (!response.IsSuccess || response.Response?.Data is null)
                return response;

            allData.AddRange(response.Response.Data);
            totalCount = response.Response.TotalCount;

            if (allData.Count >= totalCount || response.Response.Data.Count == 0)
                break;

            offset = allData.Count;
        }

        return new ApiResponse<RecordsResponse>
        {
            StatusCode = HttpStatusCode.OK,
            Message = null,
            Response = new RecordsResponse
            {
                Data = allData,
                TotalCount = totalCount ?? allData.Count,
                Offset = 0,
                PageSize = allData.Count
            }
        };
    }

    #endregion

    #region Update Record

    /// <summary>
    /// レコードを更新します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-07-レコード-更新.md">Wiki: 01-テーブル操作-07-レコード-更新</seealso>
    /// <param name="recordId">レコードID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>レコード更新レスポンス</returns>
    public async Task<ApiResponse<UpdateRecordResponse>> UpdateRecordAsync(
        long recordId,
        UpdateRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateRecordResponse>(
            $"/api/items/{recordId}/update", request, timeout, cancellationToken);
    }

    #endregion

    #region Upsert Record

    /// <summary>
    /// レコードを作成または更新します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-08-テーブル-作成・更新.md">Wiki: 01-テーブル操作-08-テーブル-作成・更新</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>レコード作成または更新レスポンス</returns>
    public async Task<ApiResponse<UpsertRecordResponse>> UpsertRecordAsync(
        long siteId,
        UpsertRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.Keys is null)
        {
            throw new ArgumentException("Keys is required", nameof(request));
        }
        SetApiCredentials(request);
        return await SendRequestAsync<UpsertRecordResponse>(
            $"/api/items/{siteId}/upsert", request, timeout, cancellationToken);
    }

    #endregion

    #region Bulk Upsert Record

    /// <summary>
    /// 複数レコードを一括で作成または更新します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-09-テーブル-一括作成・更新.md">Wiki: 01-テーブル操作-09-テーブル-一括作成・更新</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>一括作成または更新レスポンス</returns>
    public async Task<ApiResponse<BulkUpsertRecordResponse>> BulkUpsertRecordAsync(
        long siteId,
        BulkUpsertRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.Data is null)
        {
            throw new ArgumentException("Data is required", nameof(request));
        }
        SetApiCredentials(request);
        return await SendRequestAsync<BulkUpsertRecordResponse>(
            $"/api/items/{siteId}/bulkupsert", request, timeout, cancellationToken);
    }

    #endregion

    #region Delete Record

    /// <summary>
    /// レコードを削除します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-10-レコード-削除.md">Wiki: 01-テーブル操作-10-レコード-削除</seealso>
    /// <param name="recordId">レコードID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>レコード削除レスポンス</returns>
    public async Task<ApiResponse<DeleteRecordResponse>> DeleteRecordAsync(
        long recordId,
        DeleteRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteRecordResponse>(
            $"/api/items/{recordId}/delete", request, timeout, cancellationToken);
    }

    #endregion

    #region Bulk Delete Record

    /// <summary>
    /// レコードを一括削除します
    /// </summary>
    /// <seealso href="../docs/wiki/01-テーブル操作-11-テーブル-一括削除.md">Wiki: 01-テーブル操作-11-テーブル-一括削除</seealso>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>一括削除レスポンス</returns>
    public async Task<ApiResponse<BulkDeleteRecordResponse>> BulkDeleteRecordAsync(
        long siteId,
        BulkDeleteRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        SetApiCredentials(request);
        return await SendRequestAsync<BulkDeleteRecordResponse>(
            $"/api/items/{siteId}/bulkdelete", request, timeout, cancellationToken);
    }

    #endregion
}
