using Hamster.Strategies;

namespace Hamster;

public abstract class Hamster
{
    // Felder

    // Eigenschaften
    // Wenn wir verhindern wollen dass es null sein kann schreiben wir abstract statt virtual
    //public virtual string FedRepresentation { get; protected set; }
    public abstract IVisualRepresentation HungryRepresentation { get; protected set; }
    public abstract IVisualRepresentation FedRepresentation { get; protected set; }
    public IVisualRepresentation Representation { get; private set; }
    public (int x, int y) Position { get; set; }
    public bool IsHungry { get; private set; }

    // Beziehungen
    protected Plane World { get; set; }
    public List<Seedling> Mouth { get; protected set; } = new();
    protected abstract NutritionBehaviour MyNutritionBehaviour { get; set; }
    protected abstract IMovementStrategy MyMovementStragegy { get; set; }

    // Konstruktoren
    public Hamster(Plane plane, IRenderer renderer)
    {
        World = plane;
        Representation = FedRepresentation ?? throw new NullReferenceException(nameof(FedRepresentation));

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
    public void Move()
    {
        MyMovementStragegy.Execute(this, World);
    }

    public void NutritionBehaviour()
    {
        var mutator = new HamsterMutator(this); // this is the key to being hungry
        MyNutritionBehaviour.Execute(mutator, World);
    }

    // nested class which is private
    private class HamsterMutator : IHamsterMutator
    {
        public Hamster MutatedHamster { get; init; }

        public HamsterMutator(Hamster hamsterInstance)
        {
            MutatedHamster = hamsterInstance;
        }

        // private setter works because its an inner class.
        public void SetHungryState(bool isHungry)
        {
            MutatedHamster.IsHungry = isHungry;
        }
    }
}