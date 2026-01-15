using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコード作成レスポンス
/// </summary>
public class CreateRecordResponse
{
    /// <summary>
    /// レコードID
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
