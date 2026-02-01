using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Binaries;

/// <summary>
/// バイナリストリーム取得リクエスト
/// </summary>
public class GetBinaryStreamRequest : ApiRequestBase
{
}

/// <summary>
/// バイナリアップロードリクエスト
/// </summary>
public class UploadBinaryRequest : ApiRequestBase
{
    /// <summary>
    /// ファイル名
    /// </summary>
    [JsonProperty("FileName")]
    public string? FileName { get; set; }

    /// <summary>
    /// Base64エンコードされたファイルデータ
    /// </summary>
    [JsonProperty("Base64")]
    public string? Base64 { get; set; }

    /// <summary>
    /// コンテンツタイプ
    /// </summary>
    [JsonProperty("ContentType")]
    public string? ContentType { get; set; }
}
