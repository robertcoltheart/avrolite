using System.Text.Json;
using Avrocado.Serialization.Metadata.Schemas;

namespace Avrocado.Serialization.Converters;

internal class EnumSchemaConverter : NamedSchemaConverter<EnumSchema>
{
    public override void ReadField(ref Utf8JsonReader reader, EnumSchema schema, string property, TrackedResources tracked, JsonSerializerOptions options)
    {
        if (property == "symbols")
        {
            schema.Symbols = JsonSerializer.Deserialize<List<string>>(ref reader, options)!;
        }
        else if (property == "default")
        {
            schema.Default = reader.GetString();
        }
        else
        {
            reader.Skip();
        }
    }

    public override void WriteFields(Utf8JsonWriter writer, EnumSchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        writer.WritePropertyName("symbols");
        JsonSerializer.Serialize(value.Symbols, options);

        writer.WriteStringOrDefault("default", value.Default);
    }

    public override void Validate(EnumSchema schema)
    {
        if (!schema.Symbols.Any())
        {
            throw new SchemaParseException($"Enum has no symbols: {schema.Name}");
        }

        if (schema.Symbols.GroupBy(x => x).Any(x => x.Count() > 1))
        {
            throw new SchemaParseException($"Enum has duplicate symbols: {schema.Name}");
        }

        if (!string.IsNullOrEmpty(schema.Default) && !schema.Symbols.Contains(schema.Default))
        {
            throw new SchemaParseException($"Default symbol {schema.Default} not found in {schema.Name}");
        }
    }
}
