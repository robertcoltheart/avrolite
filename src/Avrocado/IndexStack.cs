namespace Avrocado;

internal struct IndexStack
{
    private int[] array;

    private int depth;

    public void Push(int value)
    {
        if (array == null)
        {
            array = new int[2];
        }

        if (depth >= array.Length)
        {
            DoubleArray();
        }

        array[depth] = value;
        depth++;
    }

    public int Peek()
    {
        return array[depth - 1];
    }

    public int Pop()
    {
        depth--;

        return array[depth];
    }

    public void IncrementLast()
    {
        array[depth - 1] += 1;
    }

    private void DoubleArray()
    {
        Array.Resize(ref array, array.Length * 2);
    }
}
