namespace Avrocado;

public abstract class AvroNamingPolicy
{
    public static AvroNamingPolicy CamelCase { get; }

    public static AvroNamingPolicy KebabCaseLower { get; }

    public static AvroNamingPolicy KebabCaseUpper { get; }

    public static AvroNamingPolicy? SnakeCaseLower { get; }

    public static AvroNamingPolicy? SnakeCaseUpper { get; }

    public abstract string ConvertName(string name);
}
