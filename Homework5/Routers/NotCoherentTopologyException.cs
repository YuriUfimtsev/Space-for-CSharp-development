namespace Routers;

public class NotCoherentTopologyException : Exception
{
    public NotCoherentTopologyException()
    {
    }

    public NotCoherentTopologyException(string message)
        : base(message)
    {
    }
}
