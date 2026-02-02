using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織更新レスポンス
/// </summary>
public class UpdateDeptResponse
{
    public int Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}
