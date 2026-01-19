using System.Text.Json.Serialization;
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
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// デフォルトのモード
        /// </summary>
        [JsonPropertyName("DefaultMode")]
        public string? DefaultMode { get; set; }

        /// <summary>
        /// 一覧の列
        /// </summary>
        [JsonPropertyName("GridColumns")]
        public List<string>? GridColumns { get; set; }

        /// <summary>
        /// フィルタの列
        /// </summary>
        [JsonPropertyName("FilterColumns")]
        public List<string>? FilterColumns { get; set; }

        /// <summary>
        /// 列フィルタハッシュ
        /// </summary>
        [JsonPropertyName("ColumnFilterHash")]
        public Dictionary<string, string>? ColumnFilterHash { get; set; }

        /// <summary>
        /// 列フィルタ否定ハッシュ
        /// </summary>
        [JsonPropertyName("ColumnFilterNegatives")]
        public List<string>? ColumnFilterNegatives { get; set; }

        /// <summary>
        /// 列フィルタ式
        /// </summary>
        [JsonPropertyName("ColumnFilterExpressions")]
        public Dictionary<string, string>? ColumnFilterExpressions { get; set; }

        /// <summary>
        /// 列ソーターハッシュ
        /// </summary>
        [JsonPropertyName("ColumnSorterHash")]
        public Dictionary<string, string>? ColumnSorterHash { get; set; }

        /// <summary>
        /// 検索テキスト
        /// </summary>
        [JsonPropertyName("Search")]
        public string? Search { get; set; }

        /// <summary>
        /// 未完了
        /// </summary>
        [JsonPropertyName("Incomplete")]
        public bool? Incomplete { get; set; }

        /// <summary>
        /// 自分のみ
        /// </summary>
        [JsonPropertyName("Own")]
        public bool? Own { get; set; }

        /// <summary>
        /// 近く完了
        /// </summary>
        [JsonPropertyName("NearCompletionTime")]
        public bool? NearCompletionTime { get; set; }

        /// <summary>
        /// 遅延
        /// </summary>
        [JsonPropertyName("Delay")]
        public bool? Delay { get; set; }

        /// <summary>
        /// 期限超過
        /// </summary>
        [JsonPropertyName("Overdue")]
        public bool? Overdue { get; set; }

        /// <summary>
        /// 表示する列数
        /// </summary>
        [JsonPropertyName("ShowHistory")]
        public bool? ShowHistory { get; set; }

        /// <summary>
        /// カレンダーのグループ化
        /// </summary>
        [JsonPropertyName("CalendarGroupBy")]
        public string? CalendarGroupBy { get; set; }

        /// <summary>
        /// カレンダーの期間種類
        /// </summary>
        [JsonPropertyName("CalendarTimePeriod")]
        public string? CalendarTimePeriod { get; set; }

        /// <summary>
        /// カレンダーの列
        /// </summary>
        [JsonPropertyName("CalendarColumn")]
        public string? CalendarColumn { get; set; }

        /// <summary>
        /// カレンダーのビュー種類
        /// </summary>
        [JsonPropertyName("CalendarViewType")]
        public string? CalendarViewType { get; set; }

        /// <summary>
        /// クロス集計のグループ化（X軸）
        /// </summary>
        [JsonPropertyName("CrosstabGroupByX")]
        public string? CrosstabGroupByX { get; set; }

        /// <summary>
        /// クロス集計のグループ化（Y軸）
        /// </summary>
        [JsonPropertyName("CrosstabGroupByY")]
        public string? CrosstabGroupByY { get; set; }

        /// <summary>
        /// クロス集計の列
        /// </summary>
        [JsonPropertyName("CrosstabColumns")]
        public string? CrosstabColumns { get; set; }

        /// <summary>
        /// クロス集計の集計種類
        /// </summary>
        [JsonPropertyName("CrosstabAggregationType")]
        public string? CrosstabAggregationType { get; set; }

        /// <summary>
        /// クロス集計の値
        /// </summary>
        [JsonPropertyName("CrosstabValue")]
        public string? CrosstabValue { get; set; }

        /// <summary>
        /// クロス集計の期間種類
        /// </summary>
        [JsonPropertyName("CrosstabTimePeriod")]
        public string? CrosstabTimePeriod { get; set; }

        /// <summary>
        /// ガントチャートのグループ化
        /// </summary>
        [JsonPropertyName("GanttGroupBy")]
        public string? GanttGroupBy { get; set; }

        /// <summary>
        /// ガントチャートのソート
        /// </summary>
        [JsonPropertyName("GanttSortBy")]
        public string? GanttSortBy { get; set; }

        /// <summary>
        /// 時系列のグループ化
        /// </summary>
        [JsonPropertyName("TimeSeriesGroupBy")]
        public string? TimeSeriesGroupBy { get; set; }

        /// <summary>
        /// 時系列の集計種類
        /// </summary>
        [JsonPropertyName("TimeSeriesAggregationType")]
        public string? TimeSeriesAggregationType { get; set; }

        /// <summary>
        /// 時系列の値
        /// </summary>
        [JsonPropertyName("TimeSeriesValue")]
        public string? TimeSeriesValue { get; set; }

        /// <summary>
        /// カンバンのグループ化
        /// </summary>
        [JsonPropertyName("KambanGroupBy")]
        public string? KambanGroupBy { get; set; }

        /// <summary>
        /// カンバンの集計種類
        /// </summary>
        [JsonPropertyName("KambanAggregationType")]
        public string? KambanAggregationType { get; set; }

        /// <summary>
        /// カンバンの値
        /// </summary>
        [JsonPropertyName("KambanValue")]
        public string? KambanValue { get; set; }

        /// <summary>
        /// カンバンの列
        /// </summary>
        [JsonPropertyName("KambanColumns")]
        public int? KambanColumns { get; set; }

        /// <summary>
        /// ロックされている
        /// </summary>
        [JsonPropertyName("Locked")]
        public bool? Locked { get; set; }
    }
}
