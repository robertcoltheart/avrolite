namespace Avrolite.Schemas;

internal class RecordSchema(SchemaType tag) : NamedSchema(tag)
{
    public List<FieldSchema> Fields { get; set; } = new();
}
