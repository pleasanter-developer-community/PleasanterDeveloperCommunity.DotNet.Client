using System;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコード更新レスポンス
/// </summary>
public class UpdateRecordResponse
{
    public long Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public int? LimitPerDate { get; set; }

    public int? LimitRemaining { get; set; }
}
