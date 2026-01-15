using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// 拡張SQLのテーブル結果
/// </summary>
public class ExtendedSqlTable
{
    /// <summary>
    /// テーブル名（Table, Table1, Table2...）
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// テーブルの行データ
    /// </summary>
    public List<Dictionary<string, object>> Rows { get; set; } = new List<Dictionary<string, object>>();
}
