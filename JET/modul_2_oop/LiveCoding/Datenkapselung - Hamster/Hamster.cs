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
        Representation = Hamster._fedRepresentation;
        
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
            notDone = plane.TryToAssignInitialPosition(this, (x,y));
        }
        while (notDone);

        Position = (x, y); 
    }

    // Methoden
    public void Move()
    {
        var random = new Random();
        int directionIndex = random.Next(Enum.GetValues<Direction>().Length);
        var direction = Enum.GetValues<Direction>()[directionIndex];

        _plane.Position(this, direction);
       
    }
}
