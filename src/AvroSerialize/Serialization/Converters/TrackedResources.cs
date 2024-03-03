using AvroSerialize.Serialization.Metadata.Schemas;

namespace AvroSerialize.Serialization.Converters;

public class TrackedResources
{
    public Dictionary<string, Schema> Schemas { get; } = new();

    public Stack<Schema> SchemaTree { get; } = new();
}
