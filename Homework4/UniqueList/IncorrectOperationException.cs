namespace UniqueList;

/// <summary>
/// Exception class for the Unique list.
/// </summary>
public class IncorrectOperationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IncorrectOperationException"/> class.
    /// </summary>
    public IncorrectOperationException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncorrectOperationException"/> class.
    /// </summary>
    /// <param name="message">Error message.</param>
    public IncorrectOperationException(string message)
        : base(message)
    {
    }
}
