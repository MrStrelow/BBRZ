namespace Hamster;

public class Hamster
{
    // Felder
    private static string _hungryRepresentation = "😡";
    private static string _fedRepresentation = "🐹";

    // Eigenschaften
    public (int x, int y) Position { get; set; }
    public string Representation { get; private set; }
    public bool IsHungry { get; private set; }

    // Beziehungen
    private Plane _plane;
    private List<Seed> mouth = new();

    // Konstruktoren
    public Hamster(Plane plane)
    {
        _plane = plane;
        // Zufällige Position wählen
        var random = new Random();

        bool done;
        int x;
        int y;

        // Plane sagt passt oder passt nicht
        // Zuständigkeit: probiere neue zufällige x und y zuweisungen aus.
        do 
        {
            x = random.Next(_plane.Size);
            y = random.Next(_plane.Size);
            done = plane.TryToAssignInitialPosition(this, (x,y));
        }
        while (!done);

        Position = (x, y); 
    }


    // Methoden
}
