namespace StackCalculator;

class StackOnList : IStack
{
    private StackElement head = new();

    public int GetSize
    {
        get { return head.Size; }
    }

    public void Push(int value)
    {
        StackElement newStackElement = new();
        newStackElement.Value = value;
        newStackElement.NextElement = head;
        head = newStackElement;
        ++head.Size;
    }

    public (int returningValue, bool isStackEmpty) Pop()
    {
        if (head.NextElement == null)
        {
            return (0, true);
        }
        int value = head.Value;
        head = head.NextElement;
        --head.Size;
        return (value, false);
    }

    public bool IsEmpty()
    {
        return head.NextElement == null;
    }

    public (int returningValue, bool isStackEmpty) Top()
    {
        if (head.NextElement == null)
        {
            return (0, true);
        }
        return (head.Value, false);
    }

    internal class StackElement
    {
        private int value;
        private StackElement? nextElement;
        private int size;

        public StackElement()
        {
            this.value = 0;
            this.nextElement = null;
            this.size = 0;
        }

        internal int Value
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