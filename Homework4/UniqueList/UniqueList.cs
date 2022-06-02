namespace UniqueList;

/// <summary>
/// Method realizes the structure list without identical elements.
/// </summary>
/// <typeparam name="T">Type for list values.</typeparam>
public class UniqueList<T> : List<T>
{
    /// <summary>
    /// Mehod adds element in the Unique List by position.
    /// </summary>
    /// <param name="value">value to adding in list.</param>
    /// <param name="position">position to element adding.</param>
    /// <returns> true if element has been added in correct position.
    /// False if element has been added in incorrect position.</returns>
    /// <exception cref="IncorrectOperationException">throws expression if list
    /// has already contained this value.</exception>
    public override bool AddByPosition(T value, int position)
    {
        var (countOfSameValues, sameValuePosition) = this.HowManyValuesInList(value);
        if (countOfSameValues > 0)
        {
            throw new InvalidOperationException(
                "The list has already contained this element");
        }

        return base.AddByPosition(value, position);
    }

    /// <summary>
    /// Method changes the element's value by position.
    /// </summary>
    /// <param name="position">position to element changing.</param>
    /// <param name="value">newValue for changing.</param>
    /// <exception cref="InvalidOperationException">throws exception if
    /// list has already contained this element.</exception>
    public override void ChangeByPosition(int position, T value)
    {
        var (countOfSameValues, sameValuePosition) = this.HowManyValuesInList(value);
        if (countOfSameValues > 0)
        {
            if (sameValuePosition == position)
            {
                base.ChangeByPosition(position, value);
                (countOfSameValues, sameValuePosition) = this.HowManyValuesInList(value);
                if (countOfSameValues > 1)
                {
                    throw new InvalidOperationException(
                        "The list has already contained this element");
                }

                return;
            }

            throw new InvalidOperationException(
                    "The list has already contained this element");
        }

        base.ChangeByPosition(position, value);
    }
}
