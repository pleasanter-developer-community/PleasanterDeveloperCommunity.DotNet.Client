using System.Text.Json.Serialization;

namespace VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Sessions;

/// <summary>
/// セッション取得リクエスト
/// </summary>
public class GetSessionRequest : ApiRequestBase
{
    /// <summary>
    /// セッションキー
    /// </summary>
    [JsonPropertyName("SessionKey")]
    public string? SessionKey { get; set; }

    /// <summary>
    /// ユーザー単位で保存するかどうか
    /// </summary>
    /// <remarks>
    /// <c>true</c>の場合、セッションはユーザー単位で保存され、有効期限切れによる自動削除の対象外となります。
    /// <c>false</c>（デフォルト）の場合、セッションはセッションGUID単位で保存され、RetentionPeriod（デフォルト24時間）経過後に削除されます。
    /// </remarks>
    public bool SavePerUser { get; set; }
}

/// <summary>
/// セッション設定リクエスト
/// </summary>
public class SetSessionRequest : ApiRequestBase
{
    /// <summary>
    /// セッションキー
    /// </summary>
    [JsonPropertyName("SessionKey")]
    public string? SessionKey { get; set; }

    /// <summary>
    /// セッション値
    /// </summary>
    [JsonPropertyName("SessionValue")]
    public string? SessionValue { get; set; }

    /// <summary>
    /// ユーザー単位で保存するかどうか
    /// </summary>
    /// <remarks>
    /// <c>true</c>の場合、セッションはユーザー単位で保存され、有効期限切れによる自動削除の対象外となります。
    /// <c>false</c>（デフォルト）の場合、セッションはセッションGUID単位で保存され、RetentionPeriod（デフォルト24時間）経過後に削除されます。
    /// </remarks>
    public bool SavePerUser { get; set; }
}

/// <summary>
/// セッション削除リクエスト
/// </summary>
public class DeleteSessionRequest : ApiRequestBase
{
    /// <summary>
    /// セッションキー
    /// </summary>
    [JsonPropertyName("SessionKey")]
    public string? SessionKey { get; set; }

    /// <summary>
    /// ユーザー単位で保存するかどうか
    /// </summary>
    /// <remarks>
    /// <c>true</c>の場合、ユーザー単位で保存されたセッションを対象とします。
    /// <c>false</c>（デフォルト）の場合、セッションGUID単位で保存されたセッションを対象とします。
    /// </remarks>
    public bool SavePerUser { get; set; }
}
