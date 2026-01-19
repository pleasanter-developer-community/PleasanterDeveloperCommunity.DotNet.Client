using System;
using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Converters;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// APIリクエストの基底クラス
/// </summary>
public class ApiRequest
{
    /// <summary>
    /// 最小APIバージョン
    /// </summary>
    public const float MinApiVersion = 1.1f;

    private float _apiVersion = MinApiVersion;

    /// <summary>
    /// APIバージョン（既定値: 1.1、1.1未満は設定不可）
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">1.1未満の値を設定した場合</exception>
    [JsonPropertyName("ApiVersion")]
    [JsonConverter(typeof(ApiVersionConverter))]
    public float ApiVersion
    {
        get => _apiVersion;
        set
        {
            if (value < MinApiVersion)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    value,
                    $"ApiVersion must be {MinApiVersion} or greater.");
            }
            _apiVersion = value;
        }
    }

    /// <summary>
    /// APIキー
    /// </summary>
    [JsonPropertyName("ApiKey")]
    public string? ApiKey { get; set; }
}
