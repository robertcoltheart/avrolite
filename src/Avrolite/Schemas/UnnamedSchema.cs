namespace Avrolite.Schemas;

internal abstract class UnnamedSchema(SchemaType tag) : Schema(tag)
{
    public override string Name => Tag.ToString().ToLowerInvariant();
}
