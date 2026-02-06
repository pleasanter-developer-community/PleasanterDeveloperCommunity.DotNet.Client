using System.Text.Json.Serialization;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Binaries;

/// <summary>
/// バイナリアップロードレスポンス
/// </summary>
public class UploadBinaryResponse
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
    [JsonPropertyName("Guid")]
    public string? FileGuid { get; set; }
}
