using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// API呼び出し制限情報のインターフェース
/// </summary>
public interface IApiLimitInfo
{
    /// <summary>
    /// 1日あたりのAPI呼び出し上限
    /// </summary>
    int? LimitPerDate { get; set; }

    /// <summary>
    /// 残りのAPI呼び出し回数
    /// </summary>
    int? LimitRemaining { get; set; }
}

/// <summary>
/// API呼び出し制限情報を持つレスポンスの基底クラス
/// </summary>
public abstract class ApiLimitInfoBase : IApiLimitInfo
{
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
