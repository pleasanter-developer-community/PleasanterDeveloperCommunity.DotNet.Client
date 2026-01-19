using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// APIデータタイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
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
