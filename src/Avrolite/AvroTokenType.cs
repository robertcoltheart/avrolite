namespace Avrolite;

public enum AvroTokenType : byte
{
    None,
    StartRecord,
    EndRecord,
    FieldName,
    Number,
    String
}
