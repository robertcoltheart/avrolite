using Avrocado.Serialization.Metadata.Schemas;

namespace Avrocado.Serialization.Metadata;

internal static class SchemaTree
{
    public static void SetSchemaHierarchy(Schema schema)
    {
        if (schema is RecordSchema recordSchema)
        {
            SetSchemaHierarchy(recordSchema);
        }
        else if (schema is UnionSchema unionSchema)
        {
            SetSchemaHierarchy(unionSchema);
        }
        else if (schema is ArraySchema arraySchema)
        {
            SetSchemaHierarchy(arraySchema);
        }
    }

    private static void SetSchemaHierarchy(RecordSchema schema)
    {
        foreach (var field in schema.Fields)
        {
            field.Schema.Parent = schema;

            SetSchemaHierarchy(field.Schema);
        }
    }

    private static void SetSchemaHierarchy(UnionSchema schema)
    {
        foreach (var unionSchema in schema.Schemas)
        {
            unionSchema.Parent = schema;

            SetSchemaHierarchy(unionSchema);
        }
    }

    private static void SetSchemaHierarchy(ArraySchema schema)
    {
        if (schema.ItemSchema != null)
        {
            schema.ItemSchema.Parent = schema;

            SetSchemaHierarchy(schema.ItemSchema);
        }
    }
}
