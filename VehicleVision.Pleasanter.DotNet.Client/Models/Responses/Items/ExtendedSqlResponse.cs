using System.Collections.Generic;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 拡張SQL実行レスポンス
/// </summary>
public class ExtendedSqlResponse
{
    /// <summary>
    /// 実行結果データ
    /// </summary>
    public List<Dictionary<string, object>>? Data { get; set; }
}
