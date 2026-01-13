using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace pleasanter_dotnet_client.Validation;

/// <summary>
/// Dictionary のキーに正規表現の制約を加える検証属性
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class RegexKeyDictionaryAttribute : ValidationAttribute
{
    /// <summary>
    /// キーの検証に使用する正規表現パターン
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
    public RegexKeyDictionaryAttribute(string pattern)
    {
        Pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
    }

    /// <summary>
    /// 検証を実行します
    /// </summary>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }

        var regex = new Regex(Pattern, RegexOptions);
        var invalidKeys = new List<string>();

        if (value is IDictionary<string, string> stringDict)
        {
            foreach (var key in stringDict.Keys)
            {
                if (!regex.IsMatch(key))
                {
                    invalidKeys.Add(key);
                }
            }
        }
        else if (value is IDictionary<string, object> objectDict)
        {
            foreach (var key in objectDict.Keys)
            {
                if (!regex.IsMatch(key))
                {
                    invalidKeys.Add(key);
                }
            }
        }
        else
        {
            return new ValidationResult($"Property {validationContext.DisplayName} is not a supported dictionary type.");
        }

        if (invalidKeys.Count > 0)
        {
            var memberNames = validationContext.MemberName is not null
                ? new[] { validationContext.MemberName }
                : null;

            return new ValidationResult(
                ErrorMessage ?? $"The following keys do not match the pattern '{Pattern}': {string.Join(", ", invalidKeys)}",
                memberNames);
        }

        return ValidationResult.Success;
    }
}
