﻿using System.Text.Json;
using Avrolite.Serialization.Metadata.Schemas;

namespace Avrolite.Serialization.Converters;

internal class LogicalSchemaConverter : TrackedConverter<LogicalSchema>
{
    public override LogicalSchema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        reader.ReadObject();

        var schema = new LogicalSchema();

        while (reader.IsInObject())
        {
            var property = reader.ReadMember();

            if (property == "logicalType")
            {
                schema.LogicalTypeName = reader.GetString()!;
            }
            else if (property == "type")
            {
                schema.BaseSchema = reader.ReadTracked<Schema>(tracked, options)!;
            }
            else
            {
                reader.Skip();
            }

            reader.Read();
        }

        return schema;
    }

    public override void Write(Utf8JsonWriter writer, LogicalSchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WritePropertyName("type");
        writer.WriteTracked(value.BaseSchema, tracked, options);
        writer.WriteString("logicalType", value.LogicalTypeName);

        writer.WriteEndObject();
    }
}
