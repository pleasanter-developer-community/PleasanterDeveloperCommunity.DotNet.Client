using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace pleasanter_dotnet_client.Validation;

/// <summary>
/// リストの各要素に正規表現の制約をかける検証属性
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class RegexListAttribute : ValidationAttribute
{
    /// <summary>
    /// 要素の検証に使用する正規表現パターン
    /// </summary>
    public string Pattern { get; }

    /// <summary>
    /// 正規表現オプション
    /// </summary>
    public RegexOptions RegexOptions { get; set; } = RegexOptions.None;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="pattern">正規表現パターン</param>
    public RegexListAttribute(string pattern)
    {
        Pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
    }

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

        var regex = new Regex(Pattern, RegexOptions);
        var invalidItems = new List<string>();

        foreach (var item in list)
        {
            if (item is not null && !regex.IsMatch(item))
            {
                invalidItems.Add(item);
            }
        }

        if (invalidItems.Count > 0)
        {
            var memberNames = validationContext.MemberName is not null
                ? new[] { validationContext.MemberName }
                : null;

            return new ValidationResult(
                ErrorMessage ?? $"The following items do not match the pattern '{Pattern}': {string.Join(", ", invalidItems)}",
                memberNames);
        }

        return ValidationResult.Success;
    }
}
