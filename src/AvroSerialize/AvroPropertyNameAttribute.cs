namespace AvroSerialize;

[AttributeUsage(AttributeTargets.Property)]
public class AvroPropertyNameAttribute : Attribute
{
    public AvroPropertyNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
