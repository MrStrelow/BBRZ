namespace Hamster.Visuals.Representations;

public interface IRepresentation
{
    // wir verwendne hier in der zukunft generics.
    object Representation { get; init; }
    string ToString();
}
