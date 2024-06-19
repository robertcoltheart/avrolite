namespace Avrocado.Serialization;

public class AvroStringEnumConverter : AvroConverterFactory
{
    public override Type? Type { get; }

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum;
    }

    public override AvroConverter? CreateConverter(Type typeToConvert, AvroSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
