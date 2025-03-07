using Avrolite.Serialization.Metadata.Schemas;

namespace Avrolite.Serialization.Converters;

internal class TrackedResources
{
    private readonly Dictionary<SchemaName, Schema> schemas = new();

    public Stack<string> EnclosingNamespaces { get; set; }

    public Schema Get(string? name, string? nameSpace)
    {
        EnclosingNamespaces.TryPeek(out var enclosing);

        var schemaName = new SchemaName(name, nameSpace, enclosing);

        return schemas[schemaName];
    }

    public bool Add(SchemaName name, Schema schema)
    {
        return schemas.TryAdd(name, schema);
    }

    public bool Add(NamedSchema schema)
    {
        return Add(schema.SchemaName, schema);
    }
}
