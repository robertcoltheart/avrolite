namespace Avrolite.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroPropertyNameAttribute(string name) : AvroAttribute
{
    public string Name { get; } = name;
}
