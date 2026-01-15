namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// プリザンターの列名パターン定義
/// </summary>
public static class ColumnPatterns
{
    /// <summary>
    /// プリザンターの列名パターン（Class[A-Z], Class[001-999], Num[A-Z], Num[001-999], Date[A-Z], Date[001-999], Description[A-Z], Description[001-999], Check[A-Z], Check[001-999], Title, Body, Status など）
    /// </summary>
    public const string ColumnNamePattern = @"^(Class|Num|Date|Description|Check)([A-Z]|[0-9]{3})$|^(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments)$";

    /// <summary>
    /// GridColumns用の列名パターン（通常の列名パターン、またはClass系列名に親テーブル参照形式「Class列名~サイトID,列名」も許可。Class列名~サイトID,は連続指定可能）
    /// </summary>
    public const string GridColumnNamePattern = @"^((Num|Date|Description|Check)([A-Z]|[0-9]{3})|(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments))$|^Class([A-Z]|[0-9]{3})(~[0-9]+,Class([A-Z]|[0-9]{3}))*(~[0-9]+,((Class|Num|Date|Description|Check)([A-Z]|[0-9]{3})|(Title|Body|Status|Manager|Owner|SiteId|IssueId|ResultId|Ver|Creator|Updator|CreatedTime|UpdatedTime|Comments)))?$";

    /// <summary>
    /// ImageHash用のキー名パターン（Body, Comments, DescriptionA〜DescriptionZ, Description001〜Description999）
    /// </summary>
    public const string ImageHashKeyPattern = @"^(Body|Comments|Description([A-Z]|[0-9]{3}))$";
}
