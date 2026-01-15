using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコード操作レスポンスの基底クラス
/// </summary>
public abstract class RecordOperationResponseBase
{
    /// <summary>
    /// ID（レコードIDまたはサイトID）
    /// </summary>
    [JsonProperty("Id")]
    public long Id { get; set; }

    /// <summary>
    /// 1日あたりのAPI呼び出し上限
    /// </summary>
    [JsonProperty("LimitPerDate")]
    public int? LimitPerDate { get; set; }

    /// <summary>
    /// 残りのAPI呼び出し回数
    /// </summary>
    [JsonProperty("LimitRemaining")]
    public int? LimitRemaining { get; set; }
}
