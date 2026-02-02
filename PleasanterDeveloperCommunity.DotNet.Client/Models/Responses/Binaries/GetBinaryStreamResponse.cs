using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Binaries;

/// <summary>
/// バイナリストリーム取得レスポンス
/// </summary>
public class GetBinaryStreamResponse
{
    /// <summary>
    /// ステータスコード
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    public BinaryStreamResponseData? Response { get; set; }
}

/// <summary>
/// バイナリストリームレスポンスデータ
/// </summary>
public class BinaryStreamResponseData
{
    /// <summary>
    /// Base64エンコードされたバイナリデータ
    /// </summary>
    public string? Base64 { get; set; }

    /// <summary>
    /// コンテンツタイプ
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// ファイル名
    /// </summary>
    public string? FileName { get; set; }
}
