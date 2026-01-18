using System;
using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Converters;

/// <summary>
/// APIバージョンをfloatから"#.#"形式の文字列にシリアライズするコンバーター
/// </summary>
public class ApiVersionConverter : JsonConverter<float>
{
    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, float value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString("0.0"));
    }

    /// <inheritdoc />
    public override float ReadJson(JsonReader reader, Type objectType, float existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
        {
            return existingValue;
        }

        if (reader.TokenType == JsonToken.String)
        {
            return float.Parse((string)reader.Value);
        }

        if (reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Integer)
        {
            return Convert.ToSingle(reader.Value);
        }

        throw new JsonSerializationException($"Unexpected token type: {reader.TokenType}");
    }
}
