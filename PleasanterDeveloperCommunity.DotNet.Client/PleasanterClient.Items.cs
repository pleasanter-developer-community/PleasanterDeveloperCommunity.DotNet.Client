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
    /// レコードを作成します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<CreateRecordResponse>> CreateRecordAsync(
        long siteId,
        CreateRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<CreateRecordResponse>(
            $"/api/items/{siteId}/create", request, timeout, cancellationToken);
    }

    /// <summary>
    /// レコードを作成します
    /// </summary>
    public async Task<ApiResponse<CreateRecordResponse>> CreateRecordAsync(
        long siteId,
        string? title = null,
        string? body = null,
        int? status = null,
        int? manager = null,
        int? owner = null,
        string? completionTime = null,
        Dictionary<string, string>? classHash = null,
        Dictionary<string, decimal>? numHash = null,
        Dictionary<string, DateTime>? dateHash = null,
        Dictionary<string, string>? descriptionHash = null,
        Dictionary<string, bool>? checkHash = null,
        Dictionary<string, List<AttachmentData>>? attachmentsHash = null,
        int? processId = null,
        List<int>? processIds = null,
        Dictionary<string, ImageSettings>? imageHash = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new CreateRecordRequest
        {
            Title = title,
            Body = body,
            Status = status,
            Manager = manager,
            Owner = owner,
            CompletionTime = completionTime,
            ClassHash = classHash,
            NumHash = numHash,
            DateHash = dateHash,
            DescriptionHash = descriptionHash,
            CheckHash = checkHash,
            AttachmentsHash = attachmentsHash,
            ProcessId = processId,
            ProcessIds = processIds,
            ImageHash = imageHash
        };
        return await CreateRecordAsync(siteId, request, timeout, cancellationToken);
    }

    #endregion

    #region Get Record

    /// <summary>
    /// 単一レコードを取得します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<RecordResponse>> GetRecordAsync(
        long recordId,
        GetRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<RecordResponse>(
            $"/api/items/{recordId}/get", request, timeout, cancellationToken);
    }

    /// <summary>
    /// 単一レコードを取得します
    /// </summary>
    public async Task<ApiResponse<RecordResponse>> GetRecordAsync(
        long recordId,
        View? view = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new GetRecordRequest { View = view };
        return await GetRecordAsync(recordId, request, timeout, cancellationToken);
    }

    #endregion

    #region Get Records

    /// <summary>
    /// 複数レコードを取得します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<RecordsResponse>> GetRecordsAsync(
        long siteId,
        GetRecordsRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<RecordsResponse>(
            $"/api/items/{siteId}/get", request, timeout, cancellationToken);
    }

    /// <summary>
    /// 複数レコードを取得します
    /// </summary>
    public async Task<ApiResponse<RecordsResponse>> GetRecordsAsync(
        long siteId,
        int? offset = null,
        View? view = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new GetRecordsRequest { Offset = offset, View = view };
        return await GetRecordsAsync(siteId, request, timeout, cancellationToken);
    }

    /// <summary>
    /// ページングを自動処理して全レコードを取得します
    /// </summary>
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
            var response = await GetRecordsAsync(siteId, offset, view, timeout, cancellationToken);

            if (!response.IsSuccess || response.Response?.Data == null)
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
    /// レコードを更新します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<UpdateRecordResponse>> UpdateRecordAsync(
        long recordId,
        UpdateRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<UpdateRecordResponse>(
            $"/api/items/{recordId}/update", request, timeout, cancellationToken);
    }

    /// <summary>
    /// レコードを更新します
    /// </summary>
    public async Task<ApiResponse<UpdateRecordResponse>> UpdateRecordAsync(
        long recordId,
        string? title = null,
        string? body = null,
        int? status = null,
        int? manager = null,
        int? owner = null,
        string? completionTime = null,
        Dictionary<string, string>? classHash = null,
        Dictionary<string, decimal>? numHash = null,
        Dictionary<string, DateTime>? dateHash = null,
        Dictionary<string, string>? descriptionHash = null,
        Dictionary<string, bool>? checkHash = null,
        Dictionary<string, List<AttachmentData>>? attachmentsHash = null,
        int? processId = null,
        List<int>? processIds = null,
        Dictionary<string, ImageSettings>? imageHash = null,
        List<string>? recordPermissions = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new UpdateRecordRequest
        {
            Title = title,
            Body = body,
            Status = status,
            Manager = manager,
            Owner = owner,
            CompletionTime = completionTime,
            ClassHash = classHash,
            NumHash = numHash,
            DateHash = dateHash,
            DescriptionHash = descriptionHash,
            CheckHash = checkHash,
            AttachmentsHash = attachmentsHash,
            ProcessId = processId,
            ProcessIds = processIds,
            ImageHash = imageHash,
            RecordPermissions = recordPermissions
        };
        return await UpdateRecordAsync(recordId, request, timeout, cancellationToken);
    }

    #endregion

    #region Upsert Record

    /// <summary>
    /// レコードを作成または更新します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<UpsertRecordResponse>> UpsertRecordAsync(
        long siteId,
        UpsertRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (request.Keys == null) throw new ArgumentException("Keys is required", nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<UpsertRecordResponse>(
            $"/api/items/{siteId}/upsert", request, timeout, cancellationToken);
    }

    /// <summary>
    /// レコードを作成または更新します
    /// </summary>
    public async Task<ApiResponse<UpsertRecordResponse>> UpsertRecordAsync(
        long siteId,
        List<string> keys,
        string? title = null,
        string? body = null,
        int? status = null,
        int? manager = null,
        int? owner = null,
        string? completionTime = null,
        Dictionary<string, string>? classHash = null,
        Dictionary<string, decimal>? numHash = null,
        Dictionary<string, DateTime>? dateHash = null,
        Dictionary<string, string>? descriptionHash = null,
        Dictionary<string, bool>? checkHash = null,
        int? processId = null,
        List<int>? processIds = null,
        Dictionary<string, ImageSettings>? imageHash = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new UpsertRecordRequest
        {
            Keys = keys ?? throw new ArgumentNullException(nameof(keys)),
            Title = title,
            Body = body,
            Status = status,
            Manager = manager,
            Owner = owner,
            CompletionTime = completionTime,
            ClassHash = classHash,
            NumHash = numHash,
            DateHash = dateHash,
            DescriptionHash = descriptionHash,
            CheckHash = checkHash,
            ProcessId = processId,
            ProcessIds = processIds,
            ImageHash = imageHash
        };
        return await UpsertRecordAsync(siteId, request, timeout, cancellationToken);
    }

    #endregion

    #region Bulk Upsert Record

    /// <summary>
    /// 複数レコードを一括で作成または更新します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<BulkUpsertRecordResponse>> BulkUpsertRecordAsync(
        long siteId,
        BulkUpsertRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (request.Data == null) throw new ArgumentException("Data is required", nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<BulkUpsertRecordResponse>(
            $"/api/items/{siteId}/bulkupsert", request, timeout, cancellationToken);
    }

    /// <summary>
    /// 複数レコードを一括で作成または更新します
    /// </summary>
    public async Task<ApiResponse<BulkUpsertRecordResponse>> BulkUpsertRecordAsync(
        long siteId,
        List<BulkUpsertRecordData> data,
        List<string>? keys = null,
        bool? keyNotFoundCreate = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new BulkUpsertRecordRequest
        {
            Data = data ?? throw new ArgumentNullException(nameof(data)),
            Keys = keys,
            KeyNotFoundCreate = keyNotFoundCreate
        };
        return await BulkUpsertRecordAsync(siteId, request, timeout, cancellationToken);
    }

    #endregion

    #region Delete Record

    /// <summary>
    /// レコードを削除します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<DeleteRecordResponse>> DeleteRecordAsync(
        long recordId,
        DeleteRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<DeleteRecordResponse>(
            $"/api/items/{recordId}/delete", request, timeout, cancellationToken);
    }

    /// <summary>
    /// レコードを削除します
    /// </summary>
    public async Task<ApiResponse<DeleteRecordResponse>> DeleteRecordAsync(
        long recordId,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteRecordRequest();
        return await DeleteRecordAsync(recordId, request, timeout, cancellationToken);
    }

    #endregion

    #region Bulk Delete Record

    /// <summary>
    /// レコードを一括削除します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<BulkDeleteRecordResponse>> BulkDeleteRecordAsync(
        long siteId,
        BulkDeleteRecordRequest request,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<BulkDeleteRecordResponse>(
            $"/api/items/{siteId}/bulkdelete", request, timeout, cancellationToken);
    }

    /// <summary>
    /// レコードを一括削除します
    /// </summary>
    public async Task<ApiResponse<BulkDeleteRecordResponse>> BulkDeleteRecordAsync(
        long siteId,
        List<long>? selected = null,
        View? view = null,
        bool? all = null,
        bool? physicalDelete = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var request = new BulkDeleteRecordRequest
        {
            Selected = selected,
            View = view,
            All = all,
            PhysicalDelete = physicalDelete
        };
        return await BulkDeleteRecordAsync(siteId, request, timeout, cancellationToken);
    }

    #endregion
}
