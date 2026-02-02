using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// レコード作成レスポンス
/// </summary>
public class CreateRecordResponse
{
    /// <summary>
    /// 作成されたレコードID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// ステータスコード
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 1日あたりのAPI制限数
    /// </summary>
    public int? LimitPerDate { get; set; }

    /// <summary>
    /// API残数
    /// </summary>
    public int? LimitRemaining { get; set; }
}
