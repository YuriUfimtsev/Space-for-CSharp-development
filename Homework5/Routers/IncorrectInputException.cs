namespace Routers;

/// <summary>
/// Class declares IncorrectInputException.
/// </summary>
public class IncorrectInputException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IncorrectInputException"/> class.
    /// </summary>
    /// <param name="message">exception message.</param>
    public IncorrectInputException(string message)
        : base(message)
    {
    }
}
