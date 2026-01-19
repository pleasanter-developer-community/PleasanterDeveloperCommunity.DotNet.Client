using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// IDを持つレスポンスの基底クラス
/// </summary>
public abstract class IdResponseBase : ApiLimitInfoBase
{
    /// <summary>
    /// ID（レコードIDまたはサイトID）
    /// </summary>
    [JsonProperty("Id")]
    public long Id { get; set; }
}
