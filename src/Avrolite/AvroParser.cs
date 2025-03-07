using System.Buffers;
using System.Buffers.Binary;
using System.Text;

namespace Avrolite;

internal static class AvroParser
{
    private const int StackallocByteThreshold = 256;

    private const int MaxStringLength = 0x7FFFFFC7;

    public static bool TryParseInt16(ReadOnlySpan<byte> source, out short value, out int bytesConsumed)
    {
        if (!TryParseInt64(source, out var longValue, out bytesConsumed))
        {
            value = default;

            return false;
        }

        value = Convert.ToInt16(longValue);

        return true;
    }

    public static bool TryParseInt32(ReadOnlySpan<byte> source, out int value, out int bytesConsumed)
    {
        if (!TryParseInt64(source, out var longValue, out bytesConsumed))
        {
            value = default;

            return false;
        }

        value = Convert.ToInt32(longValue);

        return true;
    }

    public static bool TryParseInt64(ReadOnlySpan<byte> source, out long value, out int bytesConsumed)
    {
        var index = 0;

        var b = source[index];
        var n = b & 0x7FUL;
        var shift = 7;

        while ((b & 0x80) != 0 && index < source.Length)
        {
            b = source[index++];
            n |= (b & 0x7FUL) << shift;
            shift += 7;
        }

        if ((b & 0x80) != 0)
        {
            value = default;
            bytesConsumed = 0;

            return false;
        }

        var longValue = (long)n;

        value = -(longValue & 0x01L) ^ ((longValue >> 1) & 0x7fffffffffffffffL);
        bytesConsumed = index + 1;

        return true;
    }

    public static bool TryParseSingle(ReadOnlySpan<byte> source, out float value, out int bytesConsumed)
    {
        if (source.Length < 4)
        {
            bytesConsumed = 0;
            value = default;

            return false;
        }

        value = BitConverter.Int32BitsToSingle(BinaryPrimitives.ReadInt32LittleEndian(source));

        bytesConsumed = 4;

        return true;
    }

    public static bool TryParseDouble(ReadOnlySpan<byte> source, out double value, out int bytesConsumed)
    {
        if (source.Length < 8)
        {
            bytesConsumed = 0;
            value = default;

            return false;
        }

        value = BitConverter.Int64BitsToDouble(BinaryPrimitives.ReadInt64LittleEndian(source));

        bytesConsumed = 4;

        return true;
    }

    public static bool TryParseString(ReadOnlySpan<byte> source, out string? value, out int bytesConsumed)
    {
        if (!TryParseInt32(source, out var length, out bytesConsumed) || length > MaxStringLength)
        {
            bytesConsumed = 0;
            value = default;

            return false;
        }

        var rented = default(byte[]);

        var array = length <= StackallocByteThreshold
            ? stackalloc byte[length]
            : rented = ArrayPool<byte>.Shared.Rent(length);

        value = Encoding.UTF8.GetString(array);

        if (rented != null)
        {
            ArrayPool<byte>.Shared.Return(rented);
        }

        return true;
    }
}
