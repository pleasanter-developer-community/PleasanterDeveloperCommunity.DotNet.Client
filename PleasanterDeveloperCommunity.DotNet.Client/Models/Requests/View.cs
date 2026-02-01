using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// ビュー設定
/// </summary>
public class View
{
    /// <summary>
    /// 未完了のレコードのみ取得
    /// </summary>
    [JsonProperty("Incomplete")]
    public bool? Incomplete { get; set; }

    /// <summary>
    /// 自分が担当のレコードのみ取得
    /// </summary>
    [JsonProperty("Own")]
    public bool? Own { get; set; }

    /// <summary>
    /// 期限が近いレコードのみ取得
    /// </summary>
    [JsonProperty("NearCompletionTime")]
    public bool? NearCompletionTime { get; set; }

    /// <summary>
    /// 遅延しているレコードのみ取得
    /// </summary>
    [JsonProperty("Delay")]
    public bool? Delay { get; set; }

    /// <summary>
    /// 期限超過のレコードのみ取得
    /// </summary>
    [JsonProperty("Overdue")]
    public bool? Overdue { get; set; }

    /// <summary>
    /// 全文検索キーワード
    /// </summary>
    [JsonProperty("Search")]
    public string? Search { get; set; }

    /// <summary>
    /// 列フィルタ設定
    /// </summary>
    [JsonProperty("ColumnFilterHash")]
    public Dictionary<string, string>? ColumnFilterHash { get; set; }

    /// <summary>
    /// 列フィルタ検索タイプ
    /// </summary>
    [JsonProperty("ColumnFilterSearchTypes")]
    public Dictionary<string, ColumnFilterSearchType>? ColumnFilterSearchTypes { get; set; }

    /// <summary>
    /// 否定フィルタ対象の列名
    /// </summary>
    [JsonProperty("ColumnFilterNegatives")]
    public List<string>? ColumnFilterNegatives { get; set; }

    /// <summary>
    /// ソート設定
    /// </summary>
    [JsonProperty("ColumnSorterHash")]
    public Dictionary<string, SortOrderType>? ColumnSorterHash { get; set; }

    /// <summary>
    /// APIデータタイプ
    /// </summary>
    [JsonProperty("ApiDataType")]
    public ApiDataType? ApiDataType { get; set; }

    /// <summary>
    /// APIカラムキー表示タイプ
    /// </summary>
    [JsonProperty("ApiColumnKeyDisplayType")]
    public ApiColumnKeyDisplayType? ApiColumnKeyDisplayType { get; set; }

    /// <summary>
    /// APIカラム値表示タイプ
    /// </summary>
    [JsonProperty("ApiColumnValueDisplayType")]
    public ApiColumnValueDisplayType? ApiColumnValueDisplayType { get; set; }

    /// <summary>
    /// 項目単位のKey/Value表示形式設定
    /// </summary>
    [JsonProperty("ApiColumnHash")]
    public Dictionary<string, ApiColumnSetting>? ApiColumnHash { get; set; }

    /// <summary>
    /// 返却される項目を制御する配列
    /// </summary>
    [JsonProperty("GridColumns")]
    public List<string>? GridColumns { get; set; }

    /// <summary>
    /// セッションのフィルタ条件とマージするか
    /// </summary>
    [JsonProperty("MergeSessionViewFilters")]
    public bool? MergeSessionViewFilters { get; set; }

    /// <summary>
    /// セッションのソート条件とマージするか
    /// </summary>
    [JsonProperty("MergeSessionViewSorters")]
    public bool? MergeSessionViewSorters { get; set; }
}
