namespace StackCalculator;

using System;

internal class StackOnList : IStack
{
    private StackElement head = new();

    public int GetSize
    {
        get { return this.head.Size; }
    }

    public void Push(float value)
    {
        StackElement newStackElement = new();
        newStackElement.Value = value;
        newStackElement.NextElement = this.head;
        this.head = newStackElement;
        ++this.head.Size;
    }

    public (float ReturningValue, bool IsStackNotEmpty) Pop()
    {
        if (this.head.NextElement == null)
        {
            return (0, false);
        }

        float value = this.head.Value;
        this.head = this.head.NextElement;
        --this.head.Size;
        return (value, true);
    }

    public bool IsEmpty()
    {
        return this.head.NextElement == null;
    }

    public (float ReturningValue, bool IsStackNotEmpty) Top()
    {
        if (this.head.NextElement == null)
        {
            return (0, false);
        }

        return (this.head.Value, true);
    }

    public class StackElement
    {
        private float value;
        private StackElement? nextElement;
        private int size;

        public StackElement()
        {
            this.value = 0;
            this.nextElement = null;
            this.size = 0;
        }

        internal float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        internal StackElement? NextElement
        {
            get
            {
                return this.nextElement;
            }

            set
            {
                this.nextElement = value;
            }
        }

        internal int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }
    }
}