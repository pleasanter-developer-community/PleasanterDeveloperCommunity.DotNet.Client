using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Converters;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// 拡張SQLレスポンスのデータ部分
/// </summary>
[JsonConverter(typeof(ExtendedSqlDataConverter))]
public class ExtendedSqlData
{
    /// <summary>
    /// テーブル結果のリスト（Table, Table1, Table2...を順番に格納）
    /// </summary>
    public List<ExtendedSqlTable> Tables { get; set; } = new List<ExtendedSqlTable>();
}
