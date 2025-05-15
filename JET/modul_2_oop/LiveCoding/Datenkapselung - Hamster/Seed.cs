namespace Hamster;

public class Seed
{
    // Felder
    private Plane _plane;

    // Eigenschaften (Properties)
    public (int x, int y) Position { get; private set; }
    public static string Representation = "🌱";

    public Seed(Plane plane)
    {
        _plane = plane;

        // Zufällige Position wählen
        var random = new Random();

        bool notDone;
        int x;
        int y;

        // Plane sagt passt oder passt nicht
        // Zuständigkeit: probiere neue zufällige x und y zuweisungen aus.
        do
        {
            x = random.Next(_plane.Size);
            y = random.Next(_plane.Size);
            notDone = plane.TryToAssignInitialPosition(this, (x, y));
        }
        while (notDone);

        Position = (x, y);
    }
}

