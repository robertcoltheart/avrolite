namespace Avrolite;

// Stores the stack trace of the schemas as they are encountered. Needed for AvroReader and for reader state.
// Only needs to store the current index of particular schemas: arrays, maps and fields. Union index needs to be preserved for reader state too.
// Also needs to store how many items there are if we are in an array or map (for the current block)
// Most indices for real-world cases are small, so 256 (1 byte) should be enough to encode.
// We can use 8 ulongs to store a stack depth of 64. Or stack depth of 32 if using ushort (max 65536) values.
// If values go beyond that, we'll need to allocate an array.
internal struct IndexStack
{
    private int[] array;

    private int currentDepth;

    public int CurrentDepth => currentDepth;

    public void Push(int value)
    {
        if (array == null)
        {
            array = new int[2];
        }

        if (currentDepth >= array.Length)
        {
            DoubleArray();
        }

        array[currentDepth] = value;
        currentDepth++;
    }

    public int Peek()
    {
        return array[currentDepth - 1];
    }

    public int Pop()
    {
        currentDepth--;

        return array[currentDepth];
    }

    public void IncrementLast()
    {
        array[currentDepth - 1] += 1;
    }

    private void DoubleArray()
    {
        Array.Resize(ref array, array.Length * 2);
    }
}
