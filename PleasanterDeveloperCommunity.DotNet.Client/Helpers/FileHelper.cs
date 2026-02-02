using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Mails;

namespace PleasanterDeveloperCommunity.DotNet.Client.Helpers;

/// <summary>
/// ファイル操作ヘルパー
/// </summary>
public static class FileHelper
{
    /// <summary>
    /// ContentType判定プロバイダー（700+種類の拡張子対応）
    /// </summary>
    private static readonly FileExtensionContentTypeProvider ContentTypeProvider = new();

    /// <summary>
    /// 不明な拡張子のデフォルトContentType
    /// </summary>
    public const string DefaultContentType = "application/octet-stream";

    /// <summary>
    /// ファイルをBase64エンコードして返します
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>Base64エンコードされた文字列</returns>
    /// <exception cref="ArgumentNullException"><paramref name="filePath"/>がnullまたは空の場合</exception>
    /// <exception cref="FileNotFoundException">ファイルが存在しない場合</exception>
    public static string ToBase64(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath));
        }
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("指定されたファイルが見つかりません。", filePath);
        }
        var bytes = File.ReadAllBytes(filePath);
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// ファイルパスからコンテンツタイプを推測します
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>コンテンツタイプ（不明な場合はapplication/octet-stream）</returns>
    public static string GetContentType(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            return DefaultContentType;
        }

        return ContentTypeProvider.TryGetContentType(filePath, out var contentType)
            ? contentType
            : DefaultContentType;
    }

    /// <summary>
    /// 拡張子からコンテンツタイプを推測します
    /// </summary>
    /// <param name="extension">拡張子（ドット付き、例: ".pdf"）</param>
    /// <returns>コンテンツタイプ（不明な場合はapplication/octet-stream）</returns>
    public static string GetContentTypeFromExtension(string? extension)
    {
        if (string.IsNullOrEmpty(extension))
        {
            return DefaultContentType;
        }

        // FileExtensionContentTypeProviderはファイル名で判定するため、ダミーのファイル名を作成
        var dummyFileName = $"file{extension}";
        return ContentTypeProvider.TryGetContentType(dummyFileName, out var contentType)
            ? contentType
            : DefaultContentType;
    }

    /// <summary>
    /// ファイルからBase64とContentTypeを取得します
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>Base64とContentTypeのタプル</returns>
    /// <exception cref="ArgumentNullException"><paramref name="filePath"/>がnullまたは空の場合</exception>
    /// <exception cref="FileNotFoundException">ファイルが存在しない場合</exception>
    public static (string Base64, string ContentType) GetFileData(string filePath)
    {
        var base64 = ToBase64(filePath);
        var contentType = GetContentType(filePath);
        return (base64, contentType);
    }

    /// <summary>
    /// ファイルからファイル名、サイズ、Base64、ContentTypeを取得します
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>FileName、Size、Base64、ContentTypeのタプル</returns>
    /// <exception cref="ArgumentNullException"><paramref name="filePath"/>がnullまたは空の場合</exception>
    /// <exception cref="FileNotFoundException">ファイルが存在しない場合</exception>
    public static (string FileName, long Size, string Base64, string ContentType) GetFullFileData(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath));
        }
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("指定されたファイルが見つかりません。", filePath);
        }

        var fileInfo = new FileInfo(filePath);
        var base64 = Convert.ToBase64String(File.ReadAllBytes(filePath));
        var contentType = GetContentType(filePath);

        return (fileInfo.Name, fileInfo.Length, base64, contentType);
    }

    /// <summary>
    /// カスタムContentTypeマッピングを追加します
    /// </summary>
    /// <param name="extension">拡張子（ドット付き、例: ".custom"）</param>
    /// <param name="contentType">コンテンツタイプ</param>
    public static void AddMapping(string extension, string contentType)
    {
        if (string.IsNullOrEmpty(extension))
        {
            throw new ArgumentNullException(nameof(extension));
        }
        if (string.IsNullOrEmpty(contentType))
        {
            throw new ArgumentNullException(nameof(contentType));
        }

        ContentTypeProvider.Mappings[extension] = contentType;
    }

    /// <summary>
    /// Base64文字列をデコードしてファイルに保存します（同期）
    /// </summary>
    /// <param name="base64">Base64エンコードされた文字列</param>
    /// <param name="filePath">保存先ファイルパス</param>
    /// <exception cref="ArgumentNullException"><paramref name="base64"/>または<paramref name="filePath"/>がnullまたは空の場合</exception>
    public static void SaveFromBase64(string base64, string filePath)
    {
        if (string.IsNullOrEmpty(base64))
        {
            throw new ArgumentNullException(nameof(base64));
        }
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath));
        }

        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var bytes = Convert.FromBase64String(base64);
        File.WriteAllBytes(filePath, bytes);
    }

    /// <summary>
    /// Base64文字列をデコードしてファイルに保存します（非同期）
    /// </summary>
    /// <param name="base64">Base64エンコードされた文字列</param>
    /// <param name="filePath">保存先ファイルパス</param>
    /// <exception cref="ArgumentNullException"><paramref name="base64"/>または<paramref name="filePath"/>がnullまたは空の場合</exception>
    public static async Task SaveFromBase64Async(string base64, string filePath)
    {
        if (string.IsNullOrEmpty(base64))
        {
            throw new ArgumentNullException(nameof(base64));
        }
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath));
        }

        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var bytes = Convert.FromBase64String(base64);
        using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
        await stream.WriteAsync(bytes.AsMemory()).ConfigureAwait(false);
    }

    /// <summary>
    /// Base64文字列をデコードしてバイト配列を取得します
    /// </summary>
    /// <param name="base64">Base64エンコードされた文字列</param>
    /// <returns>デコードされたバイト配列</returns>
    /// <exception cref="ArgumentNullException"><paramref name="base64"/>がnullまたは空の場合</exception>
    public static byte[] ToBytes(string base64)
    {
        if (string.IsNullOrEmpty(base64))
        {
            throw new ArgumentNullException(nameof(base64));
        }
        return Convert.FromBase64String(base64);
    }

    /// <summary>
    /// Base64文字列をデコードして指定ディレクトリにファイルとして保存します（同期）
    /// </summary>
    /// <param name="base64">Base64エンコードされた文字列</param>
    /// <param name="directoryPath">保存先ディレクトリパス</param>
    /// <param name="fileName">ファイル名</param>
    /// <returns>保存先ファイルパス</returns>
    /// <exception cref="ArgumentNullException">引数がnullまたは空の場合</exception>
    public static string SaveFromBase64ToDirectory(string base64, string directoryPath, string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName));
        }
        var filePath = Path.Combine(directoryPath, fileName);
        SaveFromBase64(base64, filePath);
        return filePath;
    }

    /// <summary>
    /// Base64文字列をデコードして指定ディレクトリにファイルとして保存します（非同期）
    /// </summary>
    /// <param name="base64">Base64エンコードされた文字列</param>
    /// <param name="directoryPath">保存先ディレクトリパス</param>
    /// <param name="fileName">ファイル名</param>
    /// <returns>保存先ファイルパス</returns>
    /// <exception cref="ArgumentNullException">引数がnullまたは空の場合</exception>
    public static async Task<string> SaveFromBase64ToDirectoryAsync(string base64, string directoryPath, string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName));
        }
        var filePath = Path.Combine(directoryPath, fileName);
        await SaveFromBase64Async(base64, filePath).ConfigureAwait(false);
        return filePath;
    }

    /// <summary>
    /// ファイルパスからMailAttachmentを作成します
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>MailAttachmentインスタンス</returns>
    /// <exception cref="ArgumentNullException"><paramref name="filePath"/>がnullまたは空の場合</exception>
    /// <exception cref="FileNotFoundException">ファイルが存在しない場合</exception>
    public static MailAttachment ToMailAttachment(string filePath)
    {
        var (fileName, _, base64, contentType) = GetFullFileData(filePath);
        return new MailAttachment
        {
            Name = fileName,
            Base64 = base64,
            ContentType = contentType
        };
    }

    /// <summary>
    /// ファイルパスからAttachmentDataを作成します
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>AttachmentDataインスタンス</returns>
    /// <exception cref="ArgumentNullException"><paramref name="filePath"/>がnullまたは空の場合</exception>
    /// <exception cref="FileNotFoundException">ファイルが存在しない場合</exception>
    public static AttachmentData ToAttachmentData(string filePath)
    {
        var (fileName, size, base64, contentType) = GetFullFileData(filePath);
        return new AttachmentData
        {
            Name = fileName,
            Size = size,
            Base64 = base64,
            ContentType = contentType
        };
    }
}
