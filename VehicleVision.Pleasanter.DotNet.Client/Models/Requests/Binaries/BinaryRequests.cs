namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Binaries;

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
    public string? FileName { get; set; }

    /// <summary>
    /// Base64エンコードされたファイルデータ
    /// </summary>
    public string? Base64 { get; set; }

    /// <summary>
    /// コンテンツタイプ
    /// </summary>
    public string? ContentType { get; set; }
}
