using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Demo
{
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
}
