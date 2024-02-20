namespace AvroSerialize;

public abstract class AvroNamingPolicy
{
    public static AvroNamingPolicy CamelCase { get; }

    public abstract string ConvertName(string name);
}
