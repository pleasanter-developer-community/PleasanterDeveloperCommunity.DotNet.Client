using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// Upsertレスポンス
/// </summary>
public class UpsertRecordResponse
{
    /// <summary>
    /// レコードID
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
    /// 新規作成されたかどうか
    /// </summary>
    public bool Created { get; set; }
}
