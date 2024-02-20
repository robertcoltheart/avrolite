using System.Buffers;

namespace AvroSerialize;

public sealed class AvroWriter : IAsyncDisposable, IDisposable
{
    public AvroWriter(IBufferWriter<byte> bufferWriter)
    {
    }

    public AvroWriter(Stream stream)
    {
    }

    public void Dispose()
    {
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public void Flush()
    {
        throw new NotImplementedException();
    }

    public Task FlushAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void WriteNumber(string propertyName, int value)
    {
        throw new NotImplementedException();
    }

    public void WriteNumberValue(int value)
    {
        throw new NotImplementedException();
    }
}
