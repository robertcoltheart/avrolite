using System.Text.Json.Serialization;
using Avrocado.Serialization.Converters;

namespace Avrocado.Serialization.Metadata.Schemas;

[JsonConverter(typeof(SchemaConverter))]
internal abstract class Schema
{
    protected Schema(SchemaType tag)
    {
        Tag = tag;
    }

    public SchemaType Tag { get; }

    public abstract string Name { get; }

    public virtual string FullName => Name;
}
