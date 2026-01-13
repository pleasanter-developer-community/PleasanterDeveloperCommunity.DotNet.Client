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
/// レコード作成・更新（Upsert）リクエスト
/// </summary>
public class UpsertRecordRequest : ApiRequest
{
    /// <summary>
    /// キーとなる項目名の配列
    /// </summary>
    [JsonProperty("Keys")]
    [RegexList(View.ColumnNamePattern, ErrorMessage = "Keys の要素はプリザンターの有効な列名である必要があります。")]
    public List<string>? Keys { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// 状況
    /// </summary>
    [JsonProperty("Status")]
    public int? Status { get; set; }

    /// <summary>
    /// 管理者
    /// </summary>
    [JsonProperty("Manager")]
    public int? Manager { get; set; }

    /// <summary>
    /// 担当者
    /// </summary>
    [JsonProperty("Owner")]
    public int? Owner { get; set; }

    /// <summary>
    /// 完了日時
    /// </summary>
    [JsonProperty("CompletionTime")]
    public string? CompletionTime { get; set; }

    /// <summary>
    /// プロセスID
    /// </summary>
    [JsonProperty("ProcessId")]
    public int? ProcessId { get; set; }

    /// <summary>
    /// 複数のプロセスID
    /// </summary>
    [JsonProperty("ProcessIds")]
    public List<int>? ProcessIds { get; set; }

    /// <summary>
    /// 分類項目（ClassA?ClassZ, Class001?Class999）
    /// </summary>
    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目（NumA?NumZ, Num001?Num999）
    /// </summary>
    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目（DateA?DateZ, Date001?Date999）
    /// </summary>
    [JsonProperty("DateHash")]
    public Dictionary<string, string>? DateHash { get; set; }

    /// <summary>
    /// 説明項目（DescriptionA?DescriptionZ, Description001?Description999）
    /// </summary>
    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目（CheckA?CheckZ, Check001?Check999）
    /// </summary>
    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 画像挿入設定
    /// </summary>
    [JsonProperty("ImageHash")]
    public Dictionary<string, ImageSettings>? ImageHash { get; set; }
}

/// <summary>
/// 画像挿入設定
/// </summary>
public class ImageSettings
{
    /// <summary>
    /// 先頭に改行を挿入するか
    /// </summary>
    [JsonProperty("HeadNewLine")]
    public bool? HeadNewLine { get; set; }

    /// <summary>
    /// 末尾に改行を挿入するか
    /// </summary>
    [JsonProperty("EndNewLine")]
    public bool? EndNewLine { get; set; }

    /// <summary>
    /// 画像を挿入する位置（-1または省略で末尾）
    /// </summary>
    [JsonProperty("Position")]
    public int? Position { get; set; }

    /// <summary>
    /// alt属性に設定する文字列
    /// </summary>
    [JsonProperty("Alt")]
    public string? Alt { get; set; }

    /// <summary>
    /// ファイル拡張子（例: .png, .jpeg）
    /// </summary>
    [JsonProperty("Extension")]
    public string? Extension { get; set; }

    /// <summary>
    /// Base64エンコードした画像データ
    /// </summary>
    [JsonProperty("Base64")]
    public string? Base64 { get; set; }
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
