using System.Drawing;
using System.Text;

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
        // variablen initialisieren
        Size = size;
        _plane = new string[size, size];

        var random = new Random();

        // Boden erstellen - grafisch
        for (int zeile = 0; zeile < size; zeile++)
        {
            for (int spalte = 0; spalte < size; spalte++)
            {
                _plane[zeile,spalte] = _earthRepresentation;
            }
        }

        // wie viele hamster gibt es? zufällig.
        // Hamster erstellen
        for (int i = 0; i < random.Next(minValue: 1, maxValue:Size); i++)
        {
            hamsters.Add(new Hamster());
        }


        // wie viele seeds gibt es? zufällig.
        // Seeds erstellen
    }

    public void Print(int delayInMilliseconds)
    {
        for (int zeile = 0; zeile < Size; zeile++)
        {
            for (int spalte = 0; spalte < Size; spalte++)
            {
                Console.Write(_plane[zeile,spalte]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(delayInMilliseconds);
    }
}
