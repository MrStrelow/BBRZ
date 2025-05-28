using Hamster.Strategies;

namespace Hamster;

public class Seedling
{
    // Felder
    // Eigenschaften (Properties)
    public (int x, int y) Position { get; private set; }
    public static IVisualRepresentation? Representation { get; protected set; }

    public Plane Plane { get; set; }

    // Konstruktor
    public Seedling(Plane plane, IRenderer renderer)
    {
        Plane = plane;

        // position and manage Seedlingling
        var random = new Random();
        bool done;
        int x, y;

        do
        {
            x = random.Next(Plane.Size);
            y = random.Next(Plane.Size);

            done = Plane.IsInitialPositionValid(this, (x, y));
        } while (!done);

        Position = (x, y);

        IVisualRepresentation representation = renderer switch
        {
            HtmlRenderer => new ImageRepresentation("resources/seedling.png"),
            ConsoleRenderer => new UnicodeRepresentation("🌱"),
            _ => throw new NotSupportedException()
        };

        Representation = representation;
    }
}
