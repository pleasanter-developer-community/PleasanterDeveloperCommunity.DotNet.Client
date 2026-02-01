using System;
using System.Net;
using System.Text;

namespace PleasanterDeveloperCommunity.DotNet.Client;

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
    public static ProxySettings UseSystemDefault => new(ProxyType.SystemDefault);

    /// <summary>
    /// プロキシを使用しない
    /// </summary>
    public static ProxySettings NoProxy => new(ProxyType.NoProxy);

    /// <summary>
    /// カスタムプロキシを設定
    /// </summary>
    /// <param name="proxyAddress">プロキシアドレス（例: "http://proxy:8080"）</param>
    /// <returns>ProxySettings</returns>
    public static ProxySettings Custom(string proxyAddress) => new(ProxyType.Custom, proxyAddress);

    /// <summary>
    /// 認証付きカスタムプロキシを設定
    /// </summary>
    /// <param name="proxyAddress">プロキシアドレス（例: "http://proxy:8080"）</param>
    /// <param name="username">ユーザー名</param>
    /// <param name="password">パスワード</param>
    /// <returns>ProxySettings</returns>
    public static ProxySettings Custom(string proxyAddress, string username, string password)
        => new(ProxyType.Custom, proxyAddress, null, username, password);

    /// <summary>
    /// IWebProxyを直接指定
    /// </summary>
    /// <param name="proxy">IWebProxyインスタンス</param>
    /// <returns>ProxySettings</returns>
    public static ProxySettings Custom(IWebProxy proxy) => new(ProxyType.Custom, null, proxy);

    internal IWebProxy? CreateWebProxy() => Type switch
    {
        ProxyType.SystemDefault => WebRequest.DefaultWebProxy,
        ProxyType.NoProxy => null,
        ProxyType.Custom => CustomProxy ?? CreateCustomProxy(),
        _ => null
    };

    private IWebProxy? CreateCustomProxy()
    {
        if (string.IsNullOrEmpty(Address))
            return null;

        var proxy = new WebProxy(Address);
        if (!string.IsNullOrEmpty(Username))
        {
            proxy.Credentials = new NetworkCredential(Username, Password);
        }
        return proxy;
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
        => new(logDirectory, Encoding.Default, maskApiKey);

    /// <summary>
    /// UTF-8エンコーディングを使用
    /// </summary>
    /// <param name="logDirectory">ログファイルの出力先ディレクトリパス</param>
    /// <param name="maskApiKey">APIキーをマスクして出力するかどうか（デフォルト: true）</param>
    /// <returns>DebugSettings</returns>
    public static DebugSettings WithUtf8Encoding(string logDirectory, bool maskApiKey = true)
        => new(logDirectory, Encoding.UTF8, maskApiKey);

    /// <summary>
    /// 任意のエンコーディングを指定
    /// </summary>
    /// <param name="logDirectory">ログファイルの出力先ディレクトリパス</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="maskApiKey">APIキーをマスクして出力するかどうか（デフォルト: true）</param>
    /// <returns>DebugSettings</returns>
    public static DebugSettings WithEncoding(string logDirectory, Encoding encoding, bool maskApiKey = true)
        => new(logDirectory, encoding, maskApiKey);
}
