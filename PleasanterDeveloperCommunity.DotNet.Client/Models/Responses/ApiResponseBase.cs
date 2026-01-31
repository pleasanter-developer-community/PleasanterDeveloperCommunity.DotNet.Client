using System.Net;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// APIレスポンス基底クラス
/// </summary>
/// <typeparam name="T">レスポンスデータの型</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// HTTPステータスコード
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// レスポンスメッセージ
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    public T? Response { get; set; }

    /// <summary>
    /// 成功したかどうか
    /// </summary>
    public bool IsSuccess => StatusCode == HttpStatusCode.OK;
}
