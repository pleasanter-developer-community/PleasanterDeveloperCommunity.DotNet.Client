using System;
using System.Net;

namespace PleasanterDeveloperCommunity.DotNet.Client;

/// <summary>
/// プロキシモード
/// </summary>
public enum ProxyMode
{
    /// <summary>
    /// OS設定に従う（システムプロキシを使用）
    /// </summary>
    UseSystemDefault,

    /// <summary>
    /// プロキシを使用しない
    /// </summary>
    NoProxy,

    /// <summary>
    /// カスタムプロキシを使用
    /// </summary>
    Custom
}

/// <summary>
/// プロキシ設定
/// </summary>
public class ProxySettings
{
    /// <summary>
    /// プロキシモード
    /// </summary>
    public ProxyMode Mode { get; }

    /// <summary>
    /// カスタムプロキシ（Mode が Custom の場合に使用）
    /// </summary>
    public IWebProxy? Proxy { get; }

    private ProxySettings(ProxyMode mode, IWebProxy? proxy = null)
    {
        Mode = mode;
        Proxy = proxy;
    }

    /// <summary>
    /// OS設定に従うプロキシ設定を取得します
    /// </summary>
    public static ProxySettings UseSystemDefault { get; } = new(ProxyMode.UseSystemDefault);

    /// <summary>
    /// プロキシを使用しない設定を取得します
    /// </summary>
    public static ProxySettings NoProxy { get; } = new(ProxyMode.NoProxy);

    /// <summary>
    /// カスタムプロキシ設定を作成します
    /// </summary>
    /// <param name="proxyAddress">プロキシサーバーのアドレス（例: http://proxy.example.com:8080）</param>
    /// <returns>プロキシ設定</returns>
    public static ProxySettings Custom(string proxyAddress)
    {
        if (string.IsNullOrWhiteSpace(proxyAddress))
        {
            throw new ArgumentNullException(nameof(proxyAddress));
        }

        return new ProxySettings(ProxyMode.Custom, new WebProxy(proxyAddress));
    }

    /// <summary>
    /// カスタムプロキシ設定を作成します（認証付き）
    /// </summary>
    /// <param name="proxyAddress">プロキシサーバーのアドレス（例: http://proxy.example.com:8080）</param>
    /// <param name="username">ユーザー名</param>
    /// <param name="password">パスワード</param>
    /// <returns>プロキシ設定</returns>
    public static ProxySettings Custom(string proxyAddress, string username, string password)
    {
        if (string.IsNullOrWhiteSpace(proxyAddress))
        {
            throw new ArgumentNullException(nameof(proxyAddress));
        }

        var proxy = new WebProxy(proxyAddress)
        {
            Credentials = new NetworkCredential(username, password)
        };

        return new ProxySettings(ProxyMode.Custom, proxy);
    }

    /// <summary>
    /// カスタムプロキシ設定を作成します（IWebProxy使用）
    /// </summary>
    /// <param name="proxy">プロキシインスタンス</param>
    /// <returns>プロキシ設定</returns>
    public static ProxySettings Custom(IWebProxy proxy)
    {
        return new ProxySettings(ProxyMode.Custom, proxy ?? throw new ArgumentNullException(nameof(proxy)));
    }
}
