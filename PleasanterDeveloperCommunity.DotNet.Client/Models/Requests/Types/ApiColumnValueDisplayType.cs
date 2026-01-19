using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// APIカラム値表示タイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiColumnValueDisplayType
{
    /// <summary>
    /// 表示名
    /// </summary>
    [EnumMember(Value = "DisplayValue")]
    DisplayValue,

    /// <summary>
    /// 値（データベース上に登録されている値）
    /// </summary>
    [EnumMember(Value = "Value")]
    Value,

    /// <summary>
    /// 書式や単位等も含めた値
    /// </summary>
    [EnumMember(Value = "Text")]
    Text
}
