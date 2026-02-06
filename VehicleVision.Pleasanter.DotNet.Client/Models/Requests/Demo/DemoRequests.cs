using VehicleVision.Pleasanter.DotNet.Client.Models.Requests;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Demo;

/// <summary>
/// デモ登録リクエスト
/// </summary>
public class RegisterDemoRequest : ApiRequestBase
{
    /// <summary>
    /// メールアドレス
    /// </summary>
    public string? MailAddress { get; set; }
}
