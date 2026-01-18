namespace PleasanterDeveloperCommunity.DotNet.Client.Resources;

using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Provides localized messages for the application.
/// Messages are returned based on the current UI culture.
/// Default language is English, with Japanese support.
/// </summary>
internal static class Messages
{
    private static readonly Dictionary<string, Dictionary<string, string>> LocalizedMessages = new()
    {
        ["en"] = new Dictionary<string, string>
        {
            ["ColumnFilterHashKeyError"] = "The key of ColumnFilterHash must be a valid Pleasanter column name.",
            ["ColumnFilterSearchTypesKeyError"] = "The key of ColumnFilterSearchTypes must be a valid Pleasanter column name.",
            ["ColumnFilterNegativesValueError"] = "The value of ColumnFilterNegatives must be a valid Pleasanter column name.",
            ["ColumnSorterHashKeyError"] = "The key of ColumnSorterHash must be a valid Pleasanter column name.",
            ["ApiColumnHashKeyError"] = "The key of ApiColumnHash must be a valid Pleasanter column name.",
            ["GridColumnsValueError"] = "The value of GridColumns must be a valid Pleasanter column name.",
            ["ClassHashKeyError"] = "The key of ClassHash must be ClassA-Z or Class001-999.",
            ["NumHashKeyError"] = "The key of NumHash must be NumA-Z or Num001-999.",
            ["DateHashKeyError"] = "The key of DateHash must be DateA-Z or Date001-999.",
            ["DescriptionHashKeyError"] = "The key of DescriptionHash must be DescriptionA-Z or Description001-999.",
            ["CheckHashKeyError"] = "The key of CheckHash must be CheckA-Z or Check001-999.",
            ["AttachmentsHashKeyError"] = "The key of AttachmentsHash must be AttachmentsA-Z or Attachments001-999.",
            ["ImageHashKeyError"] = "The key of ImageHash must be Body, Comments, or DescriptionA-Z/Description001-999.",
            ["InvalidDirectoryPath"] = "Invalid directory path: {0}",
            ["NoPermissionToCreateDirectory"] = "No permission to create directory: {0}",
            ["FailedToCreateDirectory"] = "Failed to create directory: {0}",
            ["NoWritePermissionForDirectory"] = "No write permission for directory: {0}",
            ["WriteTestFailedForDirectory"] = "Write test failed for directory: {0}",
            ["UnsupportedImportEncoding"] = "The encoding must be UTF-8 or Shift-JIS. Other encodings are not supported.",
            ["FileNotFound"] = "File not found: {0}",
        },
        ["ja"] = new Dictionary<string, string>
        {
            ["ColumnFilterHashKeyError"] = "ColumnFilterHash のキーはプリザンターの有効な列名である必要があります。",
            ["ColumnFilterSearchTypesKeyError"] = "ColumnFilterSearchTypes のキーはプリザンターの有効な列名である必要があります。",
            ["ColumnFilterNegativesValueError"] = "ColumnFilterNegatives の値はプリザンターの有効な列名である必要があります。",
            ["ColumnSorterHashKeyError"] = "ColumnSorterHash のキーはプリザンターの有効な列名である必要があります。",
            ["ApiColumnHashKeyError"] = "ApiColumnHash のキーはプリザンターの有効な列名である必要があります。",
            ["GridColumnsValueError"] = "GridColumns の値はプリザンターの有効な列名である必要があります。",
            ["ClassHashKeyError"] = "ClassHash のキーは ClassA〜Z または Class001〜999 である必要があります。",
            ["NumHashKeyError"] = "NumHash のキーは NumA〜Z または Num001〜999 である必要があります。",
            ["DateHashKeyError"] = "DateHash のキーは DateA〜Z または Date001〜999 である必要があります。",
            ["DescriptionHashKeyError"] = "DescriptionHash のキーは DescriptionA〜Z または Description001〜999 である必要があります。",
            ["CheckHashKeyError"] = "CheckHash のキーは CheckA〜Z または Check001〜999 である必要があります。",
            ["AttachmentsHashKeyError"] = "AttachmentsHash のキーは AttachmentsA〜Z または Attachments001〜999 である必要があります。",
            ["ImageHashKeyError"] = "ImageHash のキーは Body, Comments, または DescriptionA〜Z/Description001〜999 である必要があります。",
            ["InvalidDirectoryPath"] = "無効なディレクトリパスです: {0}",
            ["NoPermissionToCreateDirectory"] = "ディレクトリの作成権限がありません: {0}",
            ["FailedToCreateDirectory"] = "ディレクトリの作成に失敗しました: {0}",
            ["NoWritePermissionForDirectory"] = "ディレクトリへの書き込み権限がありません: {0}",
            ["WriteTestFailedForDirectory"] = "ディレクトリへの書き込みテストに失敗しました: {0}",
            ["UnsupportedImportEncoding"] = "エンコーディングは UTF-8 または Shift-JIS である必要があります。その他のエンコーディングはサポートされていません。",
            ["FileNotFound"] = "ファイルが見つかりません: {0}",
        }
    };

    private static CultureInfo? culture;

