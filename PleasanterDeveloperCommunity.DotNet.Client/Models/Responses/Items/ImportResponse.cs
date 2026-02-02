using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// インポートレスポンス
/// </summary>
public class ImportResponse
{
    /// <summary>
    /// ID
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
