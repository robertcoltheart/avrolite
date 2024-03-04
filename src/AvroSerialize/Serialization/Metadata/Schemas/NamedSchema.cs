namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class NamedSchema : Schema
{
    public NamedSchema(SchemaType tag)
        : base(tag)
    {
    }

    public SchemaName SchemaName { get; set; }

    public List<string> Aliases { get; set; } = new();

    public string Documentation { get; set; }

    public override string Name => SchemaName.Name;
}
