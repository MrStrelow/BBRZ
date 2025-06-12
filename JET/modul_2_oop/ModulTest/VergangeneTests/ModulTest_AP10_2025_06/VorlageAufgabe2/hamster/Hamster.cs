using Hamster.Strategies;
using Hamster.Visuals;

namespace Hamster;

public abstract class Hamster
{
    // Felder

    // Eigenschaften
    // Wenn wir verhindern wollen dass es null sein kann schreiben wir abstract statt virtual
    // public virtual string FedRepresentation { get; protected set; }
    public abstract IVisuals HungryVisual { get; protected set; } 
    public abstract IVisuals FedVisual { get; protected set; } 
    public IVisuals CurrentVisual { get; private set; }
    public (int x, int y) Position { get; set; }
    public bool IsHungry { get; private set; }

    // Beziehungen
    protected Plane MyPlane { get; set; }
    public List<Seedling> Mouth { get; protected set; } = new();
    protected abstract NutritionBehaviour MyNutritionBehaviour { get; set; }
    protected abstract IMovementStrategy MyMovementStragegy { get; set; }

    // Konstruktoren
    public Hamster(Plane plane)
    {
        MyPlane = plane;
        CurrentVisual = FedVisual;

        // Zufällige Position wählen
        var random = new Random();

        bool notDone;
        int x;
        int y;

        // Plane sagt passt oder passt nicht
        // Zuständigkeit: probiere neue zufällige x und y zuweisungen aus.
        do
        {
            x = random.Next(MyPlane.Size);
            y = random.Next(MyPlane.Size);
            notDone = plane.IsInitialPositionValid(this, (x, y));
        }
        while (notDone);

        Position = (x, y);
    }

    // Methoden
    public virtual void Move()
    {
        MyMovementStragegy.Execute(this, MyPlane);
    }

    public virtual void NutritionBehaviour()
    {
        var mutator = new HamsterMutator(this); // this is the key to being hungry
        MyNutritionBehaviour.Execute(mutator, MyPlane);
    }

    // nested class which is private
    protected class HamsterMutator : IHamsterMutator
    {
        public Hamster MutatedHamster { get; init; }

        public HamsterMutator(Hamster hamsterInstance)
        {
            MutatedHamster = hamsterInstance;
        }

        // private setter works because its an inner class.
        public void SetHungryState()
        {
            MutatedHamster.IsHungry = true;
        }

        public void SetFedState()
        {
            MutatedHamster.IsHungry = false;
        }

        public void SetHungryVisual()
        {
            MutatedHamster.CurrentVisual = MutatedHamster.HungryVisual;
        }

        public void SetFedVisual()
        {
            MutatedHamster.CurrentVisual = MutatedHamster.FedVisual;
        }
    }
}