using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace pleasanter_dotnet_client.Models.Requests.Types;

/// <summary>
/// ソート順タイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
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
