using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Depts;

/// <summary>
/// 組織作成レスポンス
/// </summary>
public class CreateDeptResponse
{
    /// <summary>
    /// 作成された組織ID
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
