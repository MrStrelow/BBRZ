namespace Hamster;

public class Plane
{
    // Felder
    private string[,] _plane;
    private static string _earthRepresentation = "🟫";

    // Eigenschaften
    public int Size { get; }

    // Beziehungen
    private Dictionary<(int x, int y), Seed> seeds = new();
    private List<Hamster> hamsters = new();

    // Konstruktor
    public Plane(int size)
    {
        Random random = new();
        Size = size;
        _plane = new string[size, size];

        // Boden
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                _plane[i, j] = _earthRepresentation;
            }
        }

        // Samen
        int numberOfSeeds = random.Next(1, size * size);
        for (int i = 0; i < numberOfSeeds; i++)
        {
            _ = new Seed(this);
        }

        // Hamster
        int numberOfHamster = random.Next(1, size * size - numberOfSeeds + 1);
        for (int i = 0; i < numberOfHamster; i++)
        {
            _ = new Hamster(this);
        }
    }

    public void SimulateSeed()
    {
        RegrowSeeds();
    }

    public void SimulateHamster()
    {
        foreach (var hamster in hamsters)
        {
            hamster.Move();
            hamster.NutritionBehaviour();
        }
    }

    public void Print(int timeToSleep = 500)
    {
        AssignElementsToPlane();
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write(_plane[i, j]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(timeToSleep);
    }

    public void Position(Hamster hamster, Direction direction)
    {
        var pos = hamster.Position;

        switch (direction)
        {
            case Direction.UP:
                if (pos.y > 0)
                    // Alternativ:// hamster.Position = (hamster.Position.x, hamster.Position.y - 1);
                    pos.y--;
                break;

            case Direction.DOWN:
                if (pos.y < Size - 1)
                    pos.y++;
                break;

            case Direction.LEFT:
                if (pos.x > 0)
                    pos.x--;
                break;

            case Direction.RIGHT:
                if (hamster.Position.x < Size - 1)
                    pos.x++;
                break;
        }

        hamster.Position = pos;
    }

    public void AssignElementsToPlane()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                _plane[i, j] = _earthRepresentation;
            }
        }

        foreach (var hamster in hamsters)
        {
            _plane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
        }

        foreach (var seed in seeds.Values)
        {
            _plane[seed.Position.y, seed.Position.x] = Seed.Representation;
        }
    }

    public void HamsterIsEatingSeeds(Hamster hamster)
    {
        seeds.Remove((hamster.Position.x, hamster.Position.y));
    }

    public void HamsterIsStoringSeeds(Hamster hamster)
    {
        seeds.Remove((hamster.Position.x, hamster.Position.y));
    }

    public void RegrowSeeds()
    {
        var random = new Random();
        bool fieldIsTaken;
        (int x, int y) key;

        int potentialGrowth = (int)Math.Pow(hamsters.Count, 2) / seeds.Count;
        int freeTiles = Size * Size - hamsters.Count - seeds.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            do
            {
                key = (random.Next(Size), random.Next(Size));
                fieldIsTaken = seeds.ContainsKey(key) || TileTakenByHamster(key);
            } while (fieldIsTaken);

            seeds[key] = new Seed(this);
        }
    }

    public bool AssignInitialPosition(Hamster hamster, (int x, int y) key)
    {
        if (!seeds.ContainsKey(key) && !TileTakenByHamster(key))
        {
            _plane[key.y, key.x] = hamster.Representation;
            hamsters.Add(hamster);
            return true;
        }

        return false;
    }

    public bool AssignInitialPosition(Seed seed, (int x, int y) key)
    {
        if (!seeds.ContainsKey(key) && !TileTakenByHamster(key))
        {
            _plane[key.y, key.x] = Seed.Representation;
            seeds[key] = seed;
            return true;
        }

        return false;
    }

    private bool TileTakenByHamster((int x, int y) key)
    {
        return hamsters.Any(h => h.Position == key);
    }

    public bool ContainsSeed((int x, int y) key)
    {
        return seeds.ContainsKey(key);
    }

    public Seed GetSeedOn((int x, int y) key)
    {
        return seeds[key];
    }
}
