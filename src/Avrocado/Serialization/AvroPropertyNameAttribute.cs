namespace Avrocado.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroPropertyNameAttribute : AvroAttribute
{
    public AvroPropertyNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
