using System.Collections.Generic;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 複数レコード取得レスポンス
/// </summary>
public class RecordsResponse
{
    public int? Offset { get; set; }

    public int? PageSize { get; set; }

    public int? TotalCount { get; set; }

    public List<RecordData>? Data { get; set; }
}
