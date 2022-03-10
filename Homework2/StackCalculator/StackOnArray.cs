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

    public (float returningValue, bool isStackNotEmpty) Pop()
    {
        if (indexOfArray == 0)
        {
            return (0, false);
        }

        float value = arrayWithElements[indexOfArray - 1];
        arrayWithElements[indexOfArray - 1] = 0;
        --indexOfArray;
        return (value, true);
    }

    public bool IsEmpty()
    {
        return indexOfArray == 0;
    }
    public (float returningValue, bool isStackNotEmpty) Top()
    {
        if (indexOfArray == 0)
        {
            return (0, false);
        }

        return (arrayWithElements[indexOfArray - 1], true);
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
