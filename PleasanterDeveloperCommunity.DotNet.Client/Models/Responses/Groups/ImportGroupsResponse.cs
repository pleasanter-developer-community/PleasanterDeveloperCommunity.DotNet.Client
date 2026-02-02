using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループインポートレスポンス
/// </summary>
public class ImportGroupsResponse
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ステータスコード
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    public string? Message { get; set; }
}
