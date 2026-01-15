using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using System;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Converters;

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
