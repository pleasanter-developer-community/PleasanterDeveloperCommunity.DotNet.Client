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
    [JsonProperty("StatusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonProperty("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonProperty("Response")]
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
    [JsonProperty("Base64")]
    public string? Base64 { get; set; }

    /// <summary>
    /// コンテンツタイプ
    /// </summary>
    [JsonProperty("ContentType")]
    public string? ContentType { get; set; }

    /// <summary>
    /// ファイル名
    /// </summary>
    [JsonProperty("FileName")]
    public string? FileName { get; set; }
}
