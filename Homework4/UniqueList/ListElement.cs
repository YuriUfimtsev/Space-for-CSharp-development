namespace UniqueList;

/// <summary>
/// Class realize structure ListElement for List class.
/// </summary>
/// <typeparam name="T">Type for ListElement values.</typeparam>
public class ListElement<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListElement{T}"/> class.
    /// </summary>
    /// <param name="value">value for adding to ListElement.</param>
    public ListElement(T value)
    {
        this.Value = value;
        this.Next = null;
    }

    /// <summary>
    /// Gets or sets ListElement's value.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Gets or sets next element for current ListElement.
    /// </summary>
    public ListElement<T>? Next { get; set; }
}
