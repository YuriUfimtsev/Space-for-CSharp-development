using System;

namespace StackCalculator;

internal class StackOnArray : IStack
{
    private int[] arrayWithElements;
    private int indexOfArray;

    public int GetSize
    {
        get { return indexOfArray; }
    }

    public StackOnArray()
    {
        this.indexOfArray = 0;
        this.arrayWithElements = new int[10];
    }

    public void Push(int value)
    {
        if (indexOfArray == arrayWithElements.Length)
        {
            arrayWithElements = Resize(arrayWithElements.Length * 2);
        }

        arrayWithElements[indexOfArray] = value;
        ++indexOfArray;
    }

    public (int returningValue, bool isStackEmpty) Pop()
    {
        if (indexOfArray == 0)
        {
            return (0, true);
        }

        int value = arrayWithElements[indexOfArray];
        arrayWithElements[indexOfArray - 1] = 0;
        --indexOfArray;
        return (value, false);
    }

    public bool IsEmpty()
    {
        return indexOfArray == 0;
    }
    public (int returningValue, bool isStackEmpty) Top()
    {
        if (indexOfArray == 0)
        {
            return (0, true);
        }

        return (arrayWithElements[indexOfArray - 1], false);
    }


    internal int[] Resize(int newLength)
    {
        var newArray = new int[newLength];
        for (int i = 0; i < arrayWithElements.Length; ++i)
        {
            newArray[i] = arrayWithElements[i];
        }

        return newArray;
    }

}
