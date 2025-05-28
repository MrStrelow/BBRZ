namespace Hamster;

public class Plane
{
    // Felder
    private string[,] _plane;
    private static string _earthRepresentation = "🟫";

    // Eigenschaften
    public int Size { get; }

    // Beziehungen
    private Dictionary<(int x, int y), Seedling> _Seedlings = new();
    private List<Hamster> _hamsters = new();

    // Konstruktor
    public Plane(int size)
    {
        var random = new Random();
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
        int numberOfSeedlings = random.Next(1, size * size);
        for (int i = 0; i < numberOfSeedlings; i++)
        {
            var Seedling = new Seedling(this);
            _Seedlings[Seedling.Position] = Seedling;
        }

        // Hamster
        int numberOfHamster = random.Next(1, size * size - numberOfSeedlings + 1);
        Console.WriteLine(numberOfSeedlings + numberOfHamster);
        for (int i = 0; i < numberOfHamster; i++)
        {
            _hamsters.Add(new Hamster(this));
        }
    }

    public void SimulateSeedling()
    {
        RegrowSeedlings();
    }

    public void SimulateHamster()
    {
        foreach (var hamster in _hamsters)
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

        foreach (var hamster in _hamsters)
        {
            _plane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
        }

        foreach (var Seedling in _Seedlings.Values)
        {
            _plane[Seedling.Position.y, Seedling.Position.x] = Seedling.Representation;
        }
    }

    public void HamsterIsEatingSeedlings(Hamster hamster)
    {
        _Seedlings.Remove(hamster.Position);
    }

    public void HamsterIsStoringSeedlings(Hamster hamster)
    {
        _Seedlings.Remove(hamster.Position);
    }

    public void RegrowSeedlings()
    {
        int potentialGrowth = (int)Math.Pow(_hamsters.Count, 2) / _Seedlings.Count;
        int freeTiles = Size * Size - _hamsters.Count - _Seedlings.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            var Seedling = new Seedling(this);
            _Seedlings[Seedling.Position] = Seedling;
        }
    }

    public bool AssignInitialPosition(Hamster hamster, (int x, int y) key)
    {
        if (!_Seedlings.ContainsKey(key) && !TileTakenByHamster(key))
        {
            _plane[key.y, key.x] = hamster.Representation;
            return true;
        }

        return false;
    }

    public bool AssignInitialPosition(Seedling Seedling, (int x, int y) key)
    {
        if (!_Seedlings.ContainsKey(key) && !TileTakenByHamster(key))
        {
            _plane[key.y, key.x] = Seedling.Representation;
            return true;
        }

        return false;
    }

    public bool TileTakenByHamster((int x, int y) key)
    {
        foreach (var hamster in _hamsters)
        {
            if (hamster.Position == key)
            {
                return true;
            }
        }

        return false;

        //Zukunft - alternative schreibweise: return _hamsters.Any(h => h.Position == key);
    }

    public bool ContainsSeedling((int x, int y) key)
    {
        return _Seedlings.ContainsKey(key);
    }

    public Seedling GetSeedlingOn((int x, int y) key)
    {
        return _Seedlings[key];
    }
}
