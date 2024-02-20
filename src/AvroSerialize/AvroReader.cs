using System.Buffers;

namespace AvroSerialize;

public ref struct AvroReader
{
    public AvroReader(ReadOnlySequence<byte> avroData)
    {
    }

    public AvroReader(ReadOnlySpan<byte> avroData)
    {
    }

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
}
