using Hamster.Visuals;

namespace Hamster;

public class Plane
{
    // Felder
    // Eigenschaften
    public int Size { get; private set; }

    // Beziehungen
    public Dictionary<(int x, int y), Seedling> Seedlings { get; private set; } = new();
    public List<Hamster> Hamsters { get; private set; } = new();

    // TODO: Sprich "Fehler" an. Verwenden wir wirklich das Image oder nur den path?
    // Wir haben hier die Haupteigenschaft Image welche wir nicht wirklich verwenden.
    // Neue Implementierung -> html representation. Das schaut aber gleich aus wie die unicode representation.
    // wir sollten uns nicht mit solchen dinge aufhalten, denn diese haben keinen effekt auf die Kriterien/Ziele.
    public static IVisuals Visual { get; protected set; } = new PlaneVisuals();

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
            if (random.NextDouble() < 0.33)
            {
                Hamsters.Add(new BigLegHamster(this));
            }
            else if (random.NextDouble() < 0.33)
            {
                Hamsters.Add(new BigLegHamster(this));
            }
            else
            {
                Hamsters.Add(new NervousHamster(this));
            }
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

    // überladen!
    public void Position(Hamster hamster, Direction direction)
    {
        Position(hamster, new List<Direction> { direction });
    }

    public void Position(Hamster hamster, List<Direction> directions)
    {
        var pos = hamster.Position;

        foreach (var direction in directions)
        {
            switch (direction)
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
        }

        hamster.Position = pos;
    }

    public void HamsterIsEatingSeedlings(Seedling Seedling)
    {
        Seedlings.Remove(Seedling.Position);
    }

    public void HamsterIsStoringSeedlings(Seedling Seedling)
    {
        Seedlings.Remove(Seedling.Position);
    }

    public void RegrowSeedlings()
    {
        int SeedlingsAboveZero = Seedlings.Count == 0 ? 1 : Seedlings.Count;

        int potentialGrowth = (int)Math.Pow(Hamsters.Count, 2) / SeedlingsAboveZero;
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

    public bool TryGetSeedling((int x, int y) key, out Seedling? seedling)
    {
        if (Seedlings.TryGetValue(key, out seedling))
        {
            return true;
        }

        return false;
    }
}