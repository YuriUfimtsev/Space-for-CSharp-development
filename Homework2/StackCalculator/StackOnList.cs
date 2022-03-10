using System;

namespace StackCalculator;

class StackOnList : IStack
{
    private StackElement head = new();

    public int GetSize
    {
        get { return head.Size; }
    }

    public void Push(float value)
    {
        StackElement newStackElement = new();
        newStackElement.Value = value;
        newStackElement.NextElement = head;
        head = newStackElement;
        ++head.Size;
    }

    public (float returningValue, bool isStackNotEmpty) Pop()
    {
        if (head.NextElement == null)
        {
            return (0, false);
        }
        float value = head.Value;
        head = head.NextElement;
        --head.Size;
        return (value, true);
    }

    public bool IsEmpty()
    {
        return head.NextElement == null;
    }

    public (float returningValue, bool isStackNotEmpty) Top()
    {
        if (head.NextElement == null)
        {
            return (0, false);
        }
        return (head.Value, true);
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