namespace Hamster;

public class Plane
{
    // Felder
    private String[,] plane;
    private int size;
    private static String earthRepresentation = "🟫";

    // (hat) Beziehungen
    private Dictionary<(int x, int y), Seed> seeds = new Dictionary<(int x, int y), Seed>();
    private List<Hamster> hamsters = new List<Hamster>();

    // Konstruktor
    public Plane(int size)
    {
        Random random = new Random();
        this.size = size;
        plane = new String[size,size];

        // wir belegen das spielfeld mit Bodensymbole
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                plane[i,j] = earthRepresentation;
            }
        }

        // wir brauchen Samen
        int numberOfSeeds = random.Next(1, size * size);
        for (int i = 0; i < numberOfSeeds; i++)
        {
            new Seed(this);
        }

        // wir brauchen Hamster
        int numberOfHamster = random.Next(1, size * size - numberOfSeeds + 1);
        for (int i = 0; i < numberOfHamster; i++)
        {
            new Hamster(this);
        }
    }

    // Methoden
    public void SimulateSeed()
    {
        Regrowth();
    }

    public void SimulateHamster()
    {
        foreach (var hamster in hamsters)
        {
            hamster.Move();
            hamster.NutritionBehaviour();
        }
    }

    public void Print()
    {
        Console.Clear();

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(plane[i,j]);
            }
            Console.WriteLine();
        }
    }

    public void Position(Hamster hamster, Direction direction)
    {
        plane[hamster.GetY(), hamster.GetX()] = hamster.GetTileToRemember();

        switch (direction)
        {
            case Direction.UP:
                if (hamster.GetY() > 0)
                {
                    hamster.SetY(hamster.GetY() - 1);
                }
                break;

            case Direction.DOWN: 
                if (hamster.GetY() < size - 1)
                {
                    hamster.SetY(hamster.GetY() + 1);
                }
                break;

            case Direction.LEFT: 
                if (hamster.GetX() > 0)
                {
                    hamster.SetX(hamster.GetX() - 1);
                }
                break;

            case Direction.RIGHT:           
                if (hamster.GetX() < size - 1)
                {
                    hamster.SetX(hamster.GetX() + 1);
                }
                break;
            }

        var hamsterSymbol = plane[hamster.GetY(), hamster.GetX()];
        bool isHamsterFreeTile =
                hamsterSymbol == Hamster.GetFedRepresentation() ||
                hamsterSymbol == Hamster.GetHungryRepresentation();

        if (!isHamsterFreeTile)
        {
            hamster.SetTileToRemember(plane[hamster.GetY(), hamster.GetX()]);
        }

        plane[hamster.GetY(), hamster.GetX()] = hamster.GetRepresentation();
    }

    public void HamsterIsEatingSeeds(Hamster hamster)
    {
        seeds.Remove((hamster.GetX(), hamster.GetY()));

        // symbol im spielfeld wird überschrieben mit dem standard symbol (boden)
        hamster.SetTileToRemember(earthRepresentation);
    }

    public void HamsterIsStoringSeeds(Hamster hamster)
    {
        seeds.Remove((hamster.GetX(), hamster.GetY()));

        // symbol im spielfeld wird überschrieben mit dem standard symbol (boden)
        hamster.SetTileToRemember(earthRepresentation);
    }

    public void Regrowth()
    {
        var random = new Random();
        int x, y;
        bool fieldIsEmpty;
        (int, int) key;

        int potentialGrowth = hamsters.Count / seeds.Count;
        int freeTiles = size * size - hamsters.Count - seeds.Count; //not considering stacked hamsters

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            do
            {
                key = (x = random.Next(size), y = random.Next(size));

                fieldIsEmpty = !seeds.ContainsKey(key) && !TileTakenByHamster(key);

            } while (fieldIsEmpty);

            seeds[key] = new Seed(this);
            plane[y,x] = Seed.GetRepresentation();
        }

    }

    public bool Position(Hamster hamster, (int x, int y) key)
    {
        bool tileIsEmpty = !seeds.ContainsKey(key) && !TileTakenByHamster(key);

        if (tileIsEmpty)
        {
            plane[key.y, key.x] = hamster.GetRepresentation();
            hamsters.Add(hamster);
        }

        return tileIsEmpty;
    }

    private bool TileTakenByHamster((int x, int y) key)
    {
        bool isTaken = false;

        foreach (var hamster in hamsters)
        {
            if (hamster.GetPosition() == key)
            {
                isTaken = true;
                break;
            }
        }

        return isTaken;
    }

    public bool Position(Seed seed, (int x, int y) key)
    {
        bool tileIsEmpty = !seeds.ContainsKey(key) && !TileTakenByHamster(key);

        if (tileIsEmpty)
        {
            plane[key.y, key.x] = Seed.GetRepresentation();
            seeds[key] = seed;
        }

        return tileIsEmpty;
    }

    public bool ContainsSeed((int x, int y) key)
    {
        return seeds.ContainsKey(key);
    }

    // get-set Methoden
    public Seed GetSamen((int x, int y) key)
    {
        return seeds[key];
    }

    public int GetSize()
    {
        return size;
    }

    public static String GetEarthRepresentation()
    {
        return earthRepresentation;
    }
}
