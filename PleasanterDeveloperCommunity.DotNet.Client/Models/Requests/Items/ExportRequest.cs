namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// エクスポートリクエスト
/// </summary>
public class ExportRequest : ApiRequestBase
{
    /// <summary>
    /// エクスポート設定ID
    /// </summary>
    public int? ExportId { get; set; }

    /// <summary>
    /// エクスポート設定
    /// </summary>
    public ExportSetting? Export { get; set; }

    /// <summary>
    /// ビュー設定
    /// </summary>
    public View? View { get; set; }
}
