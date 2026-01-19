using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

/// <summary>
/// レコード更新リクエスト
/// </summary>
public class UpdateRecordRequest : RecordRequestBase
{
    /// <summary>
    /// レコードのアクセス制御（例："Dept,1,31", "Group,1,511", "User,10,1"）
    /// </summary>
    [JsonPropertyName("RecordPermissions")]
    public List<string>? RecordPermissions { get; set; }
}
