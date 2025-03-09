using Avrolite.Schemas;

namespace Avrolite.Serialization.Metadata;

internal class SchemaVisitor
{
    private readonly LinkedList<Schema> schemas = new();

    public void Visit(Schema schema)
    {
        if (schema is RecordSchema recordSchema)
        {
            Visit(recordSchema);
        }
        else if (schema is ArraySchema arraySchema)
        {
            Visit(arraySchema);
        }
        else if (schema is UnionSchema unionSchema)
        {
            Visit(unionSchema);
        }
        else if (schema is PrimitiveSchema primitiveSchema)
        {
            Visit(primitiveSchema);
        }
        else
        {
            throw new ArgumentException($"Unexpected schema: {schema.GetType()}");
        }
    }

    private void Visit(RecordSchema schema)
    {
        schemas.AddLast(schema);

        foreach (var field in schema.Fields)
        {
            schemas.AddLast(field);

            Visit(field.Schema);
        }
    }

    private void Visit(ArraySchema schema)
    {
        schemas.AddLast(schema);

        Visit(schema.ItemSchema);
    }

    private void Visit(UnionSchema schema)
    {
        schemas.AddLast(schema);

        foreach (var innerSchema in schema.Schemas)
        {
            Visit(innerSchema);
        }
    }

    private void Visit(PrimitiveSchema schema)
    {
        schemas.AddLast(schema);
    }
}
