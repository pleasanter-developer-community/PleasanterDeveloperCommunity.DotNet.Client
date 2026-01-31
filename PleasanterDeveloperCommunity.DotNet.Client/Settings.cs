using System;
using System.Net;
using System.Text;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// プロキシ設定
    /// </summary>
    public class ProxySettings
    {
        private ProxySettings(ProxyType type, string? address = null, IWebProxy? proxy = null,
            string? username = null, string? password = null)
        {
            Type = type;
            Address = address;
            CustomProxy = proxy;
            Username = username;
            Password = password;
        }

        internal enum ProxyType
        {
            SystemDefault,
            NoProxy,
            Custom
        }

        internal ProxyType Type { get; }
        internal string? Address { get; }
        internal IWebProxy? CustomProxy { get; }
        internal string? Username { get; }
        internal string? Password { get; }

        /// <summary>
        /// OS設定のプロキシを使用（デフォルト動作）
        /// </summary>
        public static ProxySettings UseSystemDefault => new ProxySettings(ProxyType.SystemDefault);

        /// <summary>
        /// プロキシを使用しない
        /// </summary>
        public static ProxySettings NoProxy => new ProxySettings(ProxyType.NoProxy);

        /// <summary>
        /// カスタムプロキシを設定
        /// </summary>
        /// <param name="proxyAddress">プロキシアドレス（例: "http://proxy:8080"）</param>
        /// <returns>ProxySettings</returns>
        public static ProxySettings Custom(string proxyAddress)
        {
            return new ProxySettings(ProxyType.Custom, proxyAddress);
        }

        /// <summary>
        /// 認証付きカスタムプロキシを設定
        /// </summary>
        /// <param name="proxyAddress">プロキシアドレス（例: "http://proxy:8080"）</param>
        /// <param name="username">ユーザー名</param>
        /// <param name="password">パスワード</param>
        /// <returns>ProxySettings</returns>
        public static ProxySettings Custom(string proxyAddress, string username, string password)
        {
            return new ProxySettings(ProxyType.Custom, proxyAddress, null, username, password);
        }

        /// <summary>
        /// IWebProxyを直接指定
        /// </summary>
        /// <param name="proxy">IWebProxyインスタンス</param>
        /// <returns>ProxySettings</returns>
        public static ProxySettings Custom(IWebProxy proxy)
        {
            return new ProxySettings(ProxyType.Custom, null, proxy);
        }

        internal IWebProxy? CreateWebProxy()
        {
            switch (Type)
            {
                case ProxyType.SystemDefault:
                    return WebRequest.DefaultWebProxy;
                case ProxyType.NoProxy:
                    return null;
                case ProxyType.Custom:
                    if (CustomProxy != null)
                        return CustomProxy;
                    if (!string.IsNullOrEmpty(Address))
                    {
                        var proxy = new WebProxy(Address);
                        if (!string.IsNullOrEmpty(Username))
                        {
                            proxy.Credentials = new NetworkCredential(Username, Password);
                        }
                        return proxy;
                    }
                    return null;
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// デバッグ設定
    /// </summary>
    public class DebugSettings
    {
        /// <summary>
        /// デバッグ設定を作成
        /// </summary>
        /// <param name="logDirectory">ログファイルの出力先ディレクトリパス</param>
        /// <param name="maskApiKey">APIキーをマスクして出力するかどうか（デフォルト: true）</param>
        public DebugSettings(string logDirectory, bool maskApiKey = true)
        {
            LogDirectory = logDirectory ?? throw new ArgumentNullException(nameof(logDirectory));
            Encoding = Encoding.Default;
            MaskApiKey = maskApiKey;
        }

        /// <summary>
        /// デバッグ設定を作成
        /// </summary>
        /// <param name="logDirectory">ログファイルの出力先ディレクトリパス</param>
        /// <param name="encoding">CSVファイルのエンコーディング</param>
        /// <param name="maskApiKey">APIキーをマスクして出力するかどうか（デフォルト: true）</param>
        public DebugSettings(string logDirectory, Encoding encoding, bool maskApiKey = true)
        {
            LogDirectory = logDirectory ?? throw new ArgumentNullException(nameof(logDirectory));
            Encoding = encoding ?? Encoding.Default;
            MaskApiKey = maskApiKey;
        }

        /// <summary>
        /// ログファイルの出力先ディレクトリパス
        /// </summary>
        public string LogDirectory { get; }

        /// <summary>
        /// CSVファイルのエンコーディング
        /// </summary>
        public Encoding Encoding { get; }

        /// <summary>
        /// APIキーをマスクして出力するかどうか
        /// </summary>
        public bool MaskApiKey { get; }

        /// <summary>
        /// システム規定のエンコーディングを使用
        /// </summary>
        /// <param name="logDirectory">ログファイルの出力先ディレクトリパス</param>
        /// <param name="maskApiKey">APIキーをマスクして出力するかどうか（デフォルト: true）</param>
        /// <returns>DebugSettings</returns>
        public static DebugSettings WithSystemDefaultEncoding(string logDirectory, bool maskApiKey = true)
        {
            return new DebugSettings(logDirectory, Encoding.Default, maskApiKey);
        }

        /// <summary>
        /// UTF-8エンコーディングを使用
        /// </summary>
        /// <param name="logDirectory">ログファイルの出力先ディレクトリパス</param>
        /// <param name="maskApiKey">APIキーをマスクして出力するかどうか（デフォルト: true）</param>
        /// <returns>DebugSettings</returns>
        public static DebugSettings WithUtf8Encoding(string logDirectory, bool maskApiKey = true)
        {
            return new DebugSettings(logDirectory, Encoding.UTF8, maskApiKey);
        }

        /// <summary>
        /// 任意のエンコーディングを指定
        /// </summary>
        /// <param name="logDirectory">ログファイルの出力先ディレクトリパス</param>
        /// <param name="encoding">エンコーディング</param>
        /// <param name="maskApiKey">APIキーをマスクして出力するかどうか（デフォルト: true）</param>
        /// <returns>DebugSettings</returns>
        public static DebugSettings WithEncoding(string logDirectory, Encoding encoding, bool maskApiKey = true)
        {
            return new DebugSettings(logDirectory, encoding, maskApiKey);
        }
    }
}
