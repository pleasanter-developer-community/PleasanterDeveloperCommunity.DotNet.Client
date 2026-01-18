using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// テーブルエクスポートリクエスト
/// </summary>
public class ExportRequest : ApiRequest
{
    /// <summary>
    /// エクスポート設定のID（プリザンターで作成済みのエクスポート設定を使用する場合）
    /// </summary>
    [JsonProperty("ExportId")]
    public int? ExportId { get; set; }

    /// <summary>
    /// エクスポート設定（設定を直接記述する場合）
    /// </summary>
    [JsonProperty("Export")]
    public ExportSetting? Export { get; set; }

    /// <summary>
    /// ビュー設定（取得するレコードの絞り込みや並び順を指定）
    /// </summary>
    [JsonProperty("View")]
    public View? View { get; set; }
}
