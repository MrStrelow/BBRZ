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
    private Dictionary<(int x, int y), Seed> _seeds = new();
    private List<Hamster> _hamsters = new();

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
        for (int i = 0; i < random.Next(1, Size*Size); i++)
        {
            _hamsters.Add(new Hamster(this));
        }


        // wie viele seeds gibt es? zufällig.
        // Seeds erstellen
        for (int i = 0; i < random.Next(1, Size*Size - _hamsters.Count); i++)
        {
            var seed = new Seed();
            _seeds[seed.Position] = seed;
        }
    }

    public bool TryToAssignInitialPosition(Hamster hamster, (int x, int y) positionOfHamsterToBeAssigned)
    {
        bool positionIsTaken = false;

        // Logik
        foreach (var alreadyExistingHamster in _hamsters)
        {
            if (alreadyExistingHamster.Position == positionOfHamsterToBeAssigned)
            {
                positionIsTaken = true;
                break;
            }
        }

        // grafischer Aufruf.
        if (!positionIsTaken)
        {
            _plane[positionOfHamsterToBeAssigned.y, positionOfHamsterToBeAssigned.x] = hamster.Representation; 
        }

        return positionIsTaken;

    }

    public void Print(int delayInMilliseconds)
    {
        Console.SetCursorPosition(0, 0);

        for (int zeile = 0; zeile < Size; zeile++)
        {
            for (int spalte = 0; spalte < Size; spalte++)
            {
                Console.Write(_plane[zeile,spalte]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(delayInMilliseconds);
        Console.WriteLine();
    }
}
