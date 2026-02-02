using System.Collections.Generic;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 複数レコード取得レスポンス
/// </summary>
public class RecordsResponse
{
    /// <summary>
    /// オフセット
    /// </summary>
    public int? Offset { get; set; }

    /// <summary>
    /// ページサイズ
    /// </summary>
    public int? PageSize { get; set; }

    /// <summary>
    /// 総件数
    /// </summary>
    public int? TotalCount { get; set; }

    /// <summary>
    /// レコードデータリスト
    /// </summary>
    public List<RecordData>? Data { get; set; }
}
