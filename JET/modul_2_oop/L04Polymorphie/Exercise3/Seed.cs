namespace Hamster;

public class Seed
{
    // Felder
    // Eigenschaften (Properties)
    public (int x, int y) Position { get; private set; }
    public static string Representation => "🌱";

    public Plane Plane { get; set; }

    // Konstruktor
    public Seed(Plane plane)
    {
        Plane = plane;
        PositionAndManageSeed();
    }

    private void PositionAndManageSeed()
    {
        var random = new Random();
        bool done;
        int x, y;

        do
        {
            x = random.Next(Plane.Size);
            y = random.Next(Plane.Size);

            done = Plane.AssignInitialPosition(this, (x, y));
        } while (!done);

        Position = (x, y);
    }

    public override string ToString()
    {
        return Representation;
    }
}
