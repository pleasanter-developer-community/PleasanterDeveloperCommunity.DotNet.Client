using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// 列フィルタ検索タイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ColumnFilterSearchType
{
    /// <summary>
    /// 部分一致
    /// </summary>
    [EnumMember(Value = "PartialMatch")]
    PartialMatch,

    /// <summary>
    /// 完全一致
    /// </summary>
    [EnumMember(Value = "ExactMatch")]
    ExactMatch,

    /// <summary>
    /// 前方一致
    /// </summary>
    [EnumMember(Value = "ForwardMatch")]
    ForwardMatch,

    /// <summary>
    /// 部分一致（複数）
    /// </summary>
    [EnumMember(Value = "PartialMatchMultiple")]
    PartialMatchMultiple,

    /// <summary>
    /// 完全一致（複数）
    /// </summary>
    [EnumMember(Value = "ExactMatchMultiple")]
    ExactMatchMultiple,

    /// <summary>
    /// 前方一致（複数）
    /// </summary>
    [EnumMember(Value = "ForwardMatchMultiple")]
    ForwardMatchMultiple
}
