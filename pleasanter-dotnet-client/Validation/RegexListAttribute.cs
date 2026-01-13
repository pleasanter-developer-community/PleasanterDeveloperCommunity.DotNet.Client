using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace pleasanter_dotnet_client.Validation;

/// <summary>
/// リストの各要素に正規表現の制約をかける検証属性
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class RegexListAttribute(string pattern, RegexOptions options = RegexOptions.None) : ValidationAttribute
{
    private readonly Regex _regex = new(pattern, options);

    /// <summary>
    /// 要素の検証に使用する正規表現パターン
    /// </summary>
    public string Pattern { get; } = pattern ?? throw new ArgumentNullException(nameof(pattern));

    /// <summary>
    /// 検証を行います
    /// </summary>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }

        if (value is not IEnumerable<string> list)
        {
            return new ValidationResult($"Property {validationContext.DisplayName} is not a supported list type.");
        }

        var invalidItems = new List<string>();

        foreach (var item in list)
        {
            if (item is not null && !_regex.IsMatch(item))
            {
                invalidItems.Add(item);
            }
        }

        if (invalidItems.Count > 0)
        {
            var memberNames = validationContext.MemberName is not null
                ? new[] { validationContext.MemberName }
                : null;

            var errorMessage = GetFormattedErrorMessage(invalidItems);

            return new ValidationResult(errorMessage, memberNames);
        }

        return ValidationResult.Success;
    }

    /// <summary>
    /// 指定されたリソースを使用して、フォーマットされたエラーメッセージを取得します。
    /// </summary>
    private string GetFormattedErrorMessage(List<string> invalidItems)
    {
        // ErrorMessageResourceType と ErrorMessageResourceName が指定されている場合は、それを使用しようとします
        if (ErrorMessageResourceType is not null && !string.IsNullOrEmpty(ErrorMessageResourceName))
        {
            var property = ErrorMessageResourceType.GetProperty(ErrorMessageResourceName,
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            if (property?.GetValue(null) is string resourceMessage)
            {
                return resourceMessage;
            }
        }

        // フォールバックとして ErrorMessage またはデフォルトに戻る
        return ErrorMessage ?? $"The following items do not match the pattern '{Pattern}': {string.Join(", ", invalidItems)}";
    }
}
