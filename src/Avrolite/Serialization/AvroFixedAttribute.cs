﻿namespace Avrolite.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroFixedAttribute : AvroAttribute
{
    public AvroFixedAttribute(int size)
    {
        Size = size;
    }

    public int Size { get; }
}
