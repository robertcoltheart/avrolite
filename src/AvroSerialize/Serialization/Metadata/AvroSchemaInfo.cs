using System.Text.Json;
using AvroSerialize.Serialization.Metadata.Schemas;

namespace AvroSerialize.Serialization.Metadata;

public sealed class AvroSchemaInfo<T> : AvroSchemaInfo
{
    internal AvroSchemaInfo()
    {
    }
}

public abstract class AvroSchemaInfo
{
    private static readonly JsonSerializerOptions AvroOptions = new JsonSerializerOptions().AddAvroConverter();

    private string? schema;

    internal AvroSchemaInfo()
    {
    }

    public Type Type { get; }

    public string Schema => GenerateSchema(Type);

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
        var schema = JsonSerializer.Deserialize<Schema>(json, AvroOptions);

        var result = JsonSerializer.Serialize(schema, AvroOptions);

        return new AvroSchemaInfo<int>();
    }

    private string GenerateSchema(Type type)
    {
        return string.Empty;
    }
}
