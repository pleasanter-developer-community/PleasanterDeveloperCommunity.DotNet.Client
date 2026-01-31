using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Binaries
{
    /// <summary>
    /// バイナリアップロードレスポンス
    /// </summary>
    public class UploadBinaryResponse
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
        public string? Guid { get; set; }
    }
}
