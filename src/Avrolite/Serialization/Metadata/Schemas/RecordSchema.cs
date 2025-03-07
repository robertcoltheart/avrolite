namespace Avrolite.Serialization.Metadata.Schemas;

internal class RecordSchema : NamedSchema
{
    public RecordSchema(SchemaType tag)
        : base(tag)
    {
    }

    public List<FieldSchema> Fields { get; set; } = new();
}
