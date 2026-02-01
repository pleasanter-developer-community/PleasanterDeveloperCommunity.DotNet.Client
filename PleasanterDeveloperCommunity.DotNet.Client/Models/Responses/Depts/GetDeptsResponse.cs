using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織取得レスポンス
/// </summary>
public class GetDeptsResponse
{
    [JsonProperty("Data")]
    public List<DeptData>? Data { get; set; }

    [JsonProperty("TotalCount")]
    public int TotalCount { get; set; }
}

/// <summary>
/// 組織データ
/// </summary>
public class DeptData
{
    [JsonProperty("TenantId")]
    public int TenantId { get; set; }

    [JsonProperty("DeptId")]
    public int DeptId { get; set; }

    [JsonProperty("Ver")]
    public int Ver { get; set; }

    [JsonProperty("DeptCode")]
    public string? DeptCode { get; set; }

    [JsonProperty("DeptName")]
    public string? DeptName { get; set; }

    [JsonProperty("Body")]
    public string? Body { get; set; }

    [JsonProperty("Disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("Comments")]
    public string? Comments { get; set; }

    [JsonProperty("Creator")]
    public int Creator { get; set; }

    [JsonProperty("Updator")]
    public int Updator { get; set; }

    [JsonProperty("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonProperty("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }
}
