// Plane.cs
using Hamster.Strategies;

namespace Hamster;

public class Plane
{
    // Felder
    // Eigenschaften
    public int Size { get; private set; }

    // Beziehungen
    public Dictionary<(int x, int y), Seedling> Seedlings { get; private set; } = new();
    public List<Hamster> Hamsters { get; private set; } = new();
    public IRenderer Renderer { get; set; }

    public static IVisualRepresentation? Representation { get; protected set; }

    // Konstruktor
    public Plane(int size, IRenderer renderer)
    {
        Size = size;
        Renderer = renderer;

        var random = new Random();

        int numberOfSeedlings = random.Next(1, size * size);
        for (int i = 0; i < numberOfSeedlings; i++)
        {
            var Seedling = new Seedling(this, Renderer);
            Seedlings[Seedling.Position] = Seedling;
        }

        int numberOfHamster = random.Next(1, size * size - numberOfSeedlings + 1);
        for (int i = 0; i < numberOfHamster; i++)
        {
            if (random.NextDouble() < 0.5)
            {
                Hamsters.Add(new BigLegHamster(this, Renderer));
            }
            else
            {
                Hamsters.Add(new BigMouthHamster(this, Renderer));
            }
        }

        IVisualRepresentation representation = Renderer switch // tight coupling.
        {
            HtmlRenderer => new ImageRepresentation("resources/soil.png"), 
            // TODO: Sprich "Fehler" an. Verwenden wir wirklich das Image oder nur den path?
            // Wir haben hier die Haupteigenschaft Image welche wirnicht wirklich verwenden.
            // Neue Implementierung -> html representation. Das schaut aber gleich aus wie die unicode representation.
            // wir sollten uns nicht mit solchen dinge aufhalten, denn diese haben keinen effekt auf die Kriterien/Ziele.

            ConsoleRenderer => new UnicodeRepresentation("🟫"),
            _ => throw new NotSupportedException()
        };


    }

    public void SimulateSeedling()
    {
        RegrowSeedlings(Renderer);
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

    public void RegrowSeedlings(IRenderer Renderer)
    {
        int potentialGrowth = (int)Math.Pow(Hamsters.Count, 2) / Seedlings.Count;
        int freeTiles = Size * Size - Hamsters.Count - Seedlings.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            var Seedling = new Seedling(this, Renderer);
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