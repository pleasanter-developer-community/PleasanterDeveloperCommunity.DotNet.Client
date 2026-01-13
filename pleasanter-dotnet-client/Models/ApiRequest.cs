using Newtonsoft.Json;
using pleasanter_dotnet_client.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pleasanter_dotnet_client.Models;

/// <summary>
/// APIリクエストの基底クラス
/// </summary>
public class ApiRequest
{
    /// <summary>
    /// APIバージョン（1.1固定）
    /// </summary>
    [JsonProperty("ApiVersion")]
    public string ApiVersion { get; } = "1.1";

    /// <summary>
    /// APIキー
    /// </summary>
    [JsonProperty("ApiKey")]
    public string? ApiKey { get; set; }
}

/// <summary>
/// レコード取得リクエスト
/// </summary>
public class GetRecordRequest : ApiRequest
{
    /// <summary>
    /// ビュー設定（フィルタや並び替えなど）
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}

/// <summary>
/// 複数レコード取得リクエスト
/// </summary>
public class GetRecordsRequest : ApiRequest
{
    /// <summary>
    /// オフセット（取得開始位置）
    /// </summary>
    [JsonProperty("Offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// ビュー設定（フィルタや並び替えなど）
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}

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
    /// 取得する列名のフィルタ設定
    /// </summary>
    [JsonProperty("ColumnFilterHash")]
    [RegexKeyDictionary(ColumnNamePattern, ErrorMessage = "ColumnFilterHash のキーはプリザンターの有効な列名である必要があります。")]
    public Dictionary<string, string>? ColumnFilterHash { get; set; }

    /// <summary>
    /// ソートする列名（キー: 列名、値: "asc" または "desc"）
    /// </summary>
    [JsonProperty("ColumnSorterHash")]
    [RegexKeyDictionary(ColumnNamePattern, ErrorMessage = "ColumnSorterHash のキーはプリザンターの有効な列名である必要があります。")]
    public Dictionary<string, string>? ColumnSorterHash { get; set; }

    /// <summary>
    /// カスタム列名パターンでViewを作成します
    /// </summary>
    /// <param name="columnFilterHash">フィルタ設定</param>
    /// <param name="columnSorterHash">ソート設定</param>
    /// <param name="customPattern">カスタム正規表現パターン（nullの場合は検証なし）</param>
    /// <returns>検証済みのViewインスタンス</returns>
    public static View CreateWithValidation(
        Dictionary<string, string>? columnFilterHash = null,
        Dictionary<string, string>? columnSorterHash = null,
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
