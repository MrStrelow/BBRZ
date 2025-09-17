// Plane.cs
namespace Hamster;

public class Plane
{
    // Felder
    // Eigenschaften
    public int Size { get; private set; }

    // Beziehungen
    public Dictionary<(int x, int y), Seedling> Seedlings { get; private set; } = new();
    public List<Hamster> Hamsters { get; private set; } = new();

    // Konstruktor
    public Plane(int size)
    {
        Size = size;
        var random = new Random();

        int numberOfSeedlings = random.Next(1, size * size);
        for (int i = 0; i < numberOfSeedlings; i++)
        {
            var Seedling = new Seedling(this);
            Seedlings[Seedling.Position] = Seedling;
        }

        int numberOfHamster = random.Next(1, size * size - numberOfSeedlings + 1);
        for (int i = 0; i < numberOfHamster; i++)
        {
            Hamsters.Add(new Hamster(this));
        }
    }

    public void SimulateSeedling()
    {
        RegrowSeedlings();
    }

    public void SimulateHamster()
    {
        foreach (var hamster in Hamsters.ToList())
        {
            hamster.Move();
            hamster.NutritionBehaviour();
        }
    }

    public void Position(Hamster hamster, Direction direction)
    {
        var pos = hamster.Position;

        switch (direction)
        {
            case Direction.UP:
                if (pos.y > 0) pos.y--;
                break;
            case Direction.DOWN:
                if (pos.y < Size - 1) pos.y++;
                break;
            case Direction.LEFT:
                if (pos.x > 0) pos.x--;
                break;
            case Direction.RIGHT:
                if (pos.x < Size - 1) pos.x++;
                break;
        }

        hamster.Position = pos;
    }

    public void HamsterIsEatingSeedlings(Hamster hamster)
    {
        Seedlings.Remove(hamster.Position);
    }

    public void HamsterIsStoringSeedlings(Hamster hamster)
    {
        Seedlings.Remove(hamster.Position);
    }

    public void RegrowSeedlings()
    {
        int potentialGrowth = (int)Math.Pow(Hamsters.Count, 2) / Seedlings.Count;
        int freeTiles = Size * Size - Hamsters.Count - Seedlings.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            var Seedling = new Seedling(this);
            Seedlings[Seedling.Position] = Seedling;
        }
    }

    public bool IsInitialPositionValid(Hamster hamster, (int x, int y) key)
    {
        if (!Seedlings.ContainsKey(key) && !TileTakenByHamster(key))
        {
            return true;
        }
        return false;
    }

    public bool IsInitialPositionValid(Seedling Seedling, (int x, int y) key)
    {
        if (!Seedlings.ContainsKey(key) && !TileTakenByHamster(key))
        {
            return true;
        }
        return false;
    }

    public bool TileTakenByHamster((int x, int y) key)
    {
        foreach (var hamster in Hamsters)
        {
            if (hamster.Position == key)
            {
                return true;
            }
        }

        return false;

        //Zukunft - alternative schreibweise: return hamsters.Any(h => h.Position == key);
    }

    public bool TryGetSeedling((int x, int y) key, out Seedling Seedling)
    {
        if (Seedlings.TryGetValue(key, out Seedling))
        {
            return true;
        }

        return false;
    }
}