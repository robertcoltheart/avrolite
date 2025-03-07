using System.Text.Json;
using Avrolite.Serialization.Metadata.Schemas;

namespace Avrolite.Serialization.Converters;

internal class SchemaConverter : TrackedConverter<Schema>
{
    private readonly Dictionary<string, Func<PrimitiveSchema>> primitiveTypes = new()
    {
        { "null", () => new PrimitiveSchema(SchemaType.Null) },
        { "boolean", () => new PrimitiveSchema(SchemaType.Boolean) },
        { "int", () => new PrimitiveSchema(SchemaType.Int) },
        { "long", () => new PrimitiveSchema(SchemaType.Long) },
        { "float", () => new PrimitiveSchema(SchemaType.Float) },
        { "double", () => new PrimitiveSchema(SchemaType.Double) },
        { "bytes", () => new PrimitiveSchema(SchemaType.Bytes) },
        { "string", () => new PrimitiveSchema(SchemaType.String) }
    };

    public override Schema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var type = reader.GetString();

            if ( primitiveTypes.TryGetValue(type, out var factory))
            {
                return factory();
            }

            return type switch
            {
                "null" => new PrimitiveSchema(SchemaType.Null),
                "boolean" => new PrimitiveSchema(SchemaType.Boolean),
                "int" => new PrimitiveSchema(SchemaType.Int),
                "long" => new PrimitiveSchema(SchemaType.Long),
                "float" => new PrimitiveSchema(SchemaType.Float),
                "double" => new PrimitiveSchema(SchemaType.Double),
                "bytes" => new PrimitiveSchema(SchemaType.Bytes),
                "string" => new PrimitiveSchema(SchemaType.String),
                _ => tracked.Get(type, null)
            };
        }

        if (reader.TokenType == JsonTokenType.StartArray)
        {
            return reader.ReadTracked<UnionSchema>(tracked, options);
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

            reader.Skip();

            return type.Type switch
            {
                "null" => new PrimitiveSchema(SchemaType.Null),
                "boolean" => new PrimitiveSchema(SchemaType.Boolean),
                "int" => new PrimitiveSchema(SchemaType.Int),
                "long" => new PrimitiveSchema(SchemaType.Long),
                "float" => new PrimitiveSchema(SchemaType.Float),
                "double" => new PrimitiveSchema(SchemaType.Double),
                "bytes" => new PrimitiveSchema(SchemaType.Bytes),
                "string" => new PrimitiveSchema(SchemaType.String),
                "fixed" => reader.ReadTracked<FixedSchema>(tracked, options),
                "enum" => reader.ReadTracked<EnumSchema>(tracked, options),
                "record" => reader.ReadTracked<RecordSchema>(tracked, options),
                "error" => reader.ReadTracked<RecordSchema>(tracked, options),
                _ => tracked.Get(type.Type, null)
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
