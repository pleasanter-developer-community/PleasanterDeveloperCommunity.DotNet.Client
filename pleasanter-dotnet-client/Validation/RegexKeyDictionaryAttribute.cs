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
    private readonly Regex _regex;

    /// <summary>
    /// キーの検証に使用する正規表現パターン
    /// </summary>
    public string Pattern { get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="pattern">正規表現パターン</param>
    public RegexKeyDictionaryAttribute(string pattern)
        : this(pattern, RegexOptions.None)
    {
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="pattern">正規表現パターン</param>
    /// <param name="options">正規表現オプション</param>
    public RegexKeyDictionaryAttribute(string pattern, RegexOptions options)
    {
        Pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
        _regex = new Regex(pattern, options);
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

        var invalidKeys = new List<string>();

        if (value is IDictionary<string, string> stringDict)
        {
            foreach (var key in stringDict.Keys)
            {
                if (!_regex.IsMatch(key))
                {
                    invalidKeys.Add(key);
                }
            }
        }
        else if (value is IDictionary<string, object> objectDict)
        {
            foreach (var key in objectDict.Keys)
            {
                if (!_regex.IsMatch(key))
                {
                    invalidKeys.Add(key);
                }
            }
        }
        else
        {
            // Handle generic dictionary types via reflection
            var valueType = value.GetType();
            if (valueType.IsGenericType)
            {
                var genericTypeDef = valueType.GetGenericTypeDefinition();
                if (genericTypeDef == typeof(Dictionary<,>) || genericTypeDef == typeof(IDictionary<,>))
                {
                    var keysProperty = valueType.GetProperty("Keys");
                    if (keysProperty?.GetValue(value) is IEnumerable<string> keys)
                    {
                        foreach (var key in keys)
                        {
                            if (!_regex.IsMatch(key))
                            {
                                invalidKeys.Add(key);
                            }
                        }
                    }
                }
                else
                {
                    return new ValidationResult($"Property {validationContext.DisplayName} is not a supported dictionary type.");
                }
            }
            else
            {
                return new ValidationResult($"Property {validationContext.DisplayName} is not a supported dictionary type.");
            }
        }

        if (invalidKeys.Count > 0)
        {
            var memberNames = validationContext.MemberName is not null
                ? new[] { validationContext.MemberName }
                : null;

            var errorMessage = GetFormattedErrorMessage(validationContext.DisplayName, invalidKeys);

            return new ValidationResult(errorMessage, memberNames);
        }

        return ValidationResult.Success;
    }

    /// <summary>
    /// Gets the formatted error message, using resource if specified.
    /// </summary>
    private string GetFormattedErrorMessage(string displayName, List<string> invalidKeys)
    {
        // Try to use ErrorMessageResourceType and ErrorMessageResourceName if specified
        if (ErrorMessageResourceType is not null && !string.IsNullOrEmpty(ErrorMessageResourceName))
        {
            var property = ErrorMessageResourceType.GetProperty(ErrorMessageResourceName, 
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            if (property?.GetValue(null) is string resourceMessage)
            {
                return resourceMessage;
            }
        }

        // Fallback to ErrorMessage or default
        return ErrorMessage ?? $"The following keys do not match the pattern '{Pattern}': {string.Join(", ", invalidKeys)}";
    }
}
