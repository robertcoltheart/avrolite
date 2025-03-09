namespace Avrolite.Schemas;

internal abstract class UnnamedSchema : Schema
{
    protected UnnamedSchema(SchemaType tag)
        : base(tag)
    {
    }

    public override string Name => Tag.ToString().ToLowerInvariant();
}
