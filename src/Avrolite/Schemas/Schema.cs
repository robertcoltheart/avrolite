using System.Text.Json.Serialization;
using Avrolite.Serialization.Converters;

namespace Avrolite.Schemas;

[JsonConverter(typeof(SchemaConverter))]
public abstract class Schema(SchemaType tag)
{
    public SchemaType Tag { get; } = tag;

    public abstract string Name { get; }

    public virtual string FullName => Name;

    public Schema? Next { get; set; }
}
