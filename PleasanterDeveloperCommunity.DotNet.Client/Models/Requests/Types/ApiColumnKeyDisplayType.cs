using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// APIカラムキー表示タイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiColumnKeyDisplayType
{
    /// <summary>
    /// 表示名
    /// </summary>
    [EnumMember(Value = "LabelText")]
    LabelText,

    /// <summary>
    /// カラム名
    /// </summary>
    [EnumMember(Value = "ColumnName")]
    ColumnName
}
