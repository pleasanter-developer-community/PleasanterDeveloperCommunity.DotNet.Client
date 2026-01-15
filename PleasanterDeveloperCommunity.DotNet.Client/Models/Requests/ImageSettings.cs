using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

/// <summary>
/// 画像挿入設定
/// </summary>
public class ImageSettings
{
    /// <summary>
    /// 先頭に改行を挿入するか
    /// </summary>
    [JsonProperty("HeadNewLine")]
    public bool? HeadNewLine { get; set; }

    /// <summary>
    /// 末尾に改行を挿入するか
    /// </summary>
    [JsonProperty("EndNewLine")]
    public bool? EndNewLine { get; set; }

    /// <summary>
    /// 画像を挿入する位置（-1または省略で末尾）
    /// </summary>
    [JsonProperty("Position")]
    public int? Position { get; set; }

    /// <summary>
    /// alt属性に設定する文字列
    /// </summary>
    [JsonProperty("Alt")]
    public string? Alt { get; set; }

    /// <summary>
    /// ファイル拡張子（例: .png, .jpeg）
    /// </summary>
    [JsonProperty("Extension")]
    public string? Extension { get; set; }

    /// <summary>
    /// Base64エンコードした画像データ
    /// </summary>
    [JsonProperty("Base64")]
    public string? Base64 { get; set; }
}
