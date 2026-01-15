using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PleasanterDeveloperCommunity.DotNet.Client.Validation;

/// <summary>
/// MIMEタイプの妥当性を検証する属性
/// </summary>
/// <remarks>
/// RFC 2045 に基づいたMIMEタイプ形式（type/subtype）を検証します。
/// 例: "text/plain", "image/png", "application/json"
/// </remarks>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class ContentTypeAttribute : ValidationAttribute
{
    /// <summary>
    /// MIMEタイプの正規表現パターン
    /// RFC 2045 に基づく: type "/" subtype
    /// type: 登録済みのトップレベルタイプまたは "x-" プレフィックス付きの拡張タイプ
    /// subtype: 英数字、ハイフン、ドット、プラス記号を含む
    /// </summary>
    private static readonly Regex MimeTypeRegex = new(
        @"^(application|audio|font|image|message|model|multipart|text|video|x-[a-z0-9\-]+)/[a-zA-Z0-9\-\.\+]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// 検証を実行します
    /// </summary>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }

        if (value is not string contentType)
        {
            return new ValidationResult(
                FormatErrorMessage(validationContext.DisplayName),
                [validationContext.MemberName!]);
        }

        if (string.IsNullOrWhiteSpace(contentType))
        {
            return ValidationResult.Success;
        }

        // パラメータ部分（charset=utf-8 など）を除去して検証
        var mimeType = contentType.Split(';')[0].Trim();

        if (!MimeTypeRegex.IsMatch(mimeType))
        {
            return new ValidationResult(
                FormatErrorMessage(validationContext.DisplayName),
                [validationContext.MemberName!]);
        }

        return ValidationResult.Success;
    }

    /// <summary>
    /// デフォルトのエラーメッセージを取得します
    /// </summary>
    public override string FormatErrorMessage(string name)
    {
        return string.IsNullOrEmpty(ErrorMessage)
            ? $"The field {name} must be a valid MIME type (e.g., 'text/plain', 'image/png')."
            : base.FormatErrorMessage(name);
    }
}
