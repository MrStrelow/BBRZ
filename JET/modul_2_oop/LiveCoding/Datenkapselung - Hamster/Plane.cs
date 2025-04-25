using System.Drawing;

namespace Hamster;

public class Plane
{
    // Felder
    private string[,] _plane;
    private static string _earthRepresentation = "🟫";

    // Eigenschaften
    public int Size { get; set; }

    // Beziehungen
    private Dictionary<(int x, int y), Seed> seeds = new();
    private List<Hamster> hamsters = new();

    // Konstruktor
    public Plane(int size)
    {
        
    }
}
