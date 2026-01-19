using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// サイト設定のビューを表すクラスです。
    /// </summary>
    public class SiteSettingsView
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonProperty("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// デフォルトのモード
        /// </summary>
        [JsonProperty("DefaultMode")]
        public string? DefaultMode { get; set; }

        /// <summary>
        /// 一覧の列
        /// </summary>
        [JsonProperty("GridColumns")]
        public List<string>? GridColumns { get; set; }

        /// <summary>
        /// フィルタの列
        /// </summary>
        [JsonProperty("FilterColumns")]
        public List<string>? FilterColumns { get; set; }

        /// <summary>
        /// 列フィルタハッシュ
        /// </summary>
        [JsonProperty("ColumnFilterHash")]
        public Dictionary<string, string>? ColumnFilterHash { get; set; }

        /// <summary>
        /// 列フィルタ否定ハッシュ
        /// </summary>
        [JsonProperty("ColumnFilterNegatives")]
        public List<string>? ColumnFilterNegatives { get; set; }

        /// <summary>
        /// 列フィルタ式
        /// </summary>
        [JsonProperty("ColumnFilterExpressions")]
        public Dictionary<string, string>? ColumnFilterExpressions { get; set; }

        /// <summary>
        /// 列ソーターハッシュ
        /// </summary>
        [JsonProperty("ColumnSorterHash")]
        public Dictionary<string, string>? ColumnSorterHash { get; set; }

        /// <summary>
        /// 検索テキスト
        /// </summary>
        [JsonProperty("Search")]
        public string? Search { get; set; }

        /// <summary>
        /// 未完了
        /// </summary>
        [JsonProperty("Incomplete")]
        public bool? Incomplete { get; set; }

        /// <summary>
        /// 自分のみ
        /// </summary>
        [JsonProperty("Own")]
        public bool? Own { get; set; }

        /// <summary>
        /// 近く完了
        /// </summary>
        [JsonProperty("NearCompletionTime")]
        public bool? NearCompletionTime { get; set; }

        /// <summary>
        /// 遅延
        /// </summary>
        [JsonProperty("Delay")]
        public bool? Delay { get; set; }

        /// <summary>
        /// 期限超過
        /// </summary>
        [JsonProperty("Overdue")]
        public bool? Overdue { get; set; }

        /// <summary>
        /// 表示する列数
        /// </summary>
        [JsonProperty("ShowHistory")]
        public bool? ShowHistory { get; set; }

        /// <summary>
        /// カレンダーのグループ化
        /// </summary>
        [JsonProperty("CalendarGroupBy")]
        public string? CalendarGroupBy { get; set; }

        /// <summary>
        /// カレンダーの期間種類
        /// </summary>
        [JsonProperty("CalendarTimePeriod")]
        public string? CalendarTimePeriod { get; set; }

        /// <summary>
        /// カレンダーの列
        /// </summary>
        [JsonProperty("CalendarColumn")]
        public string? CalendarColumn { get; set; }

        /// <summary>
        /// カレンダーのビュー種類
        /// </summary>
        [JsonProperty("CalendarViewType")]
        public string? CalendarViewType { get; set; }

        /// <summary>
        /// クロス集計のグループ化（X軸）
        /// </summary>
        [JsonProperty("CrosstabGroupByX")]
        public string? CrosstabGroupByX { get; set; }

        /// <summary>
        /// クロス集計のグループ化（Y軸）
        /// </summary>
        [JsonProperty("CrosstabGroupByY")]
        public string? CrosstabGroupByY { get; set; }

        /// <summary>
        /// クロス集計の列
        /// </summary>
        [JsonProperty("CrosstabColumns")]
        public string? CrosstabColumns { get; set; }

        /// <summary>
        /// クロス集計の集計種類
        /// </summary>
        [JsonProperty("CrosstabAggregationType")]
        public string? CrosstabAggregationType { get; set; }

        /// <summary>
        /// クロス集計の値
        /// </summary>
        [JsonProperty("CrosstabValue")]
        public string? CrosstabValue { get; set; }

        /// <summary>
        /// クロス集計の期間種類
        /// </summary>
        [JsonProperty("CrosstabTimePeriod")]
        public string? CrosstabTimePeriod { get; set; }

        /// <summary>
        /// ガントチャートのグループ化
        /// </summary>
        [JsonProperty("GanttGroupBy")]
        public string? GanttGroupBy { get; set; }

        /// <summary>
        /// ガントチャートのソート
        /// </summary>
        [JsonProperty("GanttSortBy")]
        public string? GanttSortBy { get; set; }

        /// <summary>
        /// 時系列のグループ化
        /// </summary>
        [JsonProperty("TimeSeriesGroupBy")]
        public string? TimeSeriesGroupBy { get; set; }

        /// <summary>
        /// 時系列の集計種類
        /// </summary>
        [JsonProperty("TimeSeriesAggregationType")]
        public string? TimeSeriesAggregationType { get; set; }

        /// <summary>
        /// 時系列の値
        /// </summary>
        [JsonProperty("TimeSeriesValue")]
        public string? TimeSeriesValue { get; set; }

        /// <summary>
        /// カンバンのグループ化
        /// </summary>
        [JsonProperty("KambanGroupBy")]
        public string? KambanGroupBy { get; set; }

        /// <summary>
        /// カンバンの集計種類
        /// </summary>
        [JsonProperty("KambanAggregationType")]
        public string? KambanAggregationType { get; set; }

        /// <summary>
        /// カンバンの値
        /// </summary>
        [JsonProperty("KambanValue")]
        public string? KambanValue { get; set; }

        /// <summary>
        /// カンバンの列
        /// </summary>
        [JsonProperty("KambanColumns")]
        public int? KambanColumns { get; set; }

        /// <summary>
        /// ロックされている
        /// </summary>
        [JsonProperty("Locked")]
        public bool? Locked { get; set; }
    }
}
