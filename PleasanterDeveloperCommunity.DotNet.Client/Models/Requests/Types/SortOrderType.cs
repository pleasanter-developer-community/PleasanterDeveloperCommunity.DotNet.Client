using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// ソート順タイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortOrderType
{
    /// <summary>
    /// 昇順
    /// </summary>
    [EnumMember(Value = "asc")]
    Asc,

    /// <summary>
    /// 降順
    /// </summary>
    [EnumMember(Value = "desc")]
    Desc
}
