using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace pleasanter_dotnet_client.Models;

/// <summary>
/// APIレスポンスの基底クラス
/// </summary>
/// <typeparam name="T">レスポンスデータの型</typeparam>
public class ApiResponse<T> where T : class
{
    /// <summary>
    /// ステータスコード（200: 成功）
    /// </summary>
    [JsonProperty("StatusCode")]
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonProperty("Response")]
    public T? Response { get; set; }

    /// <summary>
    /// メッセージ
    /// </summary>
    [JsonProperty("Message")]
    public string? Message { get; set; }

    /// <summary>
    /// 成功かどうかを判定します
    /// </summary>
    public bool IsSuccess => StatusCode == HttpStatusCode.OK;
}

/// <summary>
/// 単一レコード取得レスポンス
/// </summary>
public class GetRecordResponse
{
    /// <summary>
    /// レコードデータ
    /// </summary>
    [JsonProperty("Data")]
    public List<RecordData>? Data { get; set; }
}

/// <summary>
/// 複数レコード取得レスポンス
/// </summary>
public class GetRecordsResponse
{
    /// <summary>
    /// オフセット
    /// </summary>
    [JsonProperty("Offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// ページサイズ
    /// </summary>
    [JsonProperty("PageSize")]
    public int? PageSize { get; set; }

    /// <summary>
    /// 合計レコード数
    /// </summary>
    [JsonProperty("TotalCount")]
    public int? TotalCount { get; set; }

    /// <summary>
    /// レコードデータ
    /// </summary>
    [JsonProperty("Data")]
    public List<RecordData>? Data { get; set; }

    /// <summary>
    /// 次のページが存在するかを判定します
    /// </summary>
    public bool HasNextPage => Offset.HasValue && PageSize.HasValue && TotalCount.HasValue
        && (Offset.Value + PageSize.Value) < TotalCount.Value;
}

/// <summary>
/// レコード作成・更新（Upsert）レスポンス
/// </summary>
public class UpsertRecordResponse
{
    /// <summary>
    /// レコードID
    /// </summary>
    [JsonProperty("Id")]
    public long Id { get; set; }

    /// <summary>
    /// 1日あたりのAPI呼び出し上限
    /// </summary>
    [JsonProperty("LimitPerDate")]
    public int? LimitPerDate { get; set; }

    /// <summary>
    /// 残りのAPI呼び出し回数
    /// </summary>
    [JsonProperty("LimitRemaining")]
    public int? LimitRemaining { get; set; }
}

/// <summary>
/// レコードデータ（API 1.1対応）
/// </summary>
public class RecordData
{
    /// <summary>
    /// サイトID
    /// </summary>
    [JsonProperty("SiteId")]
    public long SiteId { get; set; }

    /// <summary>
    /// レコードID（Issues）
    /// </summary>
    [JsonProperty("IssueId")]
    public long? IssueId { get; set; }

    /// <summary>
    /// レコードID（Results）
    /// </summary>
    [JsonProperty("ResultId")]
    public long? ResultId { get; set; }

    /// <summary>
    /// レコードIDを取得します（IssueIdまたはResultId）
    /// </summary>
    public long? RecordId => IssueId ?? ResultId;

    /// <summary>
    /// 更新日時
    /// </summary>
    [JsonProperty("UpdatedTime")]
    public string? UpdatedTime { get; set; }

    /// <summary>
    /// バージョン
    /// </summary>
    [JsonProperty("Ver")]
    public int? Ver { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    [JsonProperty("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonProperty("Body")]
    public string? Body { get; set; }

    /// <summary>
    /// 状況
    /// </summary>
    [JsonProperty("Status")]
    public int? Status { get; set; }

    /// <summary>
    /// 管理者
    /// </summary>
    [JsonProperty("Manager")]
    public int? Manager { get; set; }

    /// <summary>
    /// 担当者
    /// </summary>
    [JsonProperty("Owner")]
    public int? Owner { get; set; }

    /// <summary>
    /// コメント
    /// </summary>
    [JsonProperty("Comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    [JsonProperty("Creator")]
    public int? Creator { get; set; }

    /// <summary>
    /// 更新者
    /// </summary>
    [JsonProperty("Updator")]
    public int? Updator { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    [JsonProperty("CreatedTime")]
    public string? CreatedTime { get; set; }

    /// <summary>
    /// 分類項目（API 1.1: ClassA?ClassZ, Class001?Class999）
    /// </summary>
    [JsonProperty("ClassHash")]
    public Dictionary<string, string>? ClassHash { get; set; }

    /// <summary>
    /// 数値項目（API 1.1: NumA?NumZ, Num001?Num999）
    /// </summary>
    [JsonProperty("NumHash")]
    public Dictionary<string, decimal>? NumHash { get; set; }

    /// <summary>
    /// 日付項目（API 1.1: DateA?DateZ, Date001?Date999）
    /// </summary>
    [JsonProperty("DateHash")]
    public Dictionary<string, string>? DateHash { get; set; }

    /// <summary>
    /// 説明項目（API 1.1: DescriptionA?DescriptionZ, Description001?Description999）
    /// </summary>
    [JsonProperty("DescriptionHash")]
    public Dictionary<string, string>? DescriptionHash { get; set; }

    /// <summary>
    /// チェック項目（API 1.1: CheckA?CheckZ, Check001?Check999）
    /// </summary>
    [JsonProperty("CheckHash")]
    public Dictionary<string, bool>? CheckHash { get; set; }

    /// <summary>
    /// 分類項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: ClassA, Class001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public string? GetClass(string columnName)
    {
        if (ClassHash is null)
        {
            return null;
        }

        return ClassHash.TryGetValue(columnName, out var value) ? value : null;
    }

    /// <summary>
    /// 数値項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: NumA, Num001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public decimal? GetNum(string columnName)
    {
        if (NumHash is null)
        {
            return null;
        }

        return NumHash.TryGetValue(columnName, out var value) ? value : null;
    }

    /// <summary>
    /// 日付項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: DateA, Date001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public string? GetDate(string columnName)
    {
        if (DateHash is null)
        {
            return null;
        }

        return DateHash.TryGetValue(columnName, out var value) ? value : null;
    }

    /// <summary>
    /// 説明項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: DescriptionA, Description001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public string? GetDescription(string columnName)
    {
        if (DescriptionHash is null)
        {
            return null;
        }

        return DescriptionHash.TryGetValue(columnName, out var value) ? value : null;
    }

    /// <summary>
    /// チェック項目の値を取得します
    /// </summary>
    /// <param name="columnName">列名（例: CheckA, Check001）</param>
    /// <returns>値（存在しない場合はnull）</returns>
    public bool? GetCheck(string columnName)
    {
        if (CheckHash is null)
        {
            return null;
        }

        return CheckHash.TryGetValue(columnName, out var value) ? value : null;
    }
}
