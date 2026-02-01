using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// 一括削除リクエスト
/// </summary>
public class BulkDeleteRecordRequest : ApiRequestBase
{
    /// <summary>
    /// 削除対象レコードID一覧
    /// </summary>
    [JsonProperty("Selected")]
    public List<long>? Selected { get; set; }

    /// <summary>
    /// ビュー設定
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }

    /// <summary>
    /// 全削除フラグ
    /// </summary>
    [JsonProperty("All")]
    public bool? All { get; set; }

    /// <summary>
    /// 物理削除フラグ
    /// </summary>
    [JsonProperty("PhysicalDelete")]
    public bool? PhysicalDelete { get; set; }
}
