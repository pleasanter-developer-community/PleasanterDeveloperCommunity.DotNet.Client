using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// コメントデータ
/// </summary>
public class Comment
{
    /// <summary>
    /// コメントID
    /// </summary>
    [JsonPropertyName("CommentId")]
    public long CommentId { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    [JsonPropertyName("CreatedTime")]
    public string? CreatedTime { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    [JsonPropertyName("UpdatedTime")]
    public string? UpdatedTime { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    [JsonPropertyName("Creator")]
    public int Creator { get; set; }

    /// <summary>
    /// コメント本文
    /// </summary>
    [JsonPropertyName("Body")]
    public string? Body { get; set; }
}
