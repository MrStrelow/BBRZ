namespace Hamster.Strategies;

// ISP (Interface Segregation Principle): This abstract class is small (one abstract method) and focused on nutrition.
// Clients (like Hamster) only need to know about performing nutrition, not other unrelated actions.
public abstract class NutritionBehaviour
{
    // SRP (Single Responsibility Principle): This interface's sole responsibility is to define the contract for nutrition behavior.
    // OCP (Open/Closed Principle): New nutrition algorithms can be added by creating new classes that implement this interface,
    // without modifying existing code that uses INutritionBehaviour.
    protected readonly Random _random = new Random();

    public abstract void Execute(IHamsterMutator mutator, Plane plane);

    protected void EatSeedlingFromTile(IHamsterMutator mutator, Seedling seedling, Plane plane)
    {
        Eat(mutator);
        plane.HamsterIsEatingSeedlings(seedling); // Plane handles removal of seedling
    }

    protected void PutInMouthList(Hamster hamster, Seedling seedling, Plane plane)
    {
        hamster.Mouth.Add(seedling);
        plane.HamsterIsStoringSeedlings(seedling); // Plane handles removal of seedling from world
    }

    protected void EatSeedlingFromMouth(IHamsterMutator mutator)
    {
        Eat(mutator);
        if (mutator.MutatedHamster.Mouth.Any())
        {
            mutator.MutatedHamster.Mouth.RemoveAt(0);
        }
    }

    protected void Eat(IHamsterMutator mutator)
    {
        mutator.SetHungryState(false);

    }
}
