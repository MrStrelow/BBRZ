namespace Hamster;

public class Hamster
{
    // Felder
    private static string _hungryRepresentation = "😡";
    private static string _fedRepresentation = "🐹";

    // Eigenschaften (Properties)
    public (int x, int y) Position { get; set; }
    public string Representation { get; private set; }

    public bool IsHungry { get; private set; }

    // Beziehungen
    private Plane plane;
    private List<Seed> mouth = new List<Seed>();

    // Konstruktor
    public Hamster(Plane plane)
    {
        IsHungry = false;
        Representation = _fedRepresentation;
        this.plane = plane;

        PositionAndManageHamster();
    }

    // Methoden
    private void PositionAndManageHamster()
    {
        var random = new Random();
        bool done;
        int x, y;

        do
        {
            x = random.Next(plane.Size);
            y = random.Next(plane.Size);

            done = plane.AssignInitialPosition(this, (x, y));
        } while (!done);

        Position = (x, y);
    }

    public void Move()
    {
        var random = new Random();
        int index = random.Next(Enum.GetValues<Direction>().Length);
        var direction = Enum.GetValues<Direction>()[index];

        plane.Position(this, direction);
    }

    public void NutritionBehaviour()
    {
        var random = new Random();

        // Zufällig hungrig werden
        if (random.NextDouble() < 0.1)
        {
            IsHungry = true;
            Representation = _hungryRepresentation;
        }

        if (plane.ContainsSeed(Position))
        {
            if (IsHungry)
            {
                EatSeedFromTile();
            }
            else
            {
                PutInMouth();
            }
        }
        else
        {
            if (IsHungry && mouth.Any())
            {
                EatSeedFromMouth();
            }
        }
    }

    private void EatSeedFromMouth()
    {
        Eat();
        mouth.RemoveAt(0);
    }

    public void EatSeedFromTile()
    {
        Eat();
        plane.HamsterIsEatingSeeds(this);
    }

    private void Eat()
    {
        IsHungry = false;
        Representation = _fedRepresentation;
    }

    public void PutInMouth()
    {
        var samen = plane.GetSeedOn(Position);
        mouth.Add(samen);
        plane.HamsterIsStoringSeeds(this);
    }

    public override string ToString()
    {
        return Representation;
    }
}
