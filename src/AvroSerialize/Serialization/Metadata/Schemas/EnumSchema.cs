namespace AvroSerialize.Serialization.Metadata.Schemas;

public class EnumSchema : NamedSchema
{
    public EnumSchema(SchemaType tag)
        : base(tag)
    {
    }

    public List<string> Symbols { get; }
}
