using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.BackgroundTasks;

/// <summary>
/// 検索インデックス再構築レスポンス
/// </summary>
public class RebuildSearchIndexesResponse
{
    public long Id { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}
