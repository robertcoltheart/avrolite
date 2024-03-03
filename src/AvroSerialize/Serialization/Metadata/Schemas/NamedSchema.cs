namespace AvroSerialize.Serialization.Metadata.Schemas;

public class NamedSchema : Schema
{
    public NamedSchema(SchemaType tag)
        : base(tag)
    {
    }

    public SchemaName SchemaName { get; set; }

    public override string Name => SchemaName.Name;
}
