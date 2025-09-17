using Hamster.Visuals;

namespace Hamster;

public class Seedling
{
    // Felder
    // Eigenschaften (Properties)
    public (int x, int y) Position { get; private set; }
    public static IVisuals Visual { get; protected set; } = new SeedlingVisuals();

    public Plane Plane { get; set; }

    // Konstruktor
    public Seedling(Plane plane)
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
    }
}
