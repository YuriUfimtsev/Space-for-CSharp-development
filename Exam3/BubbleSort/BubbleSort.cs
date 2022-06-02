namespace BubbleSort;
/// <summary>
/// Class realizes bubble sort.
/// </summary>
/// <typeparam name="T"> Arbitrary type for objects. </typeparam>
public static class BubbleSort<T>
{
    /// <summary>
    /// Method sorts list.
    /// </summary>
    /// <param name="objectList"> list with with T type objects.</param>
    /// <param name="objectComparer">Object that allows you to compare objects from a list.</param>
    /// <returns>Sorted list.</returns>
    public static List<T> Sort(List<T> objectList, IComparer<T> objectComparer)
    {
        for (var i = 0; i < objectList.Count; ++i)
        {
            for (var j = 0; j < objectList.Count - 1; ++j)
            {
                if (objectComparer.Compare(objectList[j], objectList[j + 1]) > 0)
                {
                    (objectList[j + 1], objectList[j]) = (objectList[j], objectList[j + 1]);
                }
            }
        }

        return objectList;
    }
}