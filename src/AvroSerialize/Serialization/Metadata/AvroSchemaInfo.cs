using System.Text.Json;
using AvroSerialize.Serialization.Metadata.Schemas;

namespace AvroSerialize.Serialization.Metadata;

public sealed class AvroSchemaInfo<T> : AvroSchemaInfo
{
    internal AvroSchemaInfo(Schema? schema)
        : base(schema)
    {
    }
}

public abstract class AvroSchemaInfo
{
    private static readonly JsonSerializerOptions AvroOptions = new JsonSerializerOptions().AddAvroConverter();

    internal AvroSchemaInfo(Schema? schema)
    {
        ParsedSchema = schema;
    }

    public Type Type { get; }

    public string Schema => GenerateSchema(Type);

    internal Schema? ParsedSchema { get; }

    public static AvroSchemaInfo CreateSchemaInfo<T>(AvroSerializerOptions? options = null)
    {
        throw new NotImplementedException();
    }

    public static AvroSchemaInfo CreateSchemaInfo(Type type, AvroSerializerOptions? options = null)
    {
        throw new NotImplementedException();
    }

    public static AvroSchemaInfo Parse(string json, AvroSerializerOptions? options = null)
    {
        var schema = ParsePrimitiveSchema(json) ?? JsonSerializer.Deserialize<Schema>(json, AvroOptions);

        return new AvroSchemaInfo<int>(schema);
    }

    private string GenerateSchema(Type type)
    {
        return string.Empty;
    }

    private static Schema? ParsePrimitiveSchema(string type)
    {
        if (type.StartsWith("\"") && type.EndsWith("\""))
        {
            type = type[1..^1];
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
            _ => null
        };
    }
}
