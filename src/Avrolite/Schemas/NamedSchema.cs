namespace Avrolite.Schemas;

internal class NamedSchema(SchemaType tag) : Schema(tag)
{
    public SchemaName SchemaName { get; set; } = new();

    public List<string>? Aliases { get; set; } = new();

    public string? Documentation { get; set; }

    public override string Name => SchemaName.Name;

    public string Namespace => SchemaName.Namespace;

    public override string FullName => SchemaName.FullName;
}
