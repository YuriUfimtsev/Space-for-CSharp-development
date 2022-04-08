﻿namespace Routers;

public class IncorrectInputException : Exception
{
    public IncorrectInputException()
    {
    }

    public IncorrectInputException(string message)
        : base(message)
    {
    }
}
