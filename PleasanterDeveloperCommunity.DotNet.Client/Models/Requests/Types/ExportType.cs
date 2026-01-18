using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// エクスポートファイルタイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ExportType
{
    /// <summary>
    /// CSV形式
    /// </summary>
    [EnumMember(Value = "csv")]
    Csv,

    /// <summary>
    /// JSON形式
    /// </summary>
    [EnumMember(Value = "json")]
    Json
}
