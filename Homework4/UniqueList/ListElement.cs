namespace UniqueList;
public class ListElement<T>
{
    public ListElement(T value)
    {
        this.Value = value;
        this.Next = null;
    }

    public T Value { get; set; }

    public ListElement<T>? Next { get; set; }
}
