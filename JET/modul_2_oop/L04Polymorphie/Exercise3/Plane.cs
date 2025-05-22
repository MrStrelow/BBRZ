// Plane.cs
namespace Hamster;

public class Plane
{
    // Felder
    // Eigenschaften
    public int Size { get; private set; }

    // Beziehungen
    public Dictionary<(int x, int y), Seed> Seeds { get; private set; } = new();
    public List<Hamster> Hamsters { get; private set; } = new();

    // Konstruktor
    public Plane(int size)
    {
        Size = size;
        Random random = new();

        int numberOfSeeds = random.Next(1, size * size);
        for (int i = 0; i < numberOfSeeds; i++)
        {
            _ = new Seed(this);
        }

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

    private bool TileTakenByAnotherHamster((int x, int y) key, Hamster requestingHamster)
    {
        return Hamsters.Any(h => h != requestingHamster && h.Position == key);
    }


    public void HamsterIsEatingSeeds(Hamster hamster)
    {
        Seeds.Remove(hamster.Position);
    }

    public void HamsterIsStoringSeeds(Hamster hamster)
    {
        Seeds.Remove(hamster.Position);
    }

    public void RegrowSeeds()
    {
        var random = new Random();
        bool fieldIsTaken;
        (int x, int y) key;

        int potentialGrowth = (int)Math.Pow(Hamsters.Count, 2) / Seeds.Count;
        int freeTiles = Size * Size - Hamsters.Count - Seeds.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            do
            {
                key = (random.Next(Size), random.Next(Size));
                fieldIsTaken = Seeds.ContainsKey(key) || TileTakenByHamster(key);
            } while (fieldIsTaken);

            Seeds[key] = new Seed(this);
        }
    }

    public bool AssignInitialPosition(Hamster hamster, (int x, int y) key)
    {
        if (!Seeds.ContainsKey(key) && !TileTakenByHamster(key))
        {
            if (!Hamsters.Contains(hamster)) 
            {
                Hamsters.Add(hamster);
            }
            hamster.Position = key;
            return true;
        }
        return false;
    }

    public bool AssignInitialPosition(Seed seed, (int x, int y) key)
    {
        if (!Seeds.ContainsKey(key) && !TileTakenByHamster(key))
        {
            Seeds[key] = seed;
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

        //return hamsters.Any(h => h.Position == key);
    }

    public bool TryGetSeed((int x, int y) key, out Seed seed)
    {
        if (Seeds.TryGetValue(key, out seed))
        {
            return true;
        }

        return false;
    }
}