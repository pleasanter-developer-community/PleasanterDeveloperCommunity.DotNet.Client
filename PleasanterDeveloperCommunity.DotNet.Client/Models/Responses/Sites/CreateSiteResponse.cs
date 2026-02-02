using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Sites;

/// <summary>
/// サイト作成レスポンス
/// </summary>
public class CreateSiteResponse
{
    /// <summary>
    /// 作成されたサイトID
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
}
