using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 添付ファイルレスポンス
/// </summary>
public class AttachmentResponse
{
    /// <summary>
    /// 参照ID
    /// </summary>
    public long ReferenceId { get; set; }

    /// <summary>
    /// バイナリタイプ
    /// </summary>
    public string? BinaryType { get; set; }

    /// <summary>
    /// Base64エンコードされたファイルデータ
    /// </summary>
    public string? Base64 { get; set; }

    /// <summary>
    /// 添付ファイルのGUID
    /// </summary>
    [JsonProperty("Guid")]
    public string? AttachmentGuid { get; set; }

    /// <summary>
    /// 拡張子を除いたファイル名
    /// </summary>
    public string? FileNameWithoutExtension { get; set; }

    /// <summary>
    /// 拡張子
    /// </summary>
    public string? Extension { get; set; }

    /// <summary>
    /// ファイルサイズ（バイト）
    /// </summary>
    public long Size { get; set; }

    /// <summary>
    /// コンテンツタイプ
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// 作成者ID
    /// </summary>
    public long Creator { get; set; }

    /// <summary>
    /// 更新者ID
    /// </summary>
    public long Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// 更新日時
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// ファイル名と拡張子を結合した完全なファイル名
    /// </summary>
    public string FileName => $"{FileNameWithoutExtension}{Extension}";

    /// <summary>
    /// Base64データをバイト配列にデコードします
    /// </summary>
    public byte[] GetBytes()
    {
        if (string.IsNullOrEmpty(Base64))
            return Array.Empty<byte>();
        return Convert.FromBase64String(Base64);
    }

    /// <summary>
    /// 指定したファイルパスに保存します（同期）
    /// </summary>
    public void SaveToFile(string filePath)
    {
        var bytes = GetBytes();
        File.WriteAllBytes(filePath, bytes);
    }

    /// <summary>
    /// 指定したファイルパスに保存します（非同期）
    /// </summary>
    public async Task SaveToFileAsync(string filePath)
    {
        var bytes = GetBytes();
        using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
        await stream.WriteAsync(bytes.AsMemory()).ConfigureAwait(false);
    }

    /// <summary>
    /// 指定したディレクトリに元のファイル名で保存し、保存先パスを返します（同期）
    /// </summary>
    public string SaveToDirectory(string directoryPath)
    {
        var filePath = Path.Combine(directoryPath, FileName);
        SaveToFile(filePath);
        return filePath;
    }

    /// <summary>
    /// 指定したディレクトリに元のファイル名で保存し、保存先パスを返します（非同期）
    /// </summary>
    public async Task<string> SaveToDirectoryAsync(string directoryPath)
    {
        var filePath = Path.Combine(directoryPath, FileName);
        await SaveToFileAsync(filePath);
        return filePath;
    }
}
