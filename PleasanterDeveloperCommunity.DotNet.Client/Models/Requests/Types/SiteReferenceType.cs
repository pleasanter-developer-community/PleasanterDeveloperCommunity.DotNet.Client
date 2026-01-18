using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Types;

/// <summary>
/// サイトの参照タイプ
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SiteReferenceType
{
    /// <summary>
    /// フォルダ
    /// </summary>
    [EnumMember(Value = "Sites")]
    Sites,

    /// <summary>
    /// 期限付きテーブル
    /// </summary>
    [EnumMember(Value = "Issues")]
    Issues,

    /// <summary>
    /// 記録テーブル
    /// </summary>
    [EnumMember(Value = "Results")]
    Results,

    /// <summary>
    /// Wiki
    /// </summary>
    [EnumMember(Value = "Wikis")]
    Wikis
}
