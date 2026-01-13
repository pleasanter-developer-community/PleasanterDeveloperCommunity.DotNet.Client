using Newtonsoft.Json;
using pleasanter_dotnet_client.Models.Requests.Types;

namespace pleasanter_dotnet_client.Models.Requests;

/// <summary>
/// APIカラム設定（ApiColumnHashの値として使用）
/// </summary>
public class ApiColumnSetting
{
    /// <summary>
    /// キーの表示タイプ
    /// </summary>
    [JsonProperty("KeyDisplayType")]
    public ApiColumnKeyDisplayType? KeyDisplayType { get; set; }

    /// <summary>
    /// 値の表示タイプ
    /// </summary>
    [JsonProperty("ValueDisplayType")]
    public ApiColumnValueDisplayType? ValueDisplayType { get; set; }
}
