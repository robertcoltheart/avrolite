namespace Avrocado.Serialization;

public abstract class AvroConverterFactory : AvroConverter
{
    public abstract AvroConverter? CreateConverter(Type typeToConvert, AvroSerializerOptions options);
}
