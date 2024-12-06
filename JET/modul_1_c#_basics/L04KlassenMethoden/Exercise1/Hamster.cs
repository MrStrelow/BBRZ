namespace Hamster;

public class Hamster
{
    // Felder
    private (int x, int y) position;
    private String representation;
    private static String hungryRepresentation = "😡";
    private static String fedRepresentation = "🐹";
    private bool isHungry;

    private String tileToRemember;

    // (hat) Beziehungen
    private Plane plane;
    private List<Seed> mouth = new List<Seed>();

    // Konstruktor
    public Hamster(Plane plane)
    {
        isHungry = false;
        representation = fedRepresentation;
        this.tileToRemember = Plane.GetEarthRepresentation();
        this.plane = plane;

        PositionAndManageHamster();
    }

    private void PositionAndManageHamster()
    {
        var random = new Random();
        bool done;
        int x, y;

        do
        {
            x = random.Next(plane.GetSize());
            y = random.Next(plane.GetSize());

            done = plane.Position(this, (x, y));
        } while (!done);

        position = (x, y);
    }

    // Methoden
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

        // stehe ich auf einem Feld mit essen?
        // TODO: Gehe in der Stunde auf folgendes ein:
        //  Die Abfragen beziehen sich auf die grafische Darstellung.
        //  Diese muss nicht konsistent mit der der logischen sein!
        //  Vermeide deshalb diese.
        //        if (feldZumMerken.equals(Samen.getDarstellung())) { ... }

        // nutze anstatt dessen das Dictionary und seine Eigenschaften!
        // kein seed auf position wenn nicht in dict
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
        Eat();
        representation = fedRepresentation;
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

    public String GetTileToRemember()
    {
        return tileToRemember;
    }

    public void SetTileToRemember(String feldZumMerken)
    {
        this.tileToRemember = feldZumMerken;
    }
}
