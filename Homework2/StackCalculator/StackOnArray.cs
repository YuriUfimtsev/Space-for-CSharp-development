using System;

namespace StackCalculator;

internal class StackOnArray : IStack
{
    private float[] arrayWithElements;
    private int indexOfArray;

    public int GetSize
    {
        get { return indexOfArray; }
    }
    internal float[] GetArrayWithElemments
    {
        get { return arrayWithElements; }
    }

    public StackOnArray()
    {
        this.indexOfArray = 0;
        this.arrayWithElements = new float[10];
    }

    public void Push(float value)
    {
        if (indexOfArray == arrayWithElements.Length)
        {
            arrayWithElements = Resize(arrayWithElements.Length * 2);
        }

        arrayWithElements[indexOfArray] = value;
        ++indexOfArray;
    }

    public (float returningValue, bool isStackEmpty) Pop()
    {
        if (indexOfArray == 0)
        {
            return (0, true);
        }

        float value = arrayWithElements[indexOfArray];
        arrayWithElements[indexOfArray - 1] = 0;
        --indexOfArray;
        return (value, false);
    }

    public bool IsEmpty()
    {
        return indexOfArray == 0;
    }
    public (float returningValue, bool isStackEmpty) Top()
    {
        if (indexOfArray == 0)
        {
            return (0, true);
        }

        return (arrayWithElements[indexOfArray - 1], false);
    }


    internal float[] Resize(int newLength)
    {
        var newArray = new float[newLength];
        for (int i = 0; i < arrayWithElements.Length; ++i)
        {
            newArray[i] = arrayWithElements[i];
        }

        return newArray;
    }
}
