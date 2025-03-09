using System.Text.Json.Serialization;
using Avrolite.Serialization.Converters;

namespace Avrolite.Schemas;

[JsonConverter(typeof(SchemaConverter))]
public abstract class Schema
{
    protected Schema(SchemaType tag)
    {
        Tag = tag;
    }

    public SchemaType Tag { get; }

    public abstract string Name { get; }

    public virtual string FullName => Name;

    public Schema? Next { get; set; }
}
