namespace Hamster.Strategies;

// SRP (Single Responsibility Principle): Defines a contract for providing a visual string based on state.
// ISP (Interface Segregation Principle): A focused interface for getting visual representations.
public interface IVisualRepresentation
{
    // OCP (Open/Closed Principle): New ways of providing visuals (e.g., based on more states)
    // could be handled by new methods or new interfaces inheriting this one if needed,
    // or by passing a more complex state object.
    public object Representation { get; init; }
}