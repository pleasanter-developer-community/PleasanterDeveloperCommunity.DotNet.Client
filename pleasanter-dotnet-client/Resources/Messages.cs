namespace pleasanter_dotnet_client.Resources;

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
        },
        ["ja"] = new Dictionary<string, string>
        {
            ["ColumnFilterHashKeyError"] = "ColumnFilterHash のキーはプリザンターの有効な列名である必要があります。",
            ["ColumnFilterSearchTypesKeyError"] = "ColumnFilterSearchTypes のキーはプリザンターの有効な列名である必要があります。",
            ["ColumnFilterNegativesValueError"] = "ColumnFilterNegatives の値はプリザンターの有効な列名である必要があります。",
            ["ColumnSorterHashKeyError"] = "ColumnSorterHash のキーはプリザンターの有効な列名である必要があります。",
            ["ApiColumnHashKeyError"] = "ApiColumnHash のキーはプリザンターの有効な列名である必要があります。",
            ["GridColumnsValueError"] = "GridColumns の値はプリザンターの有効な列名である必要があります。",
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
}
