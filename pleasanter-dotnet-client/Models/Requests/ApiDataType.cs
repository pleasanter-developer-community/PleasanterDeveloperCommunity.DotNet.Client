using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace pleasanter_dotnet_client.Models.Requests;

/// <summary>
/// APIデータタイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ApiDataType
{
    /// <summary>
    /// デフォルト（Keyはカラム名、Valueは値）
    /// </summary>
    [EnumMember(Value = "Default")]
    Default,

    /// <summary>
    /// KeyValues形式（Keyは表示名、Valueは表示値）
    /// </summary>
    [EnumMember(Value = "KeyValues")]
    KeyValues
}
