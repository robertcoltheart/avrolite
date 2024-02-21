namespace AvroSerialize.Metadata.Schemas;

public class NamedSchema : Schema
{
    public SchemaName SchemaName { get; }

    public override string Name => SchemaName.Name;
}
