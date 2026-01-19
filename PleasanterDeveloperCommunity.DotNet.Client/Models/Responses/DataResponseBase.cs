using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// 単一データを持つレスポンスの基底クラス
/// </summary>
/// <typeparam name="T">データの型</typeparam>
public abstract class DataResponseBase<T>
{
    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonPropertyName("Data")]
    public T? Data { get; set; }
}
