namespace Avrolite.Schemas;

internal class EnumSchema() : NamedSchema(SchemaType.Enumeration)
{
    public List<string> Symbols { get; set; } = new();

    public string? Default { get; set; }
}
