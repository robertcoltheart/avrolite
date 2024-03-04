using AvroSerialize.Serialization.Metadata.Schemas;

namespace AvroSerialize.Serialization.Converters;

internal class TrackedResources
{
    private readonly Dictionary<SchemaName, Schema> schemas = new();

    public string EnclosingNamespace { get; set; }

    public Schema Get(string? name, string? nameSpace)
    {
        var schemaName = new SchemaName(name, nameSpace, EnclosingNamespace);

        return schemas[schemaName];
    }
}
