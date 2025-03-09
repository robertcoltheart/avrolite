namespace Avrolite.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroDecimalAttribute(int precision, int scale) : AvroAttribute
{
    public int Precision { get; } = precision;

    public int Scale { get; } = scale;
}
