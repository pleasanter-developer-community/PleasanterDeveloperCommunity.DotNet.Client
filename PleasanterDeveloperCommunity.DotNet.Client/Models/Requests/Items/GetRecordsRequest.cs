namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// 複数レコード取得リクエスト
/// </summary>
public class GetRecordsRequest : ApiRequestBase
{
    /// <summary>
    /// オフセット
    /// </summary>
    public int? Offset { get; set; }

    /// <summary>
    /// ビュー設定
    /// </summary>
    public View? View { get; set; }
}
