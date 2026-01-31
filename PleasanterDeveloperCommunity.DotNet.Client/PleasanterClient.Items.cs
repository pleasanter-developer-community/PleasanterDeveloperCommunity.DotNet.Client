using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient - レコード操作API
    /// </summary>
    public partial class PleasanterClient
    {
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
            TimeSpan? timeout = null)
        {
            var request = BuildRecordRequest(title, body, status, manager, owner, completionTime,
                classHash, numHash, dateHash, descriptionHash, checkHash, attachmentsHash,
                processId, processIds, imageHash);

            return await SendRequestAsync<CreateRecordResponse>(
                $"/api/items/{siteId}/create", request, timeout);
        }

        /// <summary>
        /// 単一レコードを取得します
        /// </summary>
        public async Task<ApiResponse<RecordResponse>> GetRecordAsync(
            long recordId,
            View? view = null,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey
            };

            if (view != null)
                request["View"] = view;

            return await SendRequestAsync<RecordResponse>(
                $"/api/items/{recordId}/get", request, timeout);
        }

        /// <summary>
        /// 複数レコードを取得します
        /// </summary>
        public async Task<ApiResponse<RecordsResponse>> GetRecordsAsync(
            long siteId,
            int? offset = null,
            View? view = null,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey
            };

            if (offset.HasValue)
                request["Offset"] = offset.Value;

            if (view != null)
                request["View"] = view;

            return await SendRequestAsync<RecordsResponse>(
                $"/api/items/{siteId}/get", request, timeout);
        }

        /// <summary>
        /// ページングを自動処理して全レコードを取得します
        /// </summary>
        public async Task<ApiResponse<RecordsResponse>> GetAllRecordsAsync(
            long siteId,
            View? view = null,
            TimeSpan? timeout = null)
        {
            var allData = new List<RecordData>();
            int offset = 0;
            int? totalCount = null;

            while (true)
            {
                var response = await GetRecordsAsync(siteId, offset, view, timeout);

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
            TimeSpan? timeout = null)
        {
            var request = BuildRecordRequest(title, body, status, manager, owner, completionTime,
                classHash, numHash, dateHash, descriptionHash, checkHash, attachmentsHash,
                processId, processIds, imageHash);

            if (recordPermissions != null)
                request["RecordPermissions"] = recordPermissions;

            return await SendRequestAsync<UpdateRecordResponse>(
                $"/api/items/{recordId}/update", request, timeout);
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
            TimeSpan? timeout = null)
        {
            var request = BuildRecordRequest(title, body, status, manager, owner, completionTime,
                classHash, numHash, dateHash, descriptionHash, checkHash, null,
                processId, processIds, imageHash);

            request["Keys"] = keys ?? throw new ArgumentNullException(nameof(keys));

            return await SendRequestAsync<UpsertRecordResponse>(
                $"/api/items/{siteId}/upsert", request, timeout);
        }

        /// <summary>
        /// 複数レコードを一括で作成または更新します
        /// </summary>
        public async Task<ApiResponse<BulkUpsertRecordResponse>> BulkUpsertRecordAsync(
            long siteId,
            List<BulkUpsertRecordData> data,
            List<string>? keys = null,
            bool? keyNotFoundCreate = null,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey,
                ["Data"] = data ?? throw new ArgumentNullException(nameof(data))
            };

            if (keys != null)
                request["Keys"] = keys;

            if (keyNotFoundCreate.HasValue)
                request["KeyNotFoundCreate"] = keyNotFoundCreate.Value;

            return await SendRequestAsync<BulkUpsertRecordResponse>(
                $"/api/items/{siteId}/bulkupsert", request, timeout);
        }

        /// <summary>
        /// レコードを削除します
        /// </summary>
        public async Task<ApiResponse<DeleteRecordResponse>> DeleteRecordAsync(
            long recordId,
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey
            };

            return await SendRequestAsync<DeleteRecordResponse>(
                $"/api/items/{recordId}/delete", request, timeout);
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
            TimeSpan? timeout = null)
        {
            var request = new Dictionary<string, object>
            {
                ["ApiVersion"] = _apiVersion.ToString("F1", CultureInfo.InvariantCulture),
                ["ApiKey"] = _apiKey
            };

            if (selected != null)
                request["Selected"] = selected;

            if (view != null)
                request["View"] = view;

            if (all.HasValue)
                request["All"] = all.Value;

            if (physicalDelete.HasValue)
                request["PhysicalDelete"] = physicalDelete.Value;

            return await SendRequestAsync<BulkDeleteRecordResponse>(
                $"/api/items/{siteId}/bulkdelete", request, timeout);
        }
    }
}
