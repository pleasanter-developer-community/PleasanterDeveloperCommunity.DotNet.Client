using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;
using PleasanterDeveloperCommunity.DotNet.Client.Resources;
using PleasanterDeveloperCommunity.DotNet.Client.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// ビュー設定
/// </summary>
public class View
{
    /// <summary>
    /// 未完了
    /// </summary>
    [JsonProperty("Incomplete")]
    public bool? Incomplete { get; set; }

    /// <summary>
    /// 自分
    /// </summary>
    [JsonProperty("Own")]
    public bool? Own { get; set; }

    /// <summary>
    /// 期限が近い
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
    /// 検索
    /// </summary>
    [JsonProperty("Search")]
    public string? Search { get; set; }

    /// <summary>
    /// 取得する列名のフィルタ設定
    /// </summary>
    [JsonProperty("ColumnFilterHash")]
    [RegexKeyDictionary(ColumnPatterns.GridColumnNamePattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.ColumnFilterHashKeyError))]
    public Dictionary<string, string>? ColumnFilterHash { get; set; }

    /// <summary>
    /// 列フィルタ検索タイプ
    /// </summary>
    [JsonProperty("ColumnFilterSearchTypes")]
    [RegexKeyDictionary(ColumnPatterns.GridColumnNamePattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.ColumnFilterSearchTypesKeyError))]
    public Dictionary<string, ColumnFilterSearchType>? ColumnFilterSearchTypes { get; set; }

    /// <summary>
    /// 否定フィルタ対象の列名
    /// </summary>
    [JsonProperty("ColumnFilterNegatives")]
    [RegexList(ColumnPatterns.GridColumnNamePattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.ColumnFilterNegativesValueError))]
    public List<string>? ColumnFilterNegatives { get; set; }

    /// <summary>
    /// ソートする列名（キー: 列名、値: "asc" または "desc"）
    /// </summary>
    [JsonProperty("ColumnSorterHash")]
    [RegexKeyDictionary(ColumnPatterns.GridColumnNamePattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.ColumnSorterHashKeyError))]
    public Dictionary<string, SortOrderType>? ColumnSorterHash { get; set; }

    /// <summary>
    /// APIデータタイプ
    /// </summary>
    [JsonProperty("ApiDataType")]
    public ApiDataType? ApiDataType { get; set; }

    /// <summary>
    /// APIカラムキー表示タイプ（ApiDataTypeがKeyValuesの場合のみ有効）
    /// </summary>
    [JsonProperty("ApiColumnKeyDisplayType")]
    public ApiColumnKeyDisplayType? ApiColumnKeyDisplayType { get; set; }

    /// <summary>
    /// APIカラム値表示タイプ（ApiDataTypeがKeyValuesの場合のみ有効）
    /// </summary>
    [JsonProperty("ApiColumnValueDisplayType")]
    public ApiColumnValueDisplayType? ApiColumnValueDisplayType { get; set; }

    /// <summary>
    /// 項目単位のKey、Value表示形式設定（ApiDataTypeがKeyValuesの場合のみ有効）
    /// </summary>
    [JsonProperty("ApiColumnHash")]
    [RegexKeyDictionary(ColumnPatterns.ColumnNamePattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.ApiColumnHashKeyError))]
    public Dictionary<string, ApiColumnSetting>? ApiColumnHash { get; set; }

    /// <summary>
    /// 返却される項目を制御する配列（ApiDataTypeがKeyValuesの場合のみ有効）
    /// </summary>
    [JsonProperty("GridColumns")]
    [RegexList(ColumnPatterns.GridColumnNamePattern, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.GridColumnsValueError))]
    public List<string>? GridColumns { get; set; }

    /// <summary>
    /// APIで指定したフィルタ条件とセッションに存在するフィルタ条件をマージするかどうか
    /// </summary>
    [JsonProperty("MergeSessionViewFilters")]
    public bool? MergeSessionViewFilters { get; set; }

    /// <summary>
    /// APIで指定したソート条件とセッションに存在するソート条件をマージするかどうか
    /// </summary>
    [JsonProperty("MergeSessionViewSorters")]
    public bool? MergeSessionViewSorters { get; set; }

    /// <summary>
    /// カスタム列名パターンでViewを作成します
    /// </summary>
    /// <param name="columnFilterHash">フィルタ設定</param>
    /// <param name="columnSorterHash">ソート設定</param>
    /// <param name="customPattern">カスタム正規表現パターン（nullの場合は検証なし）</param>
    /// <returns>検証済みのViewインスタンス</returns>
    public static View CreateWithValidation(
        Dictionary<string, string>? columnFilterHash = null,
        Dictionary<string, SortOrderType>? columnSorterHash = null,
        string? customPattern = null)
    {
        var view = new View
        {
            ColumnFilterHash = columnFilterHash,
            ColumnSorterHash = columnSorterHash
        };

        if (customPattern is null)
        {
            return view;
        }

        var validator = new RegexKeyDictionaryAttribute(customPattern);

        if (columnFilterHash is not null)
        {
            var filterResult = validator.GetValidationResult(columnFilterHash, new ValidationContext(columnFilterHash) { MemberName = nameof(ColumnFilterHash) });
            if (filterResult != ValidationResult.Success)
            {
                throw new ArgumentException(filterResult?.ErrorMessage, nameof(columnFilterHash));
            }
        }

        if (columnSorterHash is not null)
        {
            var sorterResult = validator.GetValidationResult(columnSorterHash, new ValidationContext(columnSorterHash) { MemberName = nameof(ColumnSorterHash) });
            if (sorterResult != ValidationResult.Success)
            {
                throw new ArgumentException(sorterResult?.ErrorMessage, nameof(columnSorterHash));
            }
        }

        return view;
    }
}
