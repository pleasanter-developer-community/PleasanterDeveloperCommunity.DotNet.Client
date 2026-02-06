using System;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Responses.Utility;

/// <summary>
/// ライセンス情報取得レスポンス
/// </summary>
public class GetLicenseInfoResponse
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
    public string? LicenseName { get; set; }

    /// <summary>
    /// ライセンシー
    /// </summary>
    public string? Licensee { get; set; }

    /// <summary>
    /// 有効期限
    /// </summary>
    public DateTime? Expiration { get; set; }

    /// <summary>
    /// ユーザ数上限
    /// </summary>
    public int? UserLimit { get; set; }

    /// <summary>
    /// サイト数上限
    /// </summary>
    public int? SiteLimit { get; set; }
}
