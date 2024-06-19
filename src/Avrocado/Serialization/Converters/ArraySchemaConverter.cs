using System.Text.Json;
using Avrocado.Serialization.Metadata.Schemas;

namespace Avrocado.Serialization.Converters;

internal class ArraySchemaConverter : TrackedConverter<ArraySchema>
{
    public override ArraySchema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        reader.ReadObject();

        var schema = new ArraySchema();

        while (reader.IsInObject())
        {
            var property = reader.ReadMember();

            if (property == "items")
            {
                schema.ItemSchema = reader.ReadTracked<Schema>(tracked, options)!;
            }
            else
            {
                reader.Skip();
            }

            reader.Read();
        }

        if (schema.ItemSchema == null)
        {
            throw new InvalidOperationException("Array does not have 'items' property");
        }

        return schema;
    }

    public override void Write(Utf8JsonWriter writer, ArraySchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("type", value.Tag.ToStringType());
        writer.WritePropertyName("items");
        writer.WriteTracked(value.ItemSchema, tracked, options);
        writer.WriteEndObject();
    }
}
