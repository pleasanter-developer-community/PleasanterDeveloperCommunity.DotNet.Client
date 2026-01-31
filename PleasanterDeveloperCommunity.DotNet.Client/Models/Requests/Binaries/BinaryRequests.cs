using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Binaries
{
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
        [JsonPropertyName("FileName")]
        public string? FileName { get; set; }

        /// <summary>
        /// Base64エンコードされたファイルデータ
        /// </summary>
        [JsonPropertyName("Base64")]
        public string? Base64 { get; set; }

        /// <summary>
        /// コンテンツタイプ
        /// </summary>
        [JsonPropertyName("ContentType")]
        public string? ContentType { get; set; }
    }
}
