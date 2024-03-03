using AvroSerialize.Serialization.Metadata;

namespace AvroSerialize;

public static class AvroSerializer
{
    public static object? Deserialize(Stream stream, AvroSchemaInfo schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static object? Deserialize(ref AvroReader reader, Type returnType, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static object? Deserialize(byte[] data, Type returnType, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static object? Deserialize(ReadOnlySpan<byte> data, AvroSchemaInfo schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static object? Deserialize(byte[] data, AvroSchemaInfo schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static object? Deserialize(ref AvroReader reader, AvroSchemaInfo schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static object? Deserialize(Stream stream, Type returnType, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static TValue? Deserialize<TValue>(ref AvroReader reader, AvroSchemaInfo<TValue> schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static TValue? Deserialize<TValue>(ref AvroReader reader, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static TValue? Deserialize<TValue>(byte[] data, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static TValue? Deserialize<TValue>(ReadOnlySpan<byte> data, AvroSchemaInfo<TValue> schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static TValue? Deserialize<TValue>(ReadOnlySpan<byte> data, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static TValue? Deserialize<TValue>(Stream stream, AvroSchemaInfo<TValue> schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static TValue? Deserialize<TValue>(Stream stream, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static TValue? Deserialize<TValue>(byte[] data, AvroSchemaInfo<TValue> schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static ValueTask<object?> DeserializeAsync(byte[] data, AvroSchemaInfo schemaInfo, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public static ValueTask<object?> DeserializeAsync(Stream stream, Type returnType, AvroSerializerOptions? options = default, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public static ValueTask<TValue?> DeserializeAsync<TValue>(Stream stream,AvroSchemaInfo<TValue> schemaInfo, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public static ValueTask<TValue?> DeserializeAsync<TValue>(Stream stream, AvroSerializerOptions? options = default, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public static void Serialize(Stream stream, object? value, Type inputType, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static void Serialize(AvroWriter writer, object? value, AvroSchemaInfo schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static void Serialize(AvroWriter writer, object? value, Type inputType, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static byte[] Serialize(object? value, Type inputType, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static void Serialize(Stream stream, object? value, AvroSchemaInfo schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static byte[] Serialize(object? value, AvroSchemaInfo schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static byte[] Serialize<TValue>(TValue value, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static byte[] Serialize<TValue>(TValue value, AvroSchemaInfo<TValue> schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static void Serialize<TValue>(Stream stream, TValue value, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static void Serialize<TValue>(Stream stream, TValue value, AvroSchemaInfo<TValue> schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static void Serialize<TValue>(AvroWriter writer, TValue value, AvroSerializerOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public static void Serialize<TValue>(AvroWriter writer, TValue value, AvroSchemaInfo<TValue> schemaInfo)
    {
        throw new NotImplementedException();
    }

    public static Task SerializeAsync(Stream stream, object? value, AvroSchemaInfo schemaInfo, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public static Task SerializeAsync(Stream stream, object? value, Type inputType, AvroSerializerOptions? options = default, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public static Task SerializeAsync<TValue>(Stream stream, TValue value, AvroSchemaInfo<TValue> schemaInfo, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public static Task SerializeAsync<TValue>(Stream stream, TValue value, AvroSerializerOptions? options = default, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
