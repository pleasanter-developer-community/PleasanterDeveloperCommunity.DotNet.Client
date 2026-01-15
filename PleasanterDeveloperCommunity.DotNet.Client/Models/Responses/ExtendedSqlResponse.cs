using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

/// <summary>
/// 拡張SQL APIレスポンス
/// </summary>
public class ExtendedSqlResponse
{
    /// <summary>
    /// レスポンスデータ
    /// </summary>
    [JsonProperty("Data")]
    public ExtendedSqlData? Data { get; set; }
}

/// <summary>
/// 拡張SQLレスポンスのデータ部分
/// </summary>
[JsonConverter(typeof(ExtendedSqlDataConverter))]
public class ExtendedSqlData
{
    /// <summary>
    /// テーブル結果のリスト（Table, Table1, Table2...を順番に格納）
    /// </summary>
    public List<ExtendedSqlTable> Tables { get; set; } = new List<ExtendedSqlTable>();
}

/// <summary>
/// 拡張SQLのテーブル結果
/// </summary>
public class ExtendedSqlTable
{
    /// <summary>
    /// テーブル名（Table, Table1, Table2...）
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// テーブルの行データ
    /// </summary>
    public List<Dictionary<string, object>> Rows { get; set; } = new List<Dictionary<string, object>>();
}

/// <summary>
/// ExtendedSqlData用のJsonConverter
/// </summary>
internal class ExtendedSqlDataConverter : JsonConverter<ExtendedSqlData>
{
    public override ExtendedSqlData? ReadJson(JsonReader reader, Type objectType, ExtendedSqlData? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var data = new ExtendedSqlData();
        var jObject = JObject.Load(reader);

        // Table, Table1, Table2... の順番でプロパティを処理
        if (jObject["Table"] is JArray table)
        {
            data.Tables.Add(new ExtendedSqlTable
            {
                Name = "Table",
                Rows = table.ToObject<List<Dictionary<string, object>>>(serializer) ?? new List<Dictionary<string, object>>()
            });
        }

        // Table1 以降を処理
        for (int i = 1; i <= 100; i++)
        {
            var tableName = $"Table{i}";
            if (jObject[tableName] is JArray tableN)
            {
                data.Tables.Add(new ExtendedSqlTable
                {
                    Name = tableName,
                    Rows = tableN.ToObject<List<Dictionary<string, object>>>(serializer) ?? new List<Dictionary<string, object>>()
                });
            }
            else
            {
                break;
            }
        }

        return data;
    }

    public override void WriteJson(JsonWriter writer, ExtendedSqlData? value, JsonSerializer serializer)
    {
        writer.WriteStartObject();

        if (value?.Tables != null)
        {
            foreach (var table in value.Tables)
            {
                writer.WritePropertyName(table.Name);
                serializer.Serialize(writer, table.Rows);
            }
        }

        writer.WriteEndObject();
    }
}

