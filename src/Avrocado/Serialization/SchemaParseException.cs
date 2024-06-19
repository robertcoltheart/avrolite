namespace Avrocado.Serialization;

internal class SchemaParseException : Exception
{
    public SchemaParseException(string? message)
        : base(message)
    {
    }
}
