using System;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

/// <summary>
/// 添付ファイルレスポンス
/// </summary>
public class AttachmentResponse
{
    [JsonProperty("ReferenceId")]
    public long ReferenceId { get; set; }

    [JsonProperty("BinaryType")]
    public string? BinaryType { get; set; }

    [JsonProperty("Base64")]
    public string? Base64 { get; set; }

    [JsonProperty("Guid")]
    public string? Guid { get; set; }

    [JsonProperty("FileNameWithoutExtension")]
    public string? FileNameWithoutExtension { get; set; }

    [JsonProperty("Extension")]
    public string? Extension { get; set; }

    [JsonProperty("Size")]
    public long Size { get; set; }

    [JsonProperty("ContentType")]
    public string? ContentType { get; set; }

    [JsonProperty("Creator")]
    public long Creator { get; set; }

    [JsonProperty("Updator")]
    public long Updator { get; set; }

    [JsonProperty("CreatedTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonProperty("UpdatedTime")]
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
        await stream.WriteAsync(bytes, 0, bytes.Length);
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
