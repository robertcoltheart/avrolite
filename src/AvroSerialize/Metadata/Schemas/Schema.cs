namespace AvroSerialize.Metadata.Schemas;

public abstract class Schema
{
    public SchemaType Tag { get; }

    public abstract string Name { get; }

    public static Schema Parse(string json)
    {
        throw new NotImplementedException();
    }
}
