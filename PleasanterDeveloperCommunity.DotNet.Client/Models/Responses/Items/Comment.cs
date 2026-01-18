using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// コメントデータ
/// </summary>
public class Comment
{
    /// <summary>
    /// コメントID
    /// </summary>
    [JsonProperty("CommentId")]
    public long CommentId { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    [JsonProperty("CreatedTime")]
    public string? CreatedTime { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    [JsonProperty("UpdatedTime")]
    public string? UpdatedTime { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    [JsonProperty("Creator")]
    public int Creator { get; set; }

    /// <summary>
    /// コメント本文
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }
}
