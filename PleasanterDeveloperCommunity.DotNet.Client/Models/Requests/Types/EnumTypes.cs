using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// ソート順タイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SortOrderType
{
    Asc,
    Desc
}

/// <summary>
/// 列フィルタ検索タイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
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
[JsonConverter(typeof(StringEnumConverter))]
public enum ApiDataType
{
    Default,
    KeyValues
}

/// <summary>
/// APIカラムキー表示タイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ApiColumnKeyDisplayType
{
    LabelText,
    ColumnName
}

/// <summary>
/// APIカラム値表示タイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ApiColumnValueDisplayType
{
    DisplayValue,
    Value,
    Text
}

/// <summary>
/// サイト参照タイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
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
[JsonConverter(typeof(StringEnumConverter))]
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
    [JsonProperty("KeyDisplayType")]
    public ApiColumnKeyDisplayType? KeyDisplayType { get; set; }

    [JsonProperty("ValueDisplayType")]
    public ApiColumnValueDisplayType? ValueDisplayType { get; set; }
}
