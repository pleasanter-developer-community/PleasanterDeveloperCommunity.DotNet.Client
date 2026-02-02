using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織削除レスポンス
/// </summary>
public class DeleteDeptResponse
{
    public int Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}
