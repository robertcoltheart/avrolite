using System.Text.Json;
using AvroSerialize.Serialization.Metadata.Schemas;

namespace AvroSerialize.Serialization.Converters;

public class SchemaConverter : TrackedConverter<Schema>
{
    public override Schema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var type = reader.GetString();

            return new PrimitiveSchema(SchemaType.Logical)
            {
                Type = type!
            };
        }

        if (reader.TokenType == JsonTokenType.StartArray)
        {

        }

        if (reader.TokenType == JsonTokenType.StartObject)
        {
            var type = reader.GetSchemaType();

            if (type.Type == "array")
            {
                return reader.ReadTracked<ArraySchema>(tracked, options);
            }

            if (type.Type == "map")
            {
                return reader.ReadTracked<MapSchema>(tracked, options);
            }

            if (!string.IsNullOrEmpty(type.LogicalType))
            {
                return reader.ReadTracked<LogicalSchema>(tracked, options);
            }

            return type.Type switch
            {
                "enum" => reader.ReadTracked<EnumSchema>(tracked, options),
                "record" => reader.ReadTracked<RecordSchema>(tracked, options),
                _ => throw new InvalidOperationException()
            };
        }

        throw new InvalidOperationException();
    }

    public override Schema? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var tracked = new TrackedResources();

        return Read(ref reader, typeToConvert, tracked, options);
    }

    public override void Write(Utf8JsonWriter writer, Schema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Schema value, JsonSerializerOptions options)
    {
        var tracked = new TrackedResources();

        Write(writer, value, tracked, options);
    }
}
