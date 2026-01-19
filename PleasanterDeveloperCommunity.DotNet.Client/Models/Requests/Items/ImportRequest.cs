using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Resources;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコードインポートリクエスト
/// </summary>
public class ImportRequest : ApiRequest
{
    private Encoding? _encoding;

    /// <summary>
    /// CSVファイルのエンコーディング（UTF-8 または Shift-JIS のみサポート）
    /// </summary>
    /// <exception cref="ArgumentException">UTF-8またはShift-JIS以外のエンコーディングを設定した場合</exception>
    [JsonIgnore]
    public Encoding? Encoding
    {
        get => _encoding;
        set
        {
            if (value != null && !IsValidEncoding(value))
            {
                throw new ArgumentException(Messages.UnsupportedImportEncoding);
            }
            _encoding = value;
        }
    }

    /// <summary>
    /// エンコーディング名（API送信用、内部使用）
    /// </summary>
    [JsonPropertyName("Encoding")]
    internal string? EncodingName => _encoding != null ? GetEncodingName(_encoding) : null;

    private static bool IsValidEncoding(Encoding encoding)
    {
        var codePage = encoding.CodePage;
        // UTF-8: 65001, Shift-JIS: 932
        return codePage == 65001 || codePage == 932;
    }

    private static string GetEncodingName(Encoding encoding)
    {
        return encoding.CodePage == 932 ? "Shift-JIS" : "UTF-8";
    }

    private string? _key;

    /// <summary>
    /// キーが一致するレコードを更新する場合のキー項目
    /// （例: IssueId, ClassA など）
    /// このプロパティを設定すると、自動的にUpdatableImportがtrueになります。
    /// </summary>
    [JsonPropertyName("Key")]
    [RegularExpression(ColumnPatterns.ColumnNamePattern, ErrorMessage = "Key はプリザンターの有効な列名である必要があります。")]
    public string? Key
    {
        get => _key;
        set => _key = value;
    }

    /// <summary>
    /// キーが一致するレコードを更新するかどうか（API送信用、内部使用）
    /// Keyが設定されている場合は自動的にtrueになります。
    /// </summary>
    [JsonPropertyName("UpdatableImport")]
    internal bool? UpdatableImport => !string.IsNullOrWhiteSpace(_key) ? true : null;

    /// <summary>
    /// 移行モードでのレコードのインポートを実施する場合はtrue
    /// </summary>
    [JsonPropertyName("MigrationMode")]
    public bool? MigrationMode { get; set; }
}
