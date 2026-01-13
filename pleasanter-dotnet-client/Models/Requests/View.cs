using Newtonsoft.Json;
using pleasanter_dotnet_client.Models.Requests.Types;
using pleasanter_dotnet_client.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pleasanter_dotnet_client.Models.Requests;

/// <summary>
/// ビュー設定
/// </summary>
public class View
{
    /// <summary>
    /// プリザンターの列名パターン（Class[A-Z], Class[001-999], Num[A-Z], Num[001-999], Date[A-Z], Date[001-999], Description[A-Z], Description[001-999], Check[A-Z], Check[001-999], Title, Body, Status など）
    /// </summary>
    public const string ColumnNamePattern = @"^(Class|Num|Date|Description|Check)([A-Z]|[0-9]{3})$|^(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments)$";

    /// <summary>
    /// GridColumns用の列名パターン（通常の列名パターン、またはClass系列名に親テーブル参照形式「Class列名~サイトID,列名」も許可。Class列名~サイトID,は連続指定可能）
    /// </summary>
    public const string GridColumnNamePattern = @"^((Num|Date|Description|Check)([A-Z]|[0-9]{3})|(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments))$|^Class([A-Z]|[0-9]{3})(~[0-9]+,Class([A-Z]|[0-9]{3}))*(~[0-9]+,((Class|Num|Date|Description|Check)([A-Z]|[0-9]{3})|(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments)))?$";

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
    [RegexKeyDictionary(ColumnNamePattern, ErrorMessage = "ColumnFilterHash のキーはプリザンターの有効な列名である必要があります。")]
    public Dictionary<string, string>? ColumnFilterHash { get; set; }

    /// <summary>
    /// 列フィルタ検索タイプ
    /// </summary>
    [JsonProperty("ColumnFilterSearchTypes")]
    [RegexKeyDictionary(ColumnNamePattern, ErrorMessage = "ColumnFilterSearchTypes のキーはプリザンターの有効な列名である必要があります。")]
    public Dictionary<string, ColumnFilterSearchType>? ColumnFilterSearchTypes { get; set; }

    /// <summary>
    /// 否定フィルタ対象の列名
    /// </summary>
    [JsonProperty("ColumnFilterNegatives")]
    [RegexList(ColumnNamePattern, ErrorMessage = "ColumnFilterNegatives の値はプリザンターの有効な列名である必要があります。")]
    public List<string>? ColumnFilterNegatives { get; set; }

    /// <summary>
    /// ソートする列名（キー: 列名、値: "asc" または "desc"）
    /// </summary>
    [JsonProperty("ColumnSorterHash")]
    [RegexKeyDictionary(ColumnNamePattern, ErrorMessage = "ColumnSorterHash のキーはプリザンターの有効な列名である必要があります。")]
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
    [RegexKeyDictionary(ColumnNamePattern, ErrorMessage = "ApiColumnHash のキーはプリザンターの有効な列名である必要があります。")]
    public Dictionary<string, ApiColumnSetting>? ApiColumnHash { get; set; }

    /// <summary>
    /// 返却される項目を制御する配列（ApiDataTypeがKeyValuesの場合のみ有効）
    /// </summary>
    [JsonProperty("GridColumns")]
    [RegexList(GridColumnNamePattern, ErrorMessage = "GridColumns の値はプリザンターの有効な列名である必要があります。")]
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
