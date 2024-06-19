using System.Text.Json;
using Avrocado.Serialization.Metadata.Schemas;

namespace Avrocado.Serialization.Converters;

internal class UnionSchemaConverter : TrackedConverter<UnionSchema>
{
    public override UnionSchema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        reader.ReadArray();

        var schema = new UnionSchema();
        var unique = new HashSet<string>();

        while (reader.IsInArray())
        {
            var unionSchema = reader.ReadTracked<Schema>(tracked, options);

            if (!unique.Add(unionSchema!.Name))
            {
                throw new InvalidOperationException("Duplicate");
            }

            schema.Schemas.Add(unionSchema);
        }

        return schema;
    }

    public override void Write(Utf8JsonWriter writer, UnionSchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
