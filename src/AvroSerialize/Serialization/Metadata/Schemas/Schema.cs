using System.Text.Json.Serialization;
using AvroSerialize.Serialization.Converters;

namespace AvroSerialize.Serialization.Metadata.Schemas;

[JsonConverter(typeof(SchemaConverter))]
internal abstract class Schema
{
    protected Schema(SchemaType tag)
    {
        Tag = tag;
    }

    public SchemaType Tag { get; }

    public abstract string Name { get; }
}
