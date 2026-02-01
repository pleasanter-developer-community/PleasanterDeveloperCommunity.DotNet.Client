using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// ソート順タイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortOrderType
{
    Asc,
    Desc
}

/// <summary>
/// 列フィルタ検索タイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ColumnFilterSearchType
{
    PartialMatch,
    ExactMatch,
    ForwardMatch,
    PartialMatchMultiple,
    ExactMatchMultiple,
    ForwardMatchMultiple
}

/// <summary>
/// APIデータタイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiDataType
{
    Default,
    KeyValues
}

/// <summary>
/// APIカラムキー表示タイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiColumnKeyDisplayType
{
    LabelText,
    ColumnName
}

/// <summary>
/// APIカラム値表示タイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiColumnValueDisplayType
{
    DisplayValue,
    Value,
    Text
}

/// <summary>
/// サイト参照タイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SiteReferenceType
{
    Sites,
    Issues,
    Results,
    Wikis
}

/// <summary>
/// エクスポートタイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExportType
{
    Csv,
    Json
}

/// <summary>
/// APIカラム設定
/// </summary>
public class ApiColumnSetting
{
    [JsonPropertyName("KeyDisplayType")]
    public ApiColumnKeyDisplayType? KeyDisplayType { get; set; }

    [JsonPropertyName("ValueDisplayType")]
    public ApiColumnValueDisplayType? ValueDisplayType { get; set; }
}
