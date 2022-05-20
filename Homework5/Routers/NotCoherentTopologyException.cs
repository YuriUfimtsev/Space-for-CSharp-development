namespace Routers;

/// <summary>
/// Class declares IncorrectInputException.
/// </summary>
public class NotCoherentTopologyException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotCoherentTopologyException"/> class.
    /// </summary>
    /// <param name="message">exception message.</param>
    public NotCoherentTopologyException(string message)
        : base(message)
    {
    }
}
