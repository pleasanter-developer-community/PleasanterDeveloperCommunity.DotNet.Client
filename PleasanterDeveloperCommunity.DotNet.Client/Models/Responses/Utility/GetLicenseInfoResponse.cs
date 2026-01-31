using System;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Utility
{
    /// <summary>
    /// ライセンス情報取得レスポンス
    /// </summary>
    public class GetLicenseInfoResponse
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
        public LicenseInfoResponseData? Response { get; set; }
    }

    /// <summary>
    /// ライセンス情報レスポンスデータ
    /// </summary>
    public class LicenseInfoResponseData
    {
        /// <summary>
        /// データ
        /// </summary>
        [JsonPropertyName("Data")]
        public LicenseInfoData? Data { get; set; }
    }

    /// <summary>
    /// ライセンス情報データ
    /// </summary>
    public class LicenseInfoData
    {
        /// <summary>
        /// ライセンス名
        /// </summary>
        [JsonPropertyName("LicenseName")]
        public string? LicenseName { get; set; }

        /// <summary>
        /// ライセンシー
        /// </summary>
        [JsonPropertyName("Licensee")]
        public string? Licensee { get; set; }

        /// <summary>
        /// 有効期限
        /// </summary>
        [JsonPropertyName("Expiration")]
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// ユーザ数上限
        /// </summary>
        [JsonPropertyName("UserLimit")]
        public int? UserLimit { get; set; }

        /// <summary>
        /// サイト数上限
        /// </summary>
        [JsonPropertyName("SiteLimit")]
        public int? SiteLimit { get; set; }
    }
}
