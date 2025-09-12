using System;

namespace Fahrradverleih.Exceptions;

public class FahrradNichtVerfuegbarException : Exception
{
    public FahrradNichtVerfuegbarException(string message) : base(message) { }
}

public class AusleihvorgangException : Exception
{
    public AusleihvorgangException(string message, Exception innerException) : base(message, innerException) { }
}