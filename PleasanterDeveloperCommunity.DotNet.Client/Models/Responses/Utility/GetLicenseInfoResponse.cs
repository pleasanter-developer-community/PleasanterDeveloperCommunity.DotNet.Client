using System;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Utility;

/// <summary>
/// ライセンス情報取得レスポンス
/// </summary>
public class GetLicenseInfoResponse
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
    [JsonProperty("Data")]
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
    [JsonProperty("LicenseName")]
    public string? LicenseName { get; set; }

    /// <summary>
    /// ライセンシー
    /// </summary>
    [JsonProperty("Licensee")]
    public string? Licensee { get; set; }

    /// <summary>
    /// 有効期限
    /// </summary>
    [JsonProperty("Expiration")]
    public DateTime? Expiration { get; set; }

    /// <summary>
    /// ユーザ数上限
    /// </summary>
    [JsonProperty("UserLimit")]
    public int? UserLimit { get; set; }

    /// <summary>
    /// サイト数上限
    /// </summary>
    [JsonProperty("SiteLimit")]
    public int? SiteLimit { get; set; }
}
