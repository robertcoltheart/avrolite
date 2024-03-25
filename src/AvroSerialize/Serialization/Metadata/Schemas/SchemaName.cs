namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class SchemaName
{
    public SchemaName()
    {
    }

    public SchemaName(string? name, string? nameSpace, string enclosingNamespace)
    {
        Name = name!;
        Namespace = nameSpace!;
        EnclosingNamespace = enclosingNamespace;

        if (!string.IsNullOrEmpty(name) && name.Contains('.'))
        {
            var parts = name.Split('.');

            Namespace = string.Join(".", parts, 0, parts.Length - 1);
            Name = parts[^1];
        }

        FullName = string.IsNullOrEmpty(Namespace)
            ? FullName = Name!
            : FullName = $"{Namespace}.{Name}";
    }

    public string Name { get; set; }

    public string Namespace { get; set; }

    public string EnclosingNamespace { get; set; }

    public string FullName { get; }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Namespace);
    }

    public override bool Equals(object? obj)
    {
        return obj is SchemaName other && other.Namespace == Namespace && other.Name == Name;
    }
}
