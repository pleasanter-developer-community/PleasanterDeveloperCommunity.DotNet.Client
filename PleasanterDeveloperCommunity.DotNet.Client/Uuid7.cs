using System;
using System.Security.Cryptography;
using System.Threading;

namespace PleasanterDeveloperCommunity.DotNet.Client;

/// <summary>
/// UUIDv7を生成するユーティリティクラス
/// </summary>
/// <remarks>
/// UUIDv7はRFC 9562で定義された時間ベースのUUIDで、
/// タイムスタンプ順にソート可能な特性を持ちます。
/// </remarks>
internal static class Uuid7
{
    private static long _lastTimestamp;
    private static int _sequence;
    private static readonly object _lock = new();

#if NETSTANDARD2_1
    private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();
#endif

    /// <summary>
    /// 新しいUUIDv7を生成します
    /// </summary>
    /// <returns>時間順にソート可能なUUID</returns>
    public static Guid NewGuid()
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        int seq;

        lock (_lock)
        {
            if (timestamp == _lastTimestamp)
            {
                // 同一ミリ秒内ではシーケンスをインクリメント
                _sequence++;
                if (_sequence > 0xFFF) // 12ビットの最大値を超えた場合
                {
                    // 次のミリ秒まで待機
                    while (timestamp == _lastTimestamp)
                    {
                        Thread.Sleep(1);
                        timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    }
                    _sequence = 0;
                }
            }
            else
            {
                _sequence = 0;
            }

            _lastTimestamp = timestamp;
            seq = _sequence;
        }

        return CreateUuid7(timestamp, seq);
    }

    /// <summary>
    /// UUIDv7のバイト配列を構築します
    /// </summary>
    private static Guid CreateUuid7(long timestamp, int sequence)
    {
        Span<byte> bytes = stackalloc byte[16];

        // 最初の48ビット: Unixタイムスタンプ（ミリ秒）- ビッグエンディアン
        bytes[0] = (byte)(timestamp >> 40);
        bytes[1] = (byte)(timestamp >> 32);
        bytes[2] = (byte)(timestamp >> 24);
        bytes[3] = (byte)(timestamp >> 16);
        bytes[4] = (byte)(timestamp >> 8);
        bytes[5] = (byte)timestamp;

        // 次の4ビット: バージョン7、次の12ビット: シーケンス
        bytes[6] = (byte)(0x70 | ((sequence >> 8) & 0x0F)); // version 7 + seq上位4ビット
        bytes[7] = (byte)sequence; // seq下位8ビット

        // ランダム部分を生成
#if NETSTANDARD2_1
        Span<byte> random = stackalloc byte[8];
        _rng.GetBytes(random);
#else
        Span<byte> random = stackalloc byte[8];
        RandomNumberGenerator.Fill(random);
#endif

        // バリアント（10xx xxxx）を設定
        bytes[8] = (byte)(0x80 | (random[0] & 0x3F)); // variant + 6ビットランダム
        bytes[9] = random[1];
        bytes[10] = random[2];
        bytes[11] = random[3];
        bytes[12] = random[4];
        bytes[13] = random[5];
        bytes[14] = random[6];
        bytes[15] = random[7];

        // .NETのGuidはリトルエンディアンなので、最初の3セグメントを反転
        return new Guid(
            (bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3],  // a (int)
            (short)((bytes[4] << 8) | bytes[5]),                                 // b (short)
            (short)((bytes[6] << 8) | bytes[7]),                                 // c (short)
            bytes[8], bytes[9], bytes[10], bytes[11],
            bytes[12], bytes[13], bytes[14], bytes[15]
        );
    }
}
