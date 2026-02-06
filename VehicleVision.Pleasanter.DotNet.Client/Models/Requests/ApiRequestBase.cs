namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests;

/// <summary>
/// APIリクエストの基底クラス
/// </summary>
public abstract class ApiRequestBase
{
    /// <summary>
    /// APIバージョン
    /// </summary>
    /// <remarks>
    /// この値はPleasanterClient作成時に設定され、各メソッドでは変更できません。
    /// </remarks>
    public string? ApiVersion { get; internal set; }

    /// <summary>
    /// APIキー
    /// </summary>
    /// <remarks>
    /// この値はPleasanterClient作成時に設定され、各メソッドでは変更できません。
    /// </remarks>
    public string? ApiKey { get; internal set; }
}
