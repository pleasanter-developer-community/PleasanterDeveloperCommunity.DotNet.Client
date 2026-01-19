using System.Text.Json.Serialization;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Binaries;

/// <summary>
/// 添付ファイルデータ（レスポンス用）
/// </summary>
public class AttachmentData
{
    /// <summary>
    /// ファイルが紐づいているレコードのID
    /// </summary>
    [JsonPropertyName("ReferenceId")]
    public long ReferenceId { get; set; }

    /// <summary>
    /// バイナリタイプ（Attachments: 添付ファイル, Images: 画像）
    /// </summary>
    [JsonPropertyName("BinaryType")]
    public string? BinaryType { get; set; }

    /// <summary>
    /// Base64エンコードされたファイルの内容
    /// </summary>
    [JsonPropertyName("Base64")]
    public string? Base64 { get; set; }

    /// <summary>
    /// ファイルのGUID
    /// </summary>
    [JsonPropertyName("Guid")]
    public string? Guid { get; set; }

    /// <summary>
    /// ファイル名（拡張子なし）
    /// </summary>
    [JsonPropertyName("FileName")]
    public string? FileNameWithoutExtension { get; set; }

    /// <summary>
    /// 拡張子
    /// </summary>
    [JsonPropertyName("Extension")]
    public string? Extension { get; set; }

    /// <summary>
    /// ファイル名と拡張子を結合した完全なファイル名（例: "document.pdf"）
    /// </summary>
    [JsonIgnore]
    public string FileName => $"{FileNameWithoutExtension}{Extension}";

    /// <summary>
    /// ファイルサイズ（バイト単位）
    /// </summary>
    [JsonPropertyName("Size")]
    public long Size { get; set; }

    /// <summary>
    /// ファイルのMIMEタイプ
    /// </summary>
    [JsonPropertyName("ContentType")]
    public string? ContentType { get; set; }

    /// <summary>
    /// ファイル作成者のユーザID
    /// </summary>
    [JsonPropertyName("Creator")]
    public long Creator { get; set; }

    /// <summary>
    /// ファイル更新者のユーザID
    /// </summary>
    [JsonPropertyName("Updator")]
    public long Updator { get; set; }

    /// <summary>
    /// ファイル作成日時
    /// </summary>
    [JsonPropertyName("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// ファイル更新日時
    /// </summary>
    [JsonPropertyName("UpdatedTime")]
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// Base64データをバイト配列にデコードします
    /// </summary>
    /// <returns>デコードされたバイト配列。Base64がnullの場合はnullを返します。</returns>
    public byte[]? GetBytes()
    {
        if (string.IsNullOrEmpty(Base64))
        {
            return null;
        }
        return Convert.FromBase64String(Base64);
    }

    /// <summary>
    /// ファイルを指定したパスに保存します
    /// </summary>
    /// <param name="filePath">保存先のファイルパス（ファイル名を含む完全なパス）</param>
    /// <exception cref="InvalidOperationException">Base64データがnullまたは空の場合</exception>
    public void SaveToFile(string filePath)
    {
        var bytes = GetBytes();
        if (bytes == null)
        {
            throw new InvalidOperationException("Base64 data is null or empty.");
        }
        File.WriteAllBytes(filePath, bytes);
    }

    /// <summary>
    /// ファイルを指定したパスに非同期で保存します
    /// </summary>
    /// <param name="filePath">保存先のファイルパス（ファイル名を含む完全なパス）</param>
    /// <exception cref="InvalidOperationException">Base64データがnullまたは空の場合</exception>
    public async Task SaveToFileAsync(string filePath)
    {
        var bytes = GetBytes();
        if (bytes == null)
        {
            throw new InvalidOperationException("Base64 data is null or empty.");
        }
        await File.WriteAllBytesAsync(filePath, bytes);
    }

    /// <summary>
    /// ファイルを指定したディレクトリに元のファイル名で保存します
    /// </summary>
    /// <param name="directoryPath">保存先のディレクトリパス</param>
    /// <returns>保存されたファイルの完全なパス</returns>
    /// <exception cref="InvalidOperationException">Base64データまたはファイル名がnullまたは空の場合</exception>
    public string SaveToDirectory(string directoryPath)
    {
        var bytes = GetBytes();
        if (bytes == null)
        {
            throw new InvalidOperationException("Base64 data is null or empty.");
        }
        if (string.IsNullOrEmpty(FileNameWithoutExtension))
        {
            throw new InvalidOperationException("FileNameWithoutExtension is null or empty.");
        }

        var filePath = Path.Combine(directoryPath, FileName);
        File.WriteAllBytes(filePath, bytes);
        return filePath;
    }

    /// <summary>
    /// ファイルを指定したディレクトリに元のファイル名で非同期で保存します
    /// </summary>
    /// <param name="directoryPath">保存先のディレクトリパス</param>
    /// <returns>保存されたファイルの完全なパス</returns>
    /// <exception cref="InvalidOperationException">Base64データまたはファイル名がnullまたは空の場合</exception>
    public async Task<string> SaveToDirectoryAsync(string directoryPath)
    {
        var bytes = GetBytes();
        if (bytes == null)
        {
            throw new InvalidOperationException("Base64 data is null or empty.");
        }
        if (string.IsNullOrEmpty(FileNameWithoutExtension))
        {
            throw new InvalidOperationException("FileNameWithoutExtension is null or empty.");
        }

        var filePath = Path.Combine(directoryPath, FileName);
        await File.WriteAllBytesAsync(filePath, bytes);
        return filePath;
    }
}
