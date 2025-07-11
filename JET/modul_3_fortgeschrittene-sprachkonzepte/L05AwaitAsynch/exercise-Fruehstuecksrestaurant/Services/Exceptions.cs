using Serilog;

namespace MorgenstundRestaurant.Exceptions;

/// <summary>
/// Thrown when a required dish cannot be found in the repository.
/// </summary>
public class DishNotFoundException : Exception
{
    public DishNotFoundException(string message) : base(message) { }
}

/// <summary>
/// Thrown when an ingredient is not available in the required quantity.
/// </summary>
public class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message) { }
}

/// <summary>
/// Thrown when a menu cannot be prepared due to an issue with one of its dishes.
/// This exception wraps the original dish-related error.
/// </summary>
public class MenuPreparationException : Exception
{
    public MenuPreparationException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Thrown when a customer's order for a table cannot be processed.
/// This is the top-level business exception that wraps menu-related errors.
/// </summary>
public class OrderProcessingException : Exception
{
    public OrderProcessingException(string message, Exception innerException) : base(message, innerException) { }
}
