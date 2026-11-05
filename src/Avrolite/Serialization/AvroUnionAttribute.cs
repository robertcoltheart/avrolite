namespace Avrolite.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroUnionAttribute(params Type[] types) : AvroAttribute
{
    public IReadOnlyCollection<Type> Types { get; } = types;
}
