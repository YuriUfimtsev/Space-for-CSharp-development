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


    //public bool GetByPosition(T value, int position)

    //public bool RemoveByPosition(T value, int position)
}
