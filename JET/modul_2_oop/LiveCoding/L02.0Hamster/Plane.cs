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
    private Dictionary<(int x, int y), Seedling> _Seedlings = new();
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


        // wie viele Seedlings gibt es? zufällig.
        // Seedlings erstellen
        for (int i = 0; i < random.Next(1, Size*Size - _hamsters.Count); i++)
        {
            var Seedling = new Seedling(this);
            _Seedlings[Seedling.Position] = Seedling;
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

        // grafischer Aufruf
        if (!positionIsTaken)
        {
            _plane[positionOfHamsterToBeAssigned.y, positionOfHamsterToBeAssigned.x] = hamster.Representation; 
        }

        return positionIsTaken;

    }

    public bool TryToAssignInitialPosition(Seedling Seedling, (int x, int y) positionOfSeedlingToBeAssigned)
    {
        if (!_Seedlings.ContainsKey(positionOfSeedlingToBeAssigned))
        {
            // grafischer Aufruf
            _plane[positionOfSeedlingToBeAssigned.y, positionOfSeedlingToBeAssigned.x] = Seedling.Representation;
            return false;
        }

        return true;
    }

    public void Print(int delayInMilliseconds)
    {
        Console.SetCursorPosition(0, 0);

        AssignElementToPlane();

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

    private void AssignElementToPlane()
    {
        // alles ist erde
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                _plane[y, x] = _earthRepresentation;
            }
        }

        // nimm hamster und zeichne die position
        foreach (var hamster in _hamsters)
        {
            _plane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
        }

        // nimm Seedlings und zeichne die position
        foreach (var Seedlingling in _Seedlings.Values)
        {
            _plane[Seedlingling.Position.y, Seedlingling.Position.x] = Seedling.Representation;
        }
    }

    public void SimulateHamster()
    {
        foreach (var hamster in _hamsters)
        {
            hamster.Move();
            hamster.NutritionBehaviour();
        }
    }

    public void Position(Hamster hamster, Direction direction)
    {
        var pos = hamster.Position;

        switch(direction)
        {
            case Direction.LEFT:
                if (pos.x != 0)
                {
                    pos.x--;
                } 
                break;

            case Direction.RIGHT:
                if (pos.x != Size - 1)
                {
                    pos.x++;
                }
                break;

            case Direction.UP:
                if (pos.y != 0)
                {
                    pos.y--;
                }
                break;

            case Direction.DOWN:
                if (pos.y != Size - 1)
                {
                    pos.y++;
                }
                break;
        }

        hamster.Position = pos;

        //Console.WriteLine($"Hamster: {hamster.GetHashCode()} - pos:{hamster.Position}");
    }

    public void HamsterIsEatingSeedlings(Hamster hamster)
    {
        _Seedlings.Remove(hamster.Position);
    }

    public Seedling GetSeedlinglingOn((int x, int y) position)
    {
        return _Seedlings[position];
    }

    public bool ContainsSeedling((int x, int y) position)
    {
        return _Seedlings.ContainsKey(position);
    }

    public void SimulateSeedling()
    {
        RegrowSeedlings();
    }

    public void RegrowSeedlings()
    {
        var random = new Random();
        bool fieldIsTaken;
        (int x, int y) key;

        int potentialGrowth = (int)Math.Pow(_hamsters.Count, 2) / _Seedlings.Count;
        int freeTiles = Size * Size - _hamsters.Count - _Seedlings.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            do
            {
                key = (random.Next(Size), random.Next(Size));
                fieldIsTaken = _Seedlings.ContainsKey(key);
            } while (fieldIsTaken);

            _Seedlings[key] = new Seedling(this);
        }
    }
}
