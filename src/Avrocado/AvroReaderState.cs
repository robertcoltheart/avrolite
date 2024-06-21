namespace Avrocado;

public readonly struct AvroReaderState
{
    internal readonly AvroTokenType TokenType;

    internal readonly IndexStack ElementIndices;

    public AvroReaderState(AvroReaderOptions options = default)
    {
        Options = options;

        TokenType = default;
        ElementIndices = new IndexStack();
    }

    internal AvroReaderState(
        AvroTokenType tokenType,
        IndexStack elementIndices,
        AvroReaderOptions options)
    {
        TokenType = tokenType;
        ElementIndices = elementIndices;
        Options = options;
    }

    public AvroReaderOptions Options { get; }
}
