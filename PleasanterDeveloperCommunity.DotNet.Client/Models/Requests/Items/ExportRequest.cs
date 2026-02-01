using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// エクスポートリクエスト
/// </summary>
public class ExportRequest : ApiRequestBase
{
    /// <summary>
    /// エクスポート設定ID
    /// </summary>
    [JsonProperty("ExportId")]
    public int? ExportId { get; set; }

    /// <summary>
    /// エクスポート設定
    /// </summary>
    [JsonProperty("Export")]
    public ExportSetting? Export { get; set; }

    /// <summary>
    /// ビュー設定
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}
