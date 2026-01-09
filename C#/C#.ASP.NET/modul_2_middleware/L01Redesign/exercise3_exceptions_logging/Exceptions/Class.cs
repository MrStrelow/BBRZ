namespace FruehstuecksBestellungMVC.Exceptions;

public class FruehstueckBusinessException : Exception
{
    public FruehstueckBusinessException(string message) : base(message)
    {
    }
}