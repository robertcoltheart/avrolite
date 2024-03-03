using System.Text.Json;

namespace AvroSerialize.Serialization.Metadata.Schemas;

public abstract class Schema
{
    protected Schema(SchemaType tag)
    {
        Tag = tag;
    }

    public SchemaType Tag { get; }

    public abstract string Name { get; }
}
