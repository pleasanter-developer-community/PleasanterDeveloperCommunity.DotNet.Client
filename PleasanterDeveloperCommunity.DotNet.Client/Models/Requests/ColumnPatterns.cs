namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// プリザンターの列名パターン定義
/// </summary>
public static class ColumnPatterns
{
    /// <summary>
    /// 3桁数値パターン（001〜999）
    /// </summary>
    private const string ThreeDigitPattern = @"(00[1-9]|0[1-9][0-9]|[1-9][0-9]{2})";

    /// <summary>
    /// サフィックスパターン（A〜Z または 001〜999）
    /// </summary>
    private const string SuffixPattern = $@"([A-Z]|{ThreeDigitPattern})";

    /// <summary>
    /// 非負整数パターン（0以上の整数、先頭の0は不可）
    /// </summary>
    private const string NonNegativeIntegerPattern = @"(0|[1-9][0-9]*)";

    /// <summary>
    /// プリザンターの列名パターン（Class[A-Z], Class[001-999], Num[A-Z], Num[001-999], Date[A-Z], Date[001-999], Description[A-Z], Description[001-999], Check[A-Z], Check[001-999], Title, Body, Status など）
    /// </summary>
    public const string ColumnNamePattern = $@"^(Class|Num|Date|Description|Check){SuffixPattern}$|^(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments)$";

    /// <summary>
    /// GridColumns用の列名パターン（通常の列名パターン、またはClass系列名に親テーブル参照形式「Class列名~サイトID,列名」も許可。Class列名~サイトID,は連続指定可能）
    /// </summary>
    public const string GridColumnNamePattern = $@"^((Num|Date|Description|Check){SuffixPattern}|(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments))$|^Class{SuffixPattern}(~{NonNegativeIntegerPattern},Class{SuffixPattern})*(~{NonNegativeIntegerPattern},((Class|Num|Date|Description|Check){SuffixPattern}|(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments)))?$";

    /// <summary>
    /// ClassHash用のキー名パターン（ClassA〜ClassZ, Class001〜Class999）
    /// </summary>
    public const string ClassHashKeyPattern = $@"^Class{SuffixPattern}$";

    /// <summary>
    /// NumHash用のキー名パターン（NumA〜NumZ, Num001〜Num999）
    /// </summary>
    public const string NumHashKeyPattern = $@"^Num{SuffixPattern}$";

    /// <summary>
    /// DateHash用のキー名パターン（DateA〜DateZ, Date001〜Date999）
    /// </summary>
    public const string DateHashKeyPattern = $@"^Date{SuffixPattern}$";

    /// <summary>
    /// DescriptionHash用のキー名パターン（DescriptionA〜DescriptionZ, Description001〜Description999）
    /// </summary>
    public const string DescriptionHashKeyPattern = $@"^Description{SuffixPattern}$";

    /// <summary>
    /// CheckHash用のキー名パターン（CheckA〜CheckZ, Check001〜Check999）
    /// </summary>
    public const string CheckHashKeyPattern = $@"^Check{SuffixPattern}$";

    /// <summary>
    /// AttachmentsHash用のキー名パターン（AttachmentsA〜AttachmentsZ, Attachments001〜Attachments999）
    /// </summary>
    public const string AttachmentsHashKeyPattern = $@"^Attachments{SuffixPattern}$";

    /// <summary>
    /// ImageHash用のキー名パターン（Body, Comments, DescriptionA〜DescriptionZ, Description001〜Description999）
    /// </summary>
    public const string ImageHashKeyPattern = $@"^(Body|Comments|Description{SuffixPattern})$";
}
