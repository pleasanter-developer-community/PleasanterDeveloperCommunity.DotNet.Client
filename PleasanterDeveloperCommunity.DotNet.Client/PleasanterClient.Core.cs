using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace PleasanterDeveloperCommunity.DotNet.Client;

/// <summary>
/// Pleasanter APIクライアント
/// </summary>
public partial class PleasanterClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;
    private readonly float _apiVersion;
    private readonly bool _disposeHttpClient;
    private readonly DebugSettings? _debugSettings;
    private readonly ConcurrentQueue<string> _logQueue;
    private readonly Task? _logWriterTask;
    private readonly CancellationTokenSource? _logCancellation;
    private bool _disposed;

    private static readonly JsonSerializerSettings JsonSettings = new()
    {
        ContractResolver = new DefaultContractResolver(),
        NullValueHandling = NullValueHandling.Ignore,
        Formatting = Formatting.None
    };

    /// <summary>
    /// PleasanterClientを初期化します（標準コンストラクタ）
    /// </summary>
    /// <param name="baseUrl">プリザンターのベースURL</param>
    /// <param name="apiKey">APIキー</param>
    /// <param name="apiVersion">APIバージョン（省略時: 1.1、最小値: 1.1）</param>
    /// <param name="defaultTimeout">デフォルトのリクエストタイムアウト</param>
    /// <param name="proxySettings">プロキシ設定</param>
    /// <param name="ignoreSslCertificateValidation">SSL証明書の検証を無効にするかどうか</param>
    /// <param name="debugSettings">デバッグ設定</param>
    public PleasanterClient(
        string baseUrl,
        string apiKey,
        float apiVersion = 1.1f,
        TimeSpan? defaultTimeout = null,
        ProxySettings? proxySettings = null,
        bool ignoreSslCertificateValidation = false,
        DebugSettings? debugSettings = null)
    {
        if (string.IsNullOrEmpty(baseUrl))
            throw new ArgumentNullException(nameof(baseUrl));
        if (string.IsNullOrEmpty(apiKey))
            throw new ArgumentNullException(nameof(apiKey));

        _baseUrl = baseUrl.TrimEnd('/');
        _apiKey = apiKey;
        _apiVersion = Math.Max(apiVersion, 1.1f);
        _debugSettings = debugSettings;
        _disposeHttpClient = true;
        _logQueue = new();

        var handler = new HttpClientHandler();

        // プロキシ設定
        if (proxySettings != null)
        {
            var proxy = proxySettings.CreateWebProxy();
            if (proxySettings.Type == ProxySettings.ProxyType.NoProxy)
            {
                handler.UseProxy = false;
            }
            else if (proxy != null)
            {
                handler.UseProxy = true;
                handler.Proxy = proxy;
            }
        }

        // SSL証明書検証の無効化
        if (ignoreSslCertificateValidation)
        {
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
        }

        _httpClient = new HttpClient(handler);
        if (defaultTimeout.HasValue)
        {
            _httpClient.Timeout = defaultTimeout.Value;
        }

        // デバッグモードの初期化
        if (_debugSettings != null)
        {
            Directory.CreateDirectory(_debugSettings.LogDirectory);
            _logCancellation = new();
            _logWriterTask = StartLogWriterAsync(_logCancellation.Token);
        }
    }

    /// <summary>
    /// PleasanterClientを初期化します（HttpClient指定コンストラクタ）
    /// </summary>
    /// <param name="baseUrl">プリザンターのベースURL</param>
    /// <param name="apiKey">APIキー</param>
    /// <param name="httpClient">外部から渡すHttpClientインスタンス</param>
    /// <param name="apiVersion">APIバージョン（省略時: 1.1、最小値: 1.1）</param>
    /// <param name="debugSettings">デバッグ設定</param>
    public PleasanterClient(
        string baseUrl,
        string apiKey,
        HttpClient httpClient,
        float apiVersion = 1.1f,
        DebugSettings? debugSettings = null)
    {
        if (string.IsNullOrEmpty(baseUrl))
            throw new ArgumentNullException(nameof(baseUrl));
        if (string.IsNullOrEmpty(apiKey))
            throw new ArgumentNullException(nameof(apiKey));

        _baseUrl = baseUrl.TrimEnd('/');
        _apiKey = apiKey;
        _apiVersion = Math.Max(apiVersion, 1.1f);
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _debugSettings = debugSettings;
        _disposeHttpClient = false;
        _logQueue = new();

        // デバッグモードの初期化
        if (_debugSettings != null)
        {
            Directory.CreateDirectory(_debugSettings.LogDirectory);
            _logCancellation = new();
            _logWriterTask = StartLogWriterAsync(_logCancellation.Token);
        }
    }

    #region IDisposable

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            // ログ書き込みタスクの終了を待つ
            if (_logCancellation != null)
            {
                _logCancellation.Cancel();
                _logWriterTask?.Wait(TimeSpan.FromSeconds(5));
                _logCancellation.Dispose();
            }

            if (_disposeHttpClient)
            {
                _httpClient.Dispose();
            }
        }

        _disposed = true;
    }

    #endregion
}
