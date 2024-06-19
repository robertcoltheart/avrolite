namespace Avrocado.Serialization;

public abstract class AvroConverter<T> : AvroConverter
{
    public abstract T? Read(ref AvroReader reader, Type typeToConvert, AvroSerializerOptions options);

    public abstract void Write(AvroWriter writer, T value, AvroSerializerOptions options);
}

public abstract class AvroConverter
{
    public abstract Type? Type { get; }

    public abstract bool CanConvert(Type typeToConvert);
}
