using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort;

public class ObjectComparer<T> : IComparer<T>
{
    /// <summary>
    /// Initializes a new instance of ObjectComparer.
    /// </summary>
    /// <param name="newSortFunction">Sort function for this cpmparer.</param>
    public ObjectComparer(Func<T, T, int> newSortFunction)
    {
        sortFunction = newSortFunction;
    }

    private Func<T, T, int> sortFunction;

    /// <summary>
    /// Compares two objects.
    /// </summary>
    /// <param name="firstElement">First element to compare.</param>
    /// <param name="secondElement">Second element to compare.</param>
    /// <returns>Greater than zero if the first object is greater than the second. 
    /// Zero if they are equal. Less than zero else.</returns>
    public int Compare(T? firstElement, T? secondElement)
    {
        if (firstElement == null)
        {
            if (secondElement == null)
            {
                return 0;
            }

            return -1;
        }

        if (secondElement == null)
        {
            return 1;
        }

        return sortFunction(firstElement, secondElement);
    }

}
