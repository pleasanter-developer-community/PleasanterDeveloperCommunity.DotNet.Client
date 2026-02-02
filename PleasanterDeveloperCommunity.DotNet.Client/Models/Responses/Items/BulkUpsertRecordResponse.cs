using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 一括Upsertレスポンス
/// </summary>
public class BulkUpsertRecordResponse
{
    public long Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }

    public int? Created { get; set; }

    public int? Updated { get; set; }
}
