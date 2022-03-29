namespace UniqueList;
public class IncorrectOperationException : Exception
{
    public IncorrectOperationException()
    {
    }

    public IncorrectOperationException(string message)
        : base(message)
    {
    }
}
