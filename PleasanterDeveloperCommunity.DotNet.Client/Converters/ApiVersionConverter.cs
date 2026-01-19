using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PleasanterDeveloperCommunity.DotNet.Client.Converters;

/// <summary>
/// APIバージョンをfloatから"#.#"形式の文字列にシリアライズするコンバーター
/// </summary>
public class ApiVersionConverter : JsonConverter<float>
{
    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("0.0"));
    }

    /// <inheritdoc />
    public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString();
            return str != null ? float.Parse(str) : 0f;
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetSingle();
        }

        throw new JsonException($"Unexpected token type: {reader.TokenType}");
    }
}
