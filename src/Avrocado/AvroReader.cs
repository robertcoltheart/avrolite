namespace Avrocado;

public ref struct AvroReader
{
    public AvroReader(ReadOnlySpan<byte> avroData)
    {
    }

    public long BytesConsumed { get; } = 0;

    public int CurrentDepth { get; } = 0;

    public AvroTokenType TokenType { get; } = AvroTokenType.None;

    public bool Read()
    {
        throw new NotImplementedException();
    }

    public void Skip()
    {
        throw new NotImplementedException();
    }

    public int GetInt32()
    {
        throw new NotImplementedException();
    }

    public bool TryGetInt32(out int value)
    {
        throw new NotImplementedException();
    }

    public bool TrySkip()
    {
        throw new NotImplementedException();
    }
}
