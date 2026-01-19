using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// エクスポートファイルタイプ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
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
