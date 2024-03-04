namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class EnumSchema : NamedSchema
{
    public EnumSchema()
        : base(SchemaType.Enumeration)
    {
    }

    public List<string> Symbols { get; set; } = new();

    public string Default { get; set; }
}
