using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Demo;

/// <summary>
/// デモ登録レスポンス
/// </summary>
public class RegisterDemoResponse
{
    /// <summary>
    /// デモID
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
