namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class NamedSchema : Schema
{
    public NamedSchema(SchemaType tag)
        : base(tag)
    {
    }

    public SchemaName SchemaName { get; set; } = new();

    public List<string> Aliases { get; set; } = new();

    public string? Documentation { get; set; }

    public override string Name => SchemaName.Name;

    public string Namespace => SchemaName.Namespace;

    public override string FullName => SchemaName.FullName;
}
