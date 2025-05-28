namespace Hamster;

public abstract class Hamster
{
    // Felder
    private static string _hungryRepresentation = "😡";

    // Eigenschaften
    // Wenn wir verhindern wollen dass es null sein kann schreiben wir abstract statt virtual
    //public virtual string FedRepresentation { get; protected set; }
    public abstract string FedRepresentation { get; protected set; }
    public (int x, int y) Position { get; set; }
    public string Representation { get; private set; }
    public bool IsHungry { get; private set; }

    // Beziehungen
    protected Plane World { get; set; }
    private List<Seedling> mouth = new();

    // Konstruktoren
    public Hamster(Plane plane)
    {
        World = plane;
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
            x = random.Next(World.Size);
            y = random.Next(World.Size);
            notDone = plane.IsInitialPositionValid(this, (x, y));
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

        // steh ich auf einen Seedling
        if (World.TryGetSeedling(Position, out Seedling Seedling))
        {
            if (IsHungry)
            {
                EatSeedlingFromTile(Seedling);
            }
            else
            {
                PutInMouthList(Seedling);
            }
        }
        else
        {
            if (IsHungry && mouth.Any())
            {
                EatSeedlinglingFromMouth();
            }
        }

    }

    private void EatSeedlingFromTile(Seedling Seedling)
    {
        Eat();
        World.HamsterIsEatingSeedlings(Seedling);
    }

    private void PutInMouthList(Seedling Seedling)
    {
        mouth.Add(Seedling);
    }

    private void EatSeedlinglingFromMouth()
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