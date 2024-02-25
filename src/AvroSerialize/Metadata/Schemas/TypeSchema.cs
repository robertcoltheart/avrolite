namespace AvroSerialize.Metadata.Schemas;

public abstract class TypeSchema : Schema
{
    protected TypeSchema(SchemaType tag)
        : base(tag)
    {
    }

    public override string Name => Tag.ToString().ToLowerInvariant();
}
