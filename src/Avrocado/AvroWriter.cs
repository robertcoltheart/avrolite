using System.Buffers;

namespace Avrocado;

public sealed class AvroWriter : IAsyncDisposable, IDisposable
{
    private IBufferWriter<byte>? output;

    private Stream? stream;

    private ArrayBufferWriter<byte>? arrayBufferWriter;

    private Memory<byte> memory;

    public AvroWriter(IBufferWriter<byte> bufferWriter)
    {
    }

    public AvroWriter(Stream stream)
    {
        arrayBufferWriter = new ArrayBufferWriter<byte>();
    }

    public int BytesPending { get; private set; }

    public long BytesCommitted { get; private set; }

    public void Dispose()
    {
        if (stream == null && arrayBufferWriter == null)
        {
            return;
        }

        Flush();

        stream = null;
        arrayBufferWriter = null;
        output = null;
    }

    public async ValueTask DisposeAsync()
    {
        if (stream == null && output == null)
        {
            return;
        }

        await FlushAsync().ConfigureAwait(false);

        stream = null;
        arrayBufferWriter = null;
        output = null;
    }

    public void Flush()
    {
        if (BytesPending == 0)
        {
            return;
        }

        output!.Advance(BytesPending);

        BytesCommitted += BytesPending;
        BytesPending = 0;
    }

    public Task FlushAsync(CancellationToken cancellationToken = default)
    {
        if (BytesPending == 0)
        {
            return Task.CompletedTask;
        }

        output!.Advance(BytesPending);

        BytesCommitted += BytesPending;
        BytesPending = 0;

        return Task.CompletedTask;
    }

    public void WriteNumber(string propertyName, int value)
    {
        throw new NotImplementedException();
    }

    public void WriteNumberValue(int value)
    {
        throw new NotImplementedException();
    }

    public void WriteByte(byte value)
    {
        Grow(1);
    }

    private void Grow(int length)
    {
        if (memory.Length == 0)
        {
            InitializeMemory(length);

            return;
        }

        var size = Math.Max(4096, length);

        if (stream != null)
        {
            var needed = BytesPending + size;
            memory = arrayBufferWriter!.GetMemory(needed);
        }
        else
        {
            output!.Advance(BytesPending);
            BytesCommitted += BytesPending;
            BytesPending = 0;

            memory = output.GetMemory(size);

            if (memory.Length < size)
            {
                throw new InvalidOperationException("Cannot obtain memory");
            }
        }
    }

    private void InitializeMemory(int length)
    {
        var size = Math.Max(256, length);

        if (stream != null)
        {
            memory = arrayBufferWriter!.GetMemory(size);
        }
        else
        {
            memory = output!.GetMemory(size);

            if (memory.Length < size)
            {
                throw new InvalidOperationException("Cannot obtain memory");
            }
        }
    }
}
