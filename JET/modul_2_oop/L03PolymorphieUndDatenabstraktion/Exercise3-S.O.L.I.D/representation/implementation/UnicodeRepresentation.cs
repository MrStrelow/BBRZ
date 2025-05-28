namespace Hamster.Strategies;

// SRP (Single Responsibility Principle): Responsible for providing HTML-based visuals (could be text, emoji, or image tags).
// LSP (Liskov Substitution Principle): Can be used wherever an IVisualProvider is expected for HTML contexts.
public sealed class UnicodeRepresentation : IVisualRepresentation
{
    public object Representation { get; init; }

    public UnicodeRepresentation(string representation)
    {
        Representation = representation;
    }
}
