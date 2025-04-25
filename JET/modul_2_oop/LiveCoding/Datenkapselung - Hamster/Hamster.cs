namespace Hamster;

public class Hamster
{
    // Felder
    private static string _hungryRepresentation = "😡";
    private static string _fedRepresentation = "🐹";

    // Eigenschaftenpublic
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

        var x = random.Next(_plane.Size);
        var y = random.Next(_plane.Size);
        

    }


    // Methoden
}
