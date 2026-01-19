using Newtonsoft.Json;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// リストデータを持つレスポンスの基底クラス
/// </summary>
/// <typeparam name="T">データ項目の型</typeparam>
public abstract class ListDataResponseBase<T>
{
    /// <summary>
    /// レスポンスデータリスト
    /// </summary>
    [JsonProperty("Data")]
    public List<T>? Data { get; set; }
}
