using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Validation;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// 添付ファイルデータ
/// </summary>
public class AttachmentData
{
    /// <summary>
    /// コンテンツタイプ（例: "text/plain", "image/png"）
    /// </summary>
    [JsonProperty("ContentType")]
    [ContentType(ErrorMessage = "ContentType must be a valid MIME type (e.g., 'text/plain', 'image/png').")]
    public string? ContentType { get; set; }

    /// <summary>
    /// ファイル名
    /// </summary>
    [JsonProperty("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// Base64エンコードされたファイルデータ
    /// </summary>
    [JsonProperty("Base64")]
    public string? Base64 { get; set; }
}
