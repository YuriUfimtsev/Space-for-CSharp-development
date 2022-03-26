using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList;

public class List<T>
{
    ListElement<T>? head;
    ListElement<T>? tail;
    int sizeOfList;

    public int Size
    {
        get { return sizeOfList; }
    }

    public List()
    {
        head = null;
        tail = null;
        sizeOfList = 0;
    }

    public bool AddByPosition(T value, int position)
    {
        ListElement<T> newElement = new(value);
        ++sizeOfList;
        if (head == null)
        {
            head = newElement;
            tail = newElement;
            return position == 0;
        }

        if (position > sizeOfList)
        {
            tail!.Next = newElement;
            tail = tail!.Next;
            return false;
        }

        if (position <= 0)
        {
            ListElement<T> headElement = head;
            newElement.Next = headElement;
            this.head = newElement;
            return true;
        }

        ListElement<T> currentElement = head;
        for (int i = 0; i < position - 1; ++i)
        {
            currentElement = currentElement.Next!;
        }

        newElement.Next = currentElement.Next;
        currentElement.Next = newElement;
        currentElement.Next = newElement;
        if (newElement.Next == null)
        {
            tail = newElement;
        }

        return true;
    }

    public bool RemoveByPosition(int position)
    {
        if (head == null)
        {
            throw new InvalidOperationException();
        }

        --sizeOfList;
        if (sizeOfList == 0)
        {
            head = null;
            tail = null;
            return position == 0;
        }

        if (position <= 0)
        {
            head = head.Next;
            return false;
        }

        ListElement<T> currentElement = head;
        if (position > sizeOfList)
        {
            while (currentElement.Next!.Next != null)
            {
                currentElement = currentElement.Next;
            }
            currentElement.Next = null;
            tail = currentElement;
            return false;
        }

        for (int i = 0; i < position - 1; ++i)
        {
            currentElement = currentElement.Next!;
        }

        currentElement.Next = currentElement.Next!.Next;
        if (currentElement.Next == null)
        {
            tail = currentElement;
        }

        return true;
    }

    public bool ChangeByPosition(int position, T newValue)
    {
        if (head == null)
        {
            throw new InvalidOperationException();
        }

        if (position <= 0)
        {
            head.Value = newValue;
            return false;
        }

        if (position >= sizeOfList - 1)
        {
            tail!.Value = newValue;
            return false;
        }

        ListElement<T> currentElement = head;
        for (int i = 0; i < position; ++i)
        {
            currentElement = currentElement.Next!;
        }

        currentElement.Value = newValue;
        return true;
    }

    public T GetElementFromHead()
    {
        if (head == null)
        {
            throw new InvalidOperationException();
        }

        return head.Value;
    }

    public T GetElementFromTail()
    {
        if (tail == null)
        {
            throw new InvalidOperationException();
        }

        return tail.Value;
    }
}
