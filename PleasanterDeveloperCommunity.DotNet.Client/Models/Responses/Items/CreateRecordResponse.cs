using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコード作成レスポンス
/// </summary>
public class CreateRecordResponse
{
    public long Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }

    public int? LimitPerDate { get; set; }

    public int? LimitRemaining { get; set; }
}
