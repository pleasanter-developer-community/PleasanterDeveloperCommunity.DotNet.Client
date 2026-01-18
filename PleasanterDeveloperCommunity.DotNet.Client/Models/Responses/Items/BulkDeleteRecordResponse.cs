using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコード一括削除レスポンス
/// </summary>
public class BulkDeleteRecordResponse
{
    /// <summary>
    /// 一括削除対象のサイトID
    /// </summary>
    [JsonProperty("Id")]
    public long Id { get; set; }
}
