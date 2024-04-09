namespace AvroSerialize.Serialization.Metadata.Schemas;

internal static class SchemaTypeExtensions
{
    public static string ToStringType(this SchemaType type)
    {
        return type switch
        {
            SchemaType.Enumeration => "enum",
            SchemaType.Array => "array",
            SchemaType.Boolean => "boolean",
            SchemaType.Bytes => "bytes",
            SchemaType.Double => "double",
            SchemaType.Float => "float",
            SchemaType.Int => "int",
            SchemaType.Long => "long",
            SchemaType.Error => "error",
            SchemaType.Null => "null",
            SchemaType.Record => "record",
            SchemaType.String => "string",
            SchemaType.Logical => "logical",
            SchemaType.Fixed => "fixed",
            SchemaType.Map => "map",
            SchemaType.Union => "union",
            _ => throw new ArgumentException()
        };
    }
}
