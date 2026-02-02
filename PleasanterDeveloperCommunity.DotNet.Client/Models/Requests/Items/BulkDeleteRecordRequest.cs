using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// 一括削除リクエスト
/// </summary>
public class BulkDeleteRecordRequest : ApiRequestBase
{
    /// <summary>
    /// 削除対象レコードID一覧
    /// </summary>
    public List<long>? Selected { get; set; }

    /// <summary>
    /// ビュー設定
    /// </summary>
    public View? View { get; set; }

    /// <summary>
    /// 全削除フラグ
    /// </summary>
    public bool? All { get; set; }

    /// <summary>
    /// 物理削除フラグ
    /// </summary>
    public bool? PhysicalDelete { get; set; }
}
