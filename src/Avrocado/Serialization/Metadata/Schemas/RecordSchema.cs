namespace Avrocado.Serialization.Metadata.Schemas;

internal class RecordSchema : NamedSchema
{
    public RecordSchema(SchemaType tag)
        : base(tag)
    {
    }

    public List<Field> Fields { get; set; } = new();
}
