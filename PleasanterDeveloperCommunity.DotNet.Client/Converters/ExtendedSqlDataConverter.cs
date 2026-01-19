using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.ExtendedSql;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Converters;

/// <summary>
/// ExtendedSqlData用のJsonConverter
/// </summary>
internal class ExtendedSqlDataConverter : JsonConverter<ExtendedSqlData>
{
    public override ExtendedSqlData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var data = new ExtendedSqlData();

        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        // Table, Table1, Table2... の順番でプロパティを処理
        if (root.TryGetProperty("Table", out var table) && table.ValueKind == JsonValueKind.Array)
        {
            data.Tables.Add(new ExtendedSqlTable
            {
                Name = "Table",
                Rows = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(table.GetRawText(), options) ?? new List<Dictionary<string, object>>()
            });
        }

        // Table1 以降を処理
        for (int i = 1; i <= 100; i++)
        {
            var tableName = $"Table{i}";
            if (root.TryGetProperty(tableName, out var tableN) && tableN.ValueKind == JsonValueKind.Array)
            {
                data.Tables.Add(new ExtendedSqlTable
                {
                    Name = tableName,
                    Rows = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(tableN.GetRawText(), options) ?? new List<Dictionary<string, object>>()
                });
            }
            else
            {
                break;
            }
        }

        return data;
    }

    public override void Write(Utf8JsonWriter writer, ExtendedSqlData? value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        if (value?.Tables != null)
        {
            foreach (var table in value.Tables)
            {
                writer.WritePropertyName(table.Name);
                JsonSerializer.Serialize(writer, table.Rows, options);
            }
        }

        writer.WriteEndObject();
    }
}
