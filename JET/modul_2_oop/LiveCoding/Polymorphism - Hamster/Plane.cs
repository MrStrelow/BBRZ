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
            var seed = new Seed(this);
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

        // grafischer Aufruf
        if (!positionIsTaken)
        {
            _plane[positionOfHamsterToBeAssigned.y, positionOfHamsterToBeAssigned.x] = hamster.Representation; 
        }

        return positionIsTaken;

    }

    public bool TryToAssignInitialPosition(Seed seed, (int x, int y) positionOfSeedToBeAssigned)
    {
        if (!_seeds.ContainsKey(positionOfSeedToBeAssigned))
        {
            // grafischer Aufruf
            _plane[positionOfSeedToBeAssigned.y, positionOfSeedToBeAssigned.x] = Seed.Representation;
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

        // nimm seeds und zeichne die position
        foreach (var seedling in _seeds.Values)
        {
            _plane[seedling.Position.y, seedling.Position.x] = Seed.Representation;
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

    public void HamsterIsEatingSeeds(Hamster hamster)
    {
        _seeds.Remove(hamster.Position);
    }

    public Seed GetSeedlingOn((int x, int y) position)
    {
        return _seeds[position];
    }

    public bool ContainsSeed((int x, int y) position)
    {
        return _seeds.ContainsKey(position);
    }

    public void SimulateSeed()
    {
        RegrowSeeds();
    }

    public void RegrowSeeds()
    {
        var random = new Random();
        bool fieldIsTaken;
        (int x, int y) key;

        int potentialGrowth = (int)Math.Pow(_hamsters.Count, 2) / _seeds.Count;
        int freeTiles = Size * Size - _hamsters.Count - _seeds.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            do
            {
                key = (random.Next(Size), random.Next(Size));
                fieldIsTaken = _seeds.ContainsKey(key);
            } while (fieldIsTaken);

            _seeds[key] = new Seed(this);
        }
    }
}
