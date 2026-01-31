using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses
{
    /// <summary>
    /// 組織取得レスポンス
    /// </summary>
    public class GetDeptsResponse
    {
        [JsonPropertyName("Data")]
        public List<DeptData>? Data { get; set; }

        [JsonPropertyName("TotalCount")]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// 組織データ
    /// </summary>
    public class DeptData
    {
        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("DeptId")]
        public int DeptId { get; set; }

        [JsonPropertyName("Ver")]
        public int Ver { get; set; }

        [JsonPropertyName("DeptCode")]
        public string? DeptCode { get; set; }

        [JsonPropertyName("DeptName")]
        public string? DeptName { get; set; }

        [JsonPropertyName("Body")]
        public string? Body { get; set; }

        [JsonPropertyName("Disabled")]
        public bool Disabled { get; set; }

        [JsonPropertyName("Comments")]
        public string? Comments { get; set; }

        [JsonPropertyName("Creator")]
        public int Creator { get; set; }

        [JsonPropertyName("Updator")]
        public int Updator { get; set; }

        [JsonPropertyName("CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonPropertyName("UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }
    }

    /// <summary>
    /// 組織作成レスポンス
    /// </summary>
    public class CreateDeptResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// 組織更新レスポンス
    /// </summary>
    public class UpdateDeptResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// 組織削除レスポンス
    /// </summary>
    public class DeleteDeptResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// 組織インポートレスポンス
    /// </summary>
    public class ImportDeptsResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }
}
