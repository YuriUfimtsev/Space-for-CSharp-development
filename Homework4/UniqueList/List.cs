namespace UniqueList;

public class List<T>
{
    private ListElement<T>? head;
    private ListElement<T>? tail;
    private int sizeOfList;

    public List()
    {
        this.head = null;
        this.tail = null;
        this.sizeOfList = 0;
    }

    public int Size
    {
        get { return this.sizeOfList; }
    }

    public virtual bool AddByPosition(T value, int position)
    {
        ListElement<T> newElement = new(value);
        ++this.sizeOfList;
        if (this.head == null)
        {
            this.head = newElement;
            this.tail = newElement;
            return position == 0;
        }

        if (position >= this.sizeOfList)
        {
            this.tail!.Next = newElement;
            this.tail = this.tail!.Next;
            return false;
        }

        if (position <= 0)
        {
            ListElement<T> headElement = this.head;
            newElement.Next = headElement;
            this.head = newElement;
            return true;
        }

        ListElement<T> currentElement = this.head;
        for (int i = 0; i < position - 1; ++i)
        {
            currentElement = currentElement.Next!;
        }

        newElement.Next = currentElement.Next;
        currentElement.Next = newElement;
        currentElement.Next = newElement;
        if (newElement.Next == null)
        {
            this.tail = newElement;
        }

        return true;
    }

    public bool RemoveByPosition(int position)
    {
        if (this.head == null)
        {
            throw new IncorrectOperationException("The list hasn't contained elements");
        }

        --this.sizeOfList;
        if (this.sizeOfList == 0)
        {
            this.head = null;
            this.tail = null;
            return position == 0;
        }

        if (position <= 0)
        {
            this.head = this.head.Next;
            return false;
        }

        ListElement<T> currentElement = this.head;
        if (position > this.sizeOfList)
        {
            while (currentElement.Next!.Next != null)
            {
                currentElement = currentElement.Next;
            }

            currentElement.Next = null;
            this.tail = currentElement;
            return false;
        }

        for (int i = 0; i < position - 1; ++i)
        {
            currentElement = currentElement.Next!;
        }

        currentElement.Next = currentElement.Next!.Next;
        if (currentElement.Next == null)
        {
            this.tail = currentElement;
        }

        return true;
    }

    public virtual void ChangeByPosition(int position, T newValue)
    {
        if (this.head == null)
        {
            throw new InvalidOperationException();
        }

        if (position <= 0)
        {
            this.head.Value = newValue;
        }

        if (position >= this.sizeOfList - 1)
        {
            this.tail!.Value = newValue;
        }

        ListElement<T> currentElement = this.head;
        for (int i = 0; i < position; ++i)
        {
            currentElement = currentElement.Next!;
        }

        currentElement.Value = newValue;
    }

    public T GetElementFromHead()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException();
        }

        return this.head.Value;
    }

    public T GetElementFromTail()
    {
        if (this.tail == null)
        {
            throw new InvalidOperationException();
        }

        return this.tail.Value;
    }

    internal (int CountOfValues, int ValuePositionInList) HowManyValuesInList(T value)
    {
        if (this.head == null)
        {
            return (0, -1);
        }

        ListElement<T> currentElement = this.head;
        int valuePositionInList = -1;
        int listElementsIndex = 0;

        int frequencyOfOccurrence = 0;
        while (currentElement.Next != null)
        {
            if (Equals(currentElement.Value, value))
            {
                ++frequencyOfOccurrence;
                valuePositionInList = listElementsIndex;
            }

            currentElement = currentElement.Next;
            ++listElementsIndex;
        }

        if (Equals(currentElement.Value, value))
        {
            ++frequencyOfOccurrence;
            valuePositionInList = listElementsIndex;
        }

        return (frequencyOfOccurrence, valuePositionInList);
    }
}
