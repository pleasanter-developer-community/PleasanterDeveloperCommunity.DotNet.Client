using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// IDを持つレスポンスの基底クラス
/// </summary>
public abstract class IdResponseBase : ApiLimitInfoBase
{
    /// <summary>
    /// ID（レコードIDまたはサイトID）
    /// </summary>
    [JsonPropertyName("Id")]
    public long Id { get; set; }
}
