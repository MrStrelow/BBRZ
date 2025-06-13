using System.Text.RegularExpressions;

namespace Hamster.Visuals.Representations;

// wir verwendne hier in der zukunft generics.
public sealed class HtmlRepresentation : IRepresentation
{
    public object Representation { get; init; }
    public string Path { get; init; }
    public int SizeToDisplay { get; init; }

    public HtmlRepresentation(string path, int sizeToDisplay)
    {
        Path = path;
        SizeToDisplay = sizeToDisplay;

        Representation =    $"<img " +
                                $"src='{Path}' " + //Path hier muss für das html file funktionieren.
                                $"width='{SizeToDisplay}' " +
                                $"height='{SizeToDisplay}' " +
                            $"/> ";
    }

    public override string ToString()
    {
        return (string) Representation;
    }
}
