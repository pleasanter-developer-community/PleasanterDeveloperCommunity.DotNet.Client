using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織更新レスポンス
/// </summary>
public class UpdateDeptResponse
{
    /// <summary>
    /// 更新された組織ID
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
