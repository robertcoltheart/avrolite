namespace Avrolite.Serialization.Metadata;

public interface IAvroSchemaInfoResolver
{
    AvroSchemaInfo? GetSchemaInfo(Type type, AvroSerializerOptions options);
}
