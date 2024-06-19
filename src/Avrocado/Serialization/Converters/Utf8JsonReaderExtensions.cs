using System.Text.Json;

namespace Avrocado.Serialization.Converters;

internal static class Utf8JsonReaderExtensions
{
    public static T? ReadTracked<T>(this ref Utf8JsonReader reader, TrackedResources tracked, JsonSerializerOptions options)
    {
        var converter = options.GetTrackedConverter<T>();

        return converter.Read(ref reader, typeof(T), tracked, options);
    }

    public static List<T> ReadTrackedList<T>(this ref Utf8JsonReader reader, TrackedResources tracked, JsonSerializerOptions options)
    {
        var converter = options.GetTrackedConverter<T>();

        var items = new List<T>();

        reader.ReadArray();

        while (reader.IsInArray())
        {
            items.Add(converter.Read(ref reader, typeof(T), tracked, options)!);

            reader.Read();
        }

        return items;
    }

    public static void ReadObject(this ref Utf8JsonReader reader)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new InvalidOperationException();
        }

        reader.Read();
    }

    public static void ReadArray(this ref Utf8JsonReader reader)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new InvalidOperationException();
        }

        reader.Read();
    }

    public static bool IsInObject(this ref Utf8JsonReader reader)
    {
        return reader.TokenType != JsonTokenType.EndObject;
    }

    public static bool IsInArray(this ref Utf8JsonReader reader)
    {
        return reader.TokenType != JsonTokenType.EndArray;
    }

    public static string ReadMember(this ref Utf8JsonReader reader)
    {
        if (reader.TokenType != JsonTokenType.PropertyName)
        {
            throw new InvalidOperationException();
        }

        var name = reader.GetString();
        reader.Read();

        return name!;
    }

    public static SchemaTypeName GetSchemaType(this Utf8JsonReader reader)
    {
        reader.ReadObject();

        var type = new SchemaTypeName();

        while (reader.IsInObject())
        {
            var name = reader.ReadMember();

            if (name == "type")
            {
                type.Type = reader.GetString()!;
            }
            else if (name == "logicalType")
            {
                type.LogicalType = reader.GetString()!;
            }

            if (!string.IsNullOrEmpty(type.Type) && !string.IsNullOrEmpty(type.LogicalType))
            {
                break;
            }

            reader.Skip();
            reader.Read();
        }

        if (string.IsNullOrEmpty(type.Type))
        {
            throw new InvalidOperationException();
        }

        return type;
    }

    public static string GetFullName(this Utf8JsonReader reader)
    {
        var name = default(string);
        var nameSpace = default(string);

        while (reader.IsInObject())
        {
            var property = reader.ReadMember();

            if (property == "name")
            {
                name = reader.GetString();
            }
            else if (property == "namespace")
            {
                nameSpace = reader.GetString();
            }

            reader.Skip();
            reader.Read();
        }

        if (!string.IsNullOrWhiteSpace(nameSpace))
        {
            return $"{nameSpace}.{name}";
        }

        return name!;
    }
}
