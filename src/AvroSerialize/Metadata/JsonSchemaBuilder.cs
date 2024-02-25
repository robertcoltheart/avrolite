using System.Text.Json;
using System.Text.Json.Nodes;
using AvroSerialize.Metadata.Schemas;

namespace AvroSerialize.Metadata;

public class JsonSchemaBuilder
{
    public TypeSchema Build(string json)
    {
        using var document = JsonDocument.Parse(json);

        return Parse(document.RootElement, null, new Dictionary<string, NamedSchema>());
    }

    private TypeSchema Parse(JsonElement element, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {

        }

        return null;
    }

    private TypeSchema ParseObject(JsonElement element, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
    {
    }

    private string? GetNamespace(JsonElement element, NamedSchema parent, string name)
    {
        if (element.TryGetProperty("namespace", out var value))
        {
            return value.GetString();
        }

        return null;
    }

    private IEnumerable<string> GetAliases(JsonElement element)
    {
        if (element.TryGetProperty("aliases", out var value))
        {
            if (value.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException();
            }

            foreach (var item in value.EnumerateArray())
            {
                if (item.ValueKind != JsonValueKind.String)
                {
                    throw new ArgumentException();
                }

                var itemValue = item.GetString();

                if (string.IsNullOrEmpty(itemValue))
                {
                    throw new InvalidOperationException();
                }

                yield return itemValue;
            }
        }
    }
}
