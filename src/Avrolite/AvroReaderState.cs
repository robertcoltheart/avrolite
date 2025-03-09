using Avrolite.Schemas;

namespace Avrolite;

public readonly struct AvroReaderState
{
    internal readonly AvroTokenType TokenType;

    internal readonly int CurrentDepth;

    internal readonly IndexStack ElementIndices;

    internal readonly Schema? CurrentSchema;

    public AvroReaderState(AvroReaderOptions options = default)
    {
        Options = options;

        TokenType = default;
        CurrentDepth = 0;
        ElementIndices = new IndexStack();
        CurrentSchema = null;
    }

    internal AvroReaderState(
        AvroTokenType tokenType,
        int currentDepth,
        IndexStack elementIndices,
        Schema? currentSchema,
        AvroReaderOptions options)
    {
        TokenType = tokenType;
        CurrentDepth = currentDepth;
        ElementIndices = elementIndices;
        CurrentSchema = currentSchema;
        Options = options;
    }

    public AvroReaderOptions Options { get; }
}
