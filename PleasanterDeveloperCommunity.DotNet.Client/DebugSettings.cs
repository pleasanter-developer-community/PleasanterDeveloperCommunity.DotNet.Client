using System;
using System.IO;
using System.Text;

namespace PleasanterDeveloperCommunity.DotNet.Client;

/// <summary>
/// デバッグ設定
/// </summary>
public class DebugSettings
{
    /// <summary>
    /// ログ出力先ディレクトリパス
    /// </summary>
    public string LogDirectory { get; }

    /// <summary>
    /// CSVファイルのエンコーディング（省略時：システム規定）
    /// </summary>
    public Encoding? Encoding { get; }

    /// <summary>
    /// APIキーをマスクするかどうか（省略時：true）
    /// </summary>
    public bool MaskApiKey { get; }

    /// <summary>
    /// DebugSettingsのコンストラクタ
    /// </summary>
    /// <param name="logDirectory">ログ出力先ディレクトリパス</param>
    /// <param name="encoding">CSVファイルのエンコーディング（省略時：システム規定）</param>
    /// <param name="maskApiKey">APIキーをマスクするかどうか（省略時：true）</param>
    /// <exception cref="ArgumentNullException">logDirectoryがnullまたは空白の場合</exception>
    /// <exception cref="ArgumentException">logDirectoryが無効なパスの場合</exception>
    /// <exception cref="UnauthorizedAccessException">ディレクトリへの書き込み権限がない場合</exception>
    /// <exception cref="IOException">ディレクトリの作成または書き込みテストに失敗した場合</exception>
    public DebugSettings(string logDirectory, Encoding? encoding = null, bool maskApiKey = true)
    {
        if (string.IsNullOrWhiteSpace(logDirectory))
        {
            throw new ArgumentNullException(nameof(logDirectory));
        }

        ValidateAndPrepareLogDirectory(logDirectory);

        LogDirectory = logDirectory;
        Encoding = encoding;
        MaskApiKey = maskApiKey;
    }

    /// <summary>
    /// ログディレクトリを検証し、必要に応じて作成します
    /// </summary>
    /// <param name="logDirectory">ログ出力先ディレクトリパス</param>
    private static void ValidateAndPrepareLogDirectory(string logDirectory)
    {
        // パスが有効かどうかを検証
        string fullPath;
        try
        {
            fullPath = Path.GetFullPath(logDirectory);
        }
        catch (Exception ex) when (ex is ArgumentException || ex is PathTooLongException || ex is NotSupportedException)
        {
            throw new ArgumentException($"無効なディレクトリパスです: {logDirectory}", nameof(logDirectory), ex);
        }

        // ディレクトリが存在しない場合は作成を試みる
        if (!Directory.Exists(fullPath))
        {
            try
            {
                Directory.CreateDirectory(fullPath);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException($"ディレクトリの作成権限がありません: {fullPath}", ex);
            }
            catch (IOException ex)
            {
                throw new IOException($"ディレクトリの作成に失敗しました: {fullPath}", ex);
            }
        }

        // 書き込み権限を検証（テストファイルを作成して削除）
        var testFilePath = Path.Combine(fullPath, $".write_test_{Guid.NewGuid():N}.tmp");
        try
        {
            using (File.Create(testFilePath)) { }
            File.Delete(testFilePath);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new UnauthorizedAccessException($"ディレクトリへの書き込み権限がありません: {fullPath}", ex);
        }
        catch (IOException ex)
        {
            throw new IOException($"ディレクトリへの書き込みテストに失敗しました: {fullPath}", ex);
        }
    }

    /// <summary>
    /// システム規定のエンコーディングでデバッグ設定を作成します
    /// </summary>
    /// <param name="logDirectory">ログ出力先ディレクトリパス</param>
    /// <param name="maskApiKey">APIキーをマスクするかどうか（省略時：true）</param>
    /// <returns>デバッグ設定</returns>
    public static DebugSettings WithSystemDefaultEncoding(string logDirectory, bool maskApiKey = true)
    {
        return new DebugSettings(logDirectory, null, maskApiKey);
    }

    /// <summary>
    /// UTF-8エンコーディングでデバッグ設定を作成します
    /// </summary>
    /// <param name="logDirectory">ログ出力先ディレクトリパス</param>
    /// <param name="maskApiKey">APIキーをマスクするかどうか（省略時：true）</param>
    /// <returns>デバッグ設定</returns>
    public static DebugSettings WithUtf8Encoding(string logDirectory, bool maskApiKey = true)
    {
        return new DebugSettings(logDirectory, Encoding.UTF8, maskApiKey);
    }

    /// <summary>
    /// 指定されたエンコーディングでデバッグ設定を作成します
    /// </summary>
    /// <param name="logDirectory">ログ出力先ディレクトリパス</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="maskApiKey">APIキーをマスクするかどうか（省略時：true）</param>
    /// <returns>デバッグ設定</returns>
    public static DebugSettings WithEncoding(string logDirectory, Encoding encoding, bool maskApiKey = true)
    {
        return new DebugSettings(logDirectory, encoding, maskApiKey);
    }
}