    /// <summary>
    /// Gets or sets the culture used for message lookup.
    /// If null, CultureInfo.CurrentUICulture is used.
    /// </summary>
    internal static CultureInfo? Culture
    {
        get => culture;
        set => culture = value;
    }

    /// <summary>
    /// Gets the message for the specified key based on the current culture.
    /// </summary>
    private static string GetMessage(string key)
    {
        var currentCulture = Culture ?? CultureInfo.CurrentUICulture;
        var languageCode = currentCulture.TwoLetterISOLanguageName;

        if (LocalizedMessages.TryGetValue(languageCode, out var messages) &&
            messages.TryGetValue(key, out var message))
        {
            return message;
        }

        // Fallback to English
        if (LocalizedMessages["en"].TryGetValue(key, out var fallbackMessage))
        {
            return fallbackMessage;
        }

        return key;
    }

    /// <summary>
    /// The key of ColumnFilterHash must be a valid Pleasanter column name.
    /// </summary>
    internal static string ColumnFilterHashKeyError => GetMessage(nameof(ColumnFilterHashKeyError));

    /// <summary>
    /// The key of ColumnFilterSearchTypes must be a valid Pleasanter column name.
    /// </summary>
    internal static string ColumnFilterSearchTypesKeyError => GetMessage(nameof(ColumnFilterSearchTypesKeyError));

    /// <summary>
    /// The value of ColumnFilterNegatives must be a valid Pleasanter column name.
    /// </summary>
    internal static string ColumnFilterNegativesValueError => GetMessage(nameof(ColumnFilterNegativesValueError));

    /// <summary>
    /// The key of ColumnSorterHash must be a valid Pleasanter column name.
    /// </summary>
    internal static string ColumnSorterHashKeyError => GetMessage(nameof(ColumnSorterHashKeyError));

    /// <summary>
    /// The key of ApiColumnHash must be a valid Pleasanter column name.
    /// </summary>
    internal static string ApiColumnHashKeyError => GetMessage(nameof(ApiColumnHashKeyError));

    /// <summary>
    /// The value of GridColumns must be a valid Pleasanter column name.
    /// </summary>
    internal static string GridColumnsValueError => GetMessage(nameof(GridColumnsValueError));

    /// <summary>
    /// The key of ClassHash must be ClassA-Z or Class001-999.
    /// </summary>
    internal static string ClassHashKeyError => GetMessage(nameof(ClassHashKeyError));

    /// <summary>
    /// The key of NumHash must be NumA-Z or Num001-999.
    /// </summary>
    internal static string NumHashKeyError => GetMessage(nameof(NumHashKeyError));

    /// <summary>
    /// The key of DateHash must be DateA-Z or Date001-999.
    /// </summary>
    internal static string DateHashKeyError => GetMessage(nameof(DateHashKeyError));

    /// <summary>
    /// The key of DescriptionHash must be DescriptionA-Z or Description001-999.
    /// </summary>
    internal static string DescriptionHashKeyError => GetMessage(nameof(DescriptionHashKeyError));

    /// <summary>
    /// The key of CheckHash must be CheckA-Z or Check001-999.
    /// </summary>
    internal static string CheckHashKeyError => GetMessage(nameof(CheckHashKeyError));

    /// <summary>
    /// The key of AttachmentsHash must be AttachmentsA-Z or Attachments001-999.
    /// </summary>
    internal static string AttachmentsHashKeyError => GetMessage(nameof(AttachmentsHashKeyError));

    /// <summary>
    /// The key of ImageHash must be Body, Comments, or DescriptionA-Z/Description001-999.
    /// </summary>
    internal static string ImageHashKeyError => GetMessage(nameof(ImageHashKeyError));

    /// <summary>
    /// Invalid directory path: {0}
    /// </summary>
    internal static string InvalidDirectoryPath(string path) => string.Format(GetMessage(nameof(InvalidDirectoryPath)), path);

    /// <summary>
    /// No permission to create directory: {0}
    /// </summary>
    internal static string NoPermissionToCreateDirectory(string path) => string.Format(GetMessage(nameof(NoPermissionToCreateDirectory)), path);

    /// <summary>
    /// Failed to create directory: {0}
    /// </summary>
    internal static string FailedToCreateDirectory(string path) => string.Format(GetMessage(nameof(FailedToCreateDirectory)), path);

    /// <summary>
    /// No write permission for directory: {0}
    /// </summary>
    internal static string NoWritePermissionForDirectory(string path) => string.Format(GetMessage(nameof(NoWritePermissionForDirectory)), path);

    /// <summary>
    /// Write test failed for directory: {0}
    /// </summary>
    internal static string WriteTestFailedForDirectory(string path) => string.Format(GetMessage(nameof(WriteTestFailedForDirectory)), path);

    /// <summary>
    /// The encoding must be UTF-8 or Shift-JIS. Other encodings are not supported.
    /// </summary>
    internal static string UnsupportedImportEncoding => GetMessage(nameof(UnsupportedImportEncoding));

    /// <summary>
    /// File not found: {0}
    /// </summary>
    internal static string FileNotFound(string path) => string.Format(GetMessage(nameof(FileNotFound)), path);
}
