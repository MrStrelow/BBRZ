namespace Hamster;

public abstract class Hamster
{
    // Felder
    private static string _hungryRepresentation = "😡";

    // Eigenschaften
    public string FedRepresentation { get; protected set; }
    public (int x, int y) Position { get; set; }
    public string Representation { get; private set; }
    public bool IsHungry { get; private set; }

    // Beziehungen
    protected Plane PlaneObj { get; set; }
    private List<Seed> mouth = new();

    // Konstruktoren
    public Hamster(Plane plane)
    {
        PlaneObj = plane;
        Representation = FedRepresentation;
        
        // Zufällige Position wählen
        var random = new Random();

        bool notDone;
        int x;
        int y;

        // Plane sagt passt oder passt nicht
        // Zuständigkeit: probiere neue zufällige x und y zuweisungen aus.
        do 
        {
            x = random.Next(PlaneObj.Size);
            y = random.Next(PlaneObj.Size);
            notDone = plane.TryToAssignInitialPosition(this, (x,y));
        }
        while (notDone);

        Position = (x, y); 
    }

    // Methoden
    public abstract void Move();

    public void NutritionBehaviour()
    {
        //  bin ich hungrig?
        var random = new Random();

        if (random.NextDouble() < 0.1)
        {
            IsHungry = true;
            Representation = Hamster._hungryRepresentation;
        }

        // steh ich auf einen seedling
        if (PlaneObj.ContainsSeed(Position))
        {
            if(IsHungry)
            {
                EatSeedFromTile();
            }
            else
            {
                PutInMouthList();
            }
        }
        else
        {
            if (IsHungry && mouth.Any())
            {
                EatSeedlingFromMouth();
            }
        }

    }

    private void EatSeedFromTile()
    {
        Eat();
        PlaneObj.HamsterIsEatingSeeds(this);
    }

    private void PutInMouthList()
    {
        var seedling = PlaneObj.GetSeedlingOn(Position);
        mouth.Add(seedling);
    }

    private void EatSeedlingFromMouth()
    {
        Eat();
        mouth.RemoveAt(0);
    }

    private void Eat()
    {
        IsHungry = false;
        Representation = FedRepresentation;
    }
}
