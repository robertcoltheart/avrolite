namespace AvroSerialize.Metadata.Schemas;

public class NamedSchema : Schema
{
    public NamedSchema(SchemaType tag)
        : base(tag)
    {
    }

    public SchemaName SchemaName { get; }

    public override string Name => SchemaName.Name;
}
