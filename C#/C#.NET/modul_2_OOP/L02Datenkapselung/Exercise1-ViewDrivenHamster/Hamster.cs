namespace Hamster;

public class Hamster
{
    // Felder

    // Eigenschaften (Properties)
    public (int x, int y) Position { get; set; }
    public string Representation { get; private set; }
    public static string HungryRepresentation { get; } = "😡";
    public static string FedRepresentation { get; } = "🐹";
    public string RememberSymbolOnPlane { get; set; } // Problematisch! Wir sehen bald warum...

    public bool IsHungry { get; private set; }


    // Beziehungen
    private Plane _plane;
    private List<Seedling> _mouth = new List<Seedling>();

    // Konstruktor
    public Hamster(Plane plane)
    {
        IsHungry = false;
        Representation = FedRepresentation;
        _plane = plane;

        RememberSymbolOnPlane = Plane.EarthRepresentation; // Problematisch! Wir sehen bald warum...

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
            x = random.Next(_plane.Size);
            y = random.Next(_plane.Size);

            done = _plane.AssignInitialPosition(this, (x, y));
        } while (!done);

        Position = (x, y);
    }

    public void Move()
    {
        var random = new Random();
        int index = random.Next(Enum.GetValues<Direction>().Length);
        var direction = Enum.GetValues<Direction>()[index];

        _plane.Position(this, direction);
    }

    public void NutritionBehaviour()
    {
        var random = new Random();

        // Zufällig hungrig werden
        if (random.NextDouble() < 0.1)
        {
            IsHungry = true;
            Representation = HungryRepresentation;
        }

        // Sehr Problematisch! Die Position in dem Dictionary und das merken des Seedlingling Symbols ist nicht konsistent,
        // falls wir diese nicht korrekt überschreiben, wenn wir einen Seedlingling essen!
        // Es muss also in HamsterIsStoringSeedlings und HamsterIsEatingSeedlings der Code hamster.RememberSymbolOnPlane = EarthRepresentation; aufgerufen werden.
        // Falls wir das vergessen, merken wir uns auch Hamster Symbole wenn zwei hamster gleichzeitg auf ein Feld gehen!
        // Siehe Klasse Plane für weitere Erklärungen.

        if (RememberSymbolOnPlane == Seedling.Representation) // view logic: bad
        //if (_plane.ContainsSeedling(Position)) // state logic: good
        { 
            if (IsHungry)
            {
                EatSeedlingFromTile();
            }
            else
            {
                StoreInMouth();
            }
        }
        else
        {
            if (IsHungry && _mouth.Any())
            {
                EatSeedlingFromMouth();
            }
        }
    }

    private void EatSeedlingFromMouth()
    {
        Eat();
        _mouth.RemoveAt(0);
    }

    public void EatSeedlingFromTile()
    {
        Eat();
        _plane.HamsterIsEatingSeedlings(this);
    }

    private void Eat()
    {
        IsHungry = false;
        Representation = FedRepresentation;
    }

    public void StoreInMouth()
    {
        var seedling = _plane.GetSeedlingOn(Position);
        _mouth.Add(seedling);
        _plane.HamsterIsStoringSeedlings(this);
    }

    public override string ToString()
    {
        return Representation;
    }
}
