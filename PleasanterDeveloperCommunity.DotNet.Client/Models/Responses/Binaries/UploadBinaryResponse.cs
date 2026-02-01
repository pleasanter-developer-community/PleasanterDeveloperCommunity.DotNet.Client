using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Binaries;

/// <summary>
/// バイナリアップロードレスポンス
/// </summary>
public class UploadBinaryResponse
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
    public UploadBinaryResponseData? Response { get; set; }
}

/// <summary>
/// バイナリアップロードレスポンスデータ
/// </summary>
public class UploadBinaryResponseData
{
    /// <summary>
    /// アップロードされたファイルのGUID
    /// </summary>
    [JsonProperty("Guid")]
    public string? Guid { get; set; }
}
