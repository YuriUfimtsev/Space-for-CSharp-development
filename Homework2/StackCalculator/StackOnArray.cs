namespace StackCalculator;

using System;

internal class StackOnArray : IStack
{
    private float[] arrayWithElements;
    private int indexOfArray;

    public StackOnArray()
    {
        this.indexOfArray = 0;
        this.arrayWithElements = new float[10];
    }

    public int GetSize
    {
        get { return this.indexOfArray; }
    }

    internal float[] GetArrayWithElemments
    {
        get { return this.arrayWithElements; }
    }

    public void Push(float value)
    {
        if (this.indexOfArray == this.arrayWithElements.Length)
        {
            this.arrayWithElements = this.Resize(this.arrayWithElements.Length * 2);
        }

        this.arrayWithElements[this.indexOfArray] = value;
        ++this.indexOfArray;
    }

    public (float ReturningValue, bool IsStackNotEmpty) Pop()
    {
        if (this.indexOfArray == 0)
        {
            return (0, false);
        }

        float value = this.arrayWithElements[this.indexOfArray - 1];
        this.arrayWithElements[this.indexOfArray - 1] = 0;
        --this.indexOfArray;
        return (value, true);
    }

    public bool IsEmpty()
    {
        return this.indexOfArray == 0;
    }

    public (float ReturningValue, bool IsStackNotEmpty) Top()
    {
        if (this.indexOfArray == 0)
        {
            return (0, false);
        }

        return (this.arrayWithElements[this.indexOfArray - 1], true);
    }

    internal float[] Resize(int newLength)
    {
        var newArray = new float[newLength];
        for (int i = 0; i < this.arrayWithElements.Length; ++i)
        {
            newArray[i] = this.arrayWithElements[i];
        }

        return newArray;
    }
}
