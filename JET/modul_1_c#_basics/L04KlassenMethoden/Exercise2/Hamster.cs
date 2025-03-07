namespace Hamster;

public class Hamster
{
    // Felder
    private (int x, int y) position;
    private String representation;
    private static String hungryRepresentation = "😡";
    private static String fedRepresentation = "🐹";
    private bool isHungry;

    // (hat) Beziehungen
    private Plane plane;
    private List<Seed> mouth = new List<Seed>();

    // Konstruktor
    public Hamster(Plane plane)
    {
        isHungry = false;
        representation = fedRepresentation;
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
            x = random.Next(plane.GetSize());
            y = random.Next(plane.GetSize());

            done = plane.AssignInitialPosition(this, (x, y));
        } while (!done);

        position = (x, y);
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
        // werde zufällig hungrig
        var random = new Random();

        if (random.NextDouble() < 0.1)
        {
            isHungry = true;
            representation = hungryRepresentation;
        }

        // ist ein Samen unter mir (hamster) ?
        if (plane.ContainsSeed(position))
        {
            // habe ich hunger?
            if (isHungry)
            {
                // wenn ja, dann rufe methode essen auf
                EatSeedFromTile();
            }
            else
            {
                // ansonsten rufe methode hamstern auf
                PutInMouth();
            }

        }
        else
        {
            if (isHungry && mouth.Any())
            {
                EatSeedFromMouth();
            }
        }
    }

    private void EatSeedFromMouth()
    {
        // hamster wird nicht mehr hungrig.
        Eat();

        // hamster entfernt den Samen aus dem Mund - könnte Queue sein, statt List. Hier haben wir verhalten eines Stacks.
        mouth.RemoveAt(0);
    }

    public void EatSeedFromTile()
    {
        // hamster wird nicht mehr hungrig.
        Eat();

        // hamster sagt dem spielfeld, der samen ist weg
        plane.HamsterIsEatingSeeds(this);
    }

    private void Eat()
    {
        isHungry = false;
        representation = fedRepresentation;
    }

    public void PutInMouth()
    {
        // hamster merkt sich, dass ein neues Samen Objekt gespeichtert wird.
        var samen = plane.GetSamen(position);
        mouth.Add(samen);

        // hamster sagt dem spielfeld, der samen ist weg
        plane.HamsterIsStoringSeeds(this);
    }

    public override String ToString()
    {
        return representation;
    }

    // get-set Methoden
    public (int x, int y) GetPosition()
    {
        return position;
    }

    public void SetPosition(int x, int y)
    {
        position.x = x;
        position.y = y;
    }

    public void SetPosition((int x, int y) position)
    {
        this.position = position;
    }

    public int GetX()
    {
        return position.x;
    }

    public void SetX(int x)
    {
        position.x = x;
    }

    public int GetY()
    {
        return position.y;
    }

    public void SetY(int y)
    {
        position.y = y;
    }

    public void SetY((int x, int y) position)
    {
        this.position = position;
    }

    public String GetRepresentation()
    {
        return representation;
    }

    public static String GetHungryRepresentation()
    {
        return hungryRepresentation;
    }

    public static String GetFedRepresentation()
    {
        return fedRepresentation;
    }
}
