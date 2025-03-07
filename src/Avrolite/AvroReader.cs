using Avrolite.Serialization.Metadata.Schemas;

namespace Avrolite;

public ref struct AvroReader
{
    private readonly ReadOnlySpan<byte> buffer;

    private readonly AvroReaderOptions readerOptions;

    private AvroTokenType tokenType;

    private Schema currentSchema;

    private int consumed;

    private int currentDepth;

    private IndexStack elementIndices;

    public AvroReader(ReadOnlySpan<byte> avroData, AvroReaderOptions options = default)
        : this(avroData, new AvroReaderState(options))
    {
    }

    public AvroReader(ReadOnlySpan<byte> avroData, AvroReaderState state)
    {
        buffer = avroData;
        readerOptions = state.Options;
        tokenType = state.TokenType;
        currentSchema = state.Options.Schema;
        elementIndices = state.ElementIndices;

        consumed = 0;
        currentDepth = 0;
        ValueSpan = ReadOnlySpan<byte>.Empty;
    }

    public long BytesConsumed => consumed;

    public int CurrentDepth => currentDepth;

    public AvroTokenType TokenType => tokenType;

    public AvroReaderState CurrentState => new(tokenType, currentDepth, elementIndices, currentSchema, readerOptions);

    public ReadOnlySpan<byte> ValueSpan { get; private set; }

    public bool Read()
    {
        if (!HasMoreData())
        {
            return false;
        }

        if (tokenType == AvroTokenType.None)
        {
            return Read(readerOptions.Schema);
        }

        if (tokenType == AvroTokenType.StartRecord)
        {
            elementIndices.Push(0);

            return ConsumeRecordField();
        }

        return ConsumeNextToken();
    }

    public void Skip()
    {
        throw new NotImplementedException();
    }

    public int GetInt16()
    {
        if (!TryGetInt16(out var value))
        {
            throw new FormatException();
        }

        return value;
    }

    public int GetInt32()
    {
        if (!TryGetInt32(out var value))
        {
            throw new FormatException();
        }

        return value;
    }

    public long GetInt64()
    {
        if (!TryGetInt64(out var value))
        {
            throw new FormatException();
        }

        return value;
    }

    public string? GetString()
    {
        if (!AvroParser.TryParseString(ValueSpan, out var value, out var bytesConsumed) || ValueSpan.Length != bytesConsumed)
        {
            throw new FormatException();
        }

        return value;
    }

    public bool TryGetInt16(out short value)
    {
        if (TokenType != AvroTokenType.Number)
        {
            throw new InvalidOperationException();
        }

        return AvroParser.TryParseInt16(ValueSpan, out value, out var bytesConsumed) && ValueSpan.Length == bytesConsumed;
    }

    public bool TryGetInt32(out int value)
    {
        if (TokenType != AvroTokenType.Number)
        {
            throw new InvalidOperationException();
        }

        return AvroParser.TryParseInt32(ValueSpan, out value, out var bytesConsumed) && ValueSpan.Length == bytesConsumed;
    }

    public bool TryGetInt64(out long value)
    {
        if (TokenType != AvroTokenType.Number)
        {
            throw new InvalidOperationException();
        }

        return AvroParser.TryParseInt64(ValueSpan, out value, out var bytesConsumed) && ValueSpan.Length == bytesConsumed;
    }

    public bool TryGetSingle(out float value)
    {
        if (TokenType != AvroTokenType.Number)
        {
            throw new InvalidOperationException();
        }

        return AvroParser.TryParseSingle(ValueSpan, out value, out var bytesConsumed) && ValueSpan.Length == bytesConsumed;
    }

    public bool TryGetDouble(out double value)
    {
        if (TokenType != AvroTokenType.Number)
        {
            throw new InvalidOperationException();
        }

        return AvroParser.TryParseDouble(ValueSpan, out value, out var bytesConsumed) && ValueSpan.Length == bytesConsumed;
    }

    public bool TrySkip()
    {
        throw new NotImplementedException();
    }

    private bool Read(Schema schema)
    {
        if (schema.Tag == SchemaType.Record)
        {
            StartRecord((RecordSchema) schema);

            return true;
        }

        return false;
    }

    private void StartRecord()
    {
        if (currentDepth >= readerOptions.MaxDepth)
        {
            throw new AvroReaderException("The maximum configured depth has been exceeded. Cannot read next object.");
        }

        currentDepth++;

        tokenType = AvroTokenType.StartRecord;
        ValueSpan = ReadOnlySpan<byte>.Empty;
    }

    private void EndRecord()
    {
        if (currentDepth <= 0)
        {
            throw new AvroReaderException("Invalid without a matching start record");
        }

        currentDepth--;

        tokenType = AvroTokenType.EndRecord;
    }

    private void StartRecord(RecordSchema schema)
    {
        currentSchema = schema;
        tokenType = AvroTokenType.StartRecord;
    }

    private bool ConsumeNextToken()
    {
        //var schema = GetParentSchema();

        //if (schema is RecordSchema recordSchema)
        //{
        //    if (elementIndices.Peek() < recordSchema.Fields.Count - 1)
        //    {
        //        currentSchema = recordSchema;

        //        return ConsumeRecordField();
        //    }
        //}

        return false;
    }

    private bool ConsumeRecordField()
    {
        var record = (RecordSchema) currentSchema;
        var field = record.Fields[elementIndices.Peek()];

        currentSchema = field.Schema;

        if (currentSchema.Tag == SchemaType.Int)
        {
            if (ConsumeNumber())
            {
                elementIndices.IncrementLast();

                return true;
            }

            return false;
        }

        if (currentSchema.Tag == SchemaType.Union)
        {
            return ConsumeUnion();
        }

        return false;
    }

    private bool ConsumeUnion()
    {
        var schema = (UnionSchema) currentSchema;

        if (!AvroParser.TryParseInt32(buffer.Slice(consumed), out var index, out var bytesConsumed))
        {
            return false;
        }

        elementIndices.Push(index);

        currentSchema = schema.Schemas[index];

        consumed += bytesConsumed;

        return true;
    }

    private bool ConsumeNumber()
    {
        if (!TryConsumeNumber(buffer.Slice(consumed), out var bytesConsumed))
        {
            return false;
        }

        tokenType = AvroTokenType.Number;
        consumed += bytesConsumed;

        return true;
    }

    private bool ConsumeString()
    {
        if (!TryConsumeString(buffer.Slice(consumed), out var bytesConsumed))
        {
            return false;
        }

        tokenType = AvroTokenType.String;
        consumed += bytesConsumed;

        return true;
    }

    private bool TryConsumeNumber(ReadOnlySpan<byte> data, out int bytesConsumed)
    {
        if (!AvroParser.TryParseInt64(data, out _, out bytesConsumed))
        {
            return false;
        }

        ValueSpan = data.Slice(0, bytesConsumed);

        return true;
    }

    private bool TryConsumeString(ReadOnlySpan<byte> data, out int bytesConsumed)
    {
        bytesConsumed = 0;

        if (!AvroParser.TryParseInt32(data, out var length, out var lengthBytes))
        {
            return false;
        }

        if (data.Length < length + lengthBytes)
        {
            return false;
        }

        bytesConsumed += length + lengthBytes;

        ValueSpan = data.Slice(0, bytesConsumed);

        return true;
    }

    private bool HasMoreData()
    {
        return consumed < buffer.Length;
    }
}
