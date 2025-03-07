namespace Avrolite.Serialization.Metadata.Schemas;

internal class SchemaNames
{
    public Dictionary<string, NamedSchema> Names { get; } = new();

    public bool Contains(string name)
    {
        return Names.ContainsKey(name);
    }

    public bool Add(string name, NamedSchema schema)
    {
        if (Names.ContainsKey(name))
        {
            return false;
        }

        Names.Add(name, schema);

        return true;
    }
}
