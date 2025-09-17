namespace Hamster.Visuals.Representations;

// wir verwendne hier in der zukunft generics.
public sealed class UnicodeRepresentation : IRepresentation
{
    public object Representation { get; init; }

    public UnicodeRepresentation(string representation)
    {
        Representation = representation;
    }

    public override string ToString()
    {
        return (string) Representation;
    }
}
