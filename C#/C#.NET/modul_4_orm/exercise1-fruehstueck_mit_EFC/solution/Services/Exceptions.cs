using Serilog;

namespace MorgenstundRestaurant.Exceptions;

public class DishNotFoundException : Exception
{
    public DishNotFoundException(string message) : base(message) { }
}

public class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message) { }
}

public class MenuPreparationException : Exception
{
    public MenuPreparationException(string message, Exception innerException) : base(message, innerException) { }
}
public class OrderProcessingException : Exception
{
    public OrderProcessingException(string message, Exception innerException) : base(message, innerException) { }
}
