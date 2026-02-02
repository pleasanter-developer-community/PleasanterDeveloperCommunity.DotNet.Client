using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Groups;

/// <summary>
/// グループ削除レスポンス
/// </summary>
public class DeleteGroupResponse
{
    /// <summary>
    /// 削除されたグループID
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
