namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class RecordSchema : NamedSchema
{
    public RecordSchema(SchemaType tag)
        : base(tag)
    {
    }

    public string Namespace { get; set; }

    public string Documentation { get; set; }

    public List<string> Aliases { get; set; } = new();

    public List<Field> Fields { get; set; } = new();
}
