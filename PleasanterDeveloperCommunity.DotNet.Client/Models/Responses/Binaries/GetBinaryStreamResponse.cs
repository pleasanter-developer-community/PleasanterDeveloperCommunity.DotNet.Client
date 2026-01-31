using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Binaries
{
    /// <summary>
    /// バイナリストリーム取得レスポンス
    /// </summary>
    public class GetBinaryStreamResponse
    {
        /// <summary>
        /// ステータスコード
        /// </summary>
        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        /// <summary>
        /// レスポンスデータ
        /// </summary>
        [JsonPropertyName("Response")]
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
        [JsonPropertyName("Base64")]
        public string? Base64 { get; set; }

        /// <summary>
        /// コンテンツタイプ
        /// </summary>
        [JsonPropertyName("ContentType")]
        public string? ContentType { get; set; }

        /// <summary>
        /// ファイル名
        /// </summary>
        [JsonPropertyName("FileName")]
        public string? FileName { get; set; }
    }
}
