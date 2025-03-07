namespace Avrolite.Serialization.Metadata.Types;

internal abstract class LogicalUnixEpochType<T> : LogicalType
    where T : struct
{
    protected static readonly DateTime UnixEpochDateTime = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
}
