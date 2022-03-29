namespace UniqueList;

public class UniqueList<T> : List<T>
{
    public override bool AddByPosition(T value, int position)
    {
        var (countOfSameValues, sameValuePosition) = this.HowManyValuesInList(value);
        if (countOfSameValues > 0)
        {
            throw new IncorrectOperationException(
                "The list has already contained this element");
        }

        return base.AddByPosition(value, position);
    }

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
                    throw new IncorrectOperationException(
                        "The list has already contained this element");
                }

                return;
            }

            throw new IncorrectOperationException(
                    "The list has already contained this element");
        }

        base.ChangeByPosition(position, value);
    }
}
