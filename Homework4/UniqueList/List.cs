namespace UniqueList;

/// <summary>
/// Class realizes the structure List.
/// </summary>
/// <typeparam name="T">Type for list values.</typeparam>
public class List<T>
{
    private ListElement<T>? head;
    private ListElement<T>? tail;
    private int sizeOfList;

    /// <summary>
    /// Initializes a new instance of the <see cref="List{T}"/> class.
    /// </summary>
    public List()
    {
        this.head = null;
        this.tail = null;
        this.sizeOfList = 0;
    }

    /// <summary>
    /// Gets size of the list.
    /// </summary>
    public int Size
    {
        get { return this.sizeOfList; }
    }

    /// <summary>
    /// Mehod adds element in list by position.
    /// </summary>
    /// <param name="value">value to adding in list.</param>
    /// <param name="position">position to element adding.</param>
    /// <returns> true if element has been added in correct position.
    /// False if element has been added in incorrect position.</returns>
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

    /// <summary>
    /// Method removes the element by position.
    /// </summary>
    /// <param name="position">position to element removing.</param>
    /// <returns> true if element has been removed by correct position.
    /// False if element has been removed by incorrect position.</returns>
    /// <exception cref="IncorrectOperationException">throws exception if list is empty.</exception>
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

    /// <summary>
    /// Method changes the element's value by position.
    /// </summary>
    /// <param name="position">position to element changing.</param>
    /// <param name="newValue">newValue for changing.</param>
    /// <exception cref="InvalidOperationException">throws exception if list is empty.</exception>
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

    /// <summary>
    /// Method gets element from list's head.
    /// </summary>
    /// <returns>element from list's head.</returns>
    /// <exception cref="InvalidOperationException">throws exception if list is empty.</exception>
    public T GetElementFromHead()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException();
        }

        return this.head.Value;
    }

    /// <summary>
    /// Method gets element from list's tail.
    /// </summary>
    /// <returns>element from list's head.</returns>
    /// <exception cref="InvalidOperationException">throws exception if list is empty.</exception>
    public T GetElementFromTail()
    {
        if (this.tail == null)
        {
            throw new InvalidOperationException();
        }

        return this.tail.Value;
    }

    /// <summary>
    /// Method checks how many same values are in list.
    /// </summary>
    /// <param name="value">value for search in list.</param>
    /// <returns> count of same values and same value's position.</returns>
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
