namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// エクスポートレスポンス
/// </summary>
public class ExportResponse
{
    /// <summary>
    /// エクスポート名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// エクスポートされたコンテンツ
    /// </summary>
    public string? Content { get; set; }
}
