namespace AvroSerialize.Metadata.Schemas;

public abstract class UnnamedSchema : Schema
{
    public override string Name => Tag.ToString().ToLowerInvariant();
}
