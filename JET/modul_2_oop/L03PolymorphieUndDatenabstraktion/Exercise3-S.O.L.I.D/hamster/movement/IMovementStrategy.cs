// IMovementStrategy.cs
namespace Hamster.Strategies;

// ISP (Interface Segregation Principle): This interface is small and focused on movement.
// Clients (like Hamster) only need to know about planning a move, not other unrelated actions.
public interface IMovementStrategy
{
    // SRP (Single Responsibility Principle): This interface's sole responsibility is to define the contract for movement planning.
    // OCP (Open/Closed Principle): New movement algorithms can be added by creating new classes that implement this interface,
    // without modifying existing code that uses IMovementStrategy.
    void Execute(Hamster hamster, Plane plane);
}
