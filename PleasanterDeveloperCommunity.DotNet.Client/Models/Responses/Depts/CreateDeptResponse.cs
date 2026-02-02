using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織作成レスポンス
/// </summary>
public class CreateDeptResponse
{
    public int Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}
