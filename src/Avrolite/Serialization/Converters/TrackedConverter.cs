using System.Text.Json;
using System.Text.Json.Serialization;

namespace Avrolite.Serialization.Converters;

internal abstract class TrackedConverter<T> : JsonConverter<T>
{
    public abstract T? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options);

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }

    public abstract void Write(Utf8JsonWriter writer, T value, TrackedResources tracked, JsonSerializerOptions options);

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }
}
