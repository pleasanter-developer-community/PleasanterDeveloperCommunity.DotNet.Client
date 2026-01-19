using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// ページネーション情報を持つレスポンスの基底クラス
/// </summary>
/// <typeparam name="T">データ項目の型</typeparam>
public abstract class PaginatedResponseBase<T>
{
    /// <summary>
    /// オフセット
    /// </summary>
    [JsonPropertyName("Offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// ページサイズ
    /// </summary>
    [JsonPropertyName("PageSize")]
    public int? PageSize { get; set; }

    /// <summary>
    /// 合計レコード数
    /// </summary>
    [JsonPropertyName("TotalCount")]
    public int? TotalCount { get; set; }

    /// <summary>
    /// レスポンスデータリスト
    /// </summary>
    [JsonPropertyName("Data")]
    public List<T>? Data { get; set; }

    /// <summary>
    /// 次のページが存在するかを判定します
    /// </summary>
    public bool HasNextPage => Offset.HasValue && PageSize.HasValue && TotalCount.HasValue
        && (Offset.Value + PageSize.Value) < TotalCount.Value;
}
