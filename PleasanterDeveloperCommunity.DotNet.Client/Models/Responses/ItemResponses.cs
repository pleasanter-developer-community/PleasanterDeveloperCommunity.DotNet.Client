using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses
{
    /// <summary>
    /// APIレスポンス基底クラス
    /// </summary>
    /// <typeparam name="T">レスポンスデータの型</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// HTTPステータスコード
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// レスポンスメッセージ
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// レスポンスデータ
        /// </summary>
        public T? Response { get; set; }

        /// <summary>
        /// 成功したかどうか
        /// </summary>
        public bool IsSuccess => StatusCode == HttpStatusCode.OK;
    }

    /// <summary>
    /// 単一レコード取得レスポンス
    /// </summary>
    public class RecordResponse
    {
        [JsonPropertyName("Data")]
        public RecordData? Data { get; set; }
    }

    /// <summary>
    /// 複数レコード取得レスポンス
    /// </summary>
    public class RecordsResponse
    {
        [JsonPropertyName("Offset")]
        public int? Offset { get; set; }

        [JsonPropertyName("PageSize")]
        public int? PageSize { get; set; }

        [JsonPropertyName("TotalCount")]
        public int? TotalCount { get; set; }

        [JsonPropertyName("Data")]
        public List<RecordData>? Data { get; set; }
    }

    /// <summary>
    /// レコード作成レスポンス
    /// </summary>
    public class CreateRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("LimitPerDate")]
        public int? LimitPerDate { get; set; }

        [JsonPropertyName("LimitRemaining")]
        public int? LimitRemaining { get; set; }
    }

    /// <summary>
    /// レコード更新レスポンス
    /// </summary>
    public class UpdateRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("UpdatedTime")]
        public DateTime? UpdatedTime { get; set; }

        [JsonPropertyName("LimitPerDate")]
        public int? LimitPerDate { get; set; }

        [JsonPropertyName("LimitRemaining")]
        public int? LimitRemaining { get; set; }
    }

    /// <summary>
    /// Upsertレスポンス
    /// </summary>
    public class UpsertRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("Created")]
        public bool Created { get; set; }
    }

    /// <summary>
    /// 一括Upsertレスポンス
    /// </summary>
    public class BulkUpsertRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("Created")]
        public int? Created { get; set; }

        [JsonPropertyName("Updated")]
        public int? Updated { get; set; }
    }

    /// <summary>
    /// レコード削除レスポンス
    /// </summary>
    public class DeleteRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("LimitPerDate")]
        public int? LimitPerDate { get; set; }

        [JsonPropertyName("LimitRemaining")]
        public int? LimitRemaining { get; set; }
    }

    /// <summary>
    /// 一括削除レスポンス
    /// </summary>
    public class BulkDeleteRecordResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// インポートレスポンス
    /// </summary>
    public class ImportResponse
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// エクスポートレスポンス
    /// </summary>
    public class ExportResponse
    {
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Content")]
        public string? Content { get; set; }
    }

    /// <summary>
    /// 添付ファイルレスポンス
    /// </summary>
    public class AttachmentResponse
    {
        [JsonPropertyName("ReferenceId")]
        public long ReferenceId { get; set; }

        [JsonPropertyName("BinaryType")]
        public string? BinaryType { get; set; }

        [JsonPropertyName("Base64")]
        public string? Base64 { get; set; }

        [JsonPropertyName("Guid")]
        public string? Guid { get; set; }

        [JsonPropertyName("FileNameWithoutExtension")]
        public string? FileNameWithoutExtension { get; set; }

        [JsonPropertyName("Extension")]
        public string? Extension { get; set; }

        [JsonPropertyName("Size")]
        public long Size { get; set; }

        [JsonPropertyName("ContentType")]
        public string? ContentType { get; set; }

        [JsonPropertyName("Creator")]
        public long Creator { get; set; }

        [JsonPropertyName("Updator")]
        public long Updator { get; set; }

        [JsonPropertyName("CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonPropertyName("UpdatedTime")]
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

    /// <summary>
    /// 拡張SQL実行レスポンス
    /// </summary>
    public class ExtendedSqlResponse
    {
        [JsonPropertyName("Data")]
        public List<Dictionary<string, object>>? Data { get; set; }
    }
}
