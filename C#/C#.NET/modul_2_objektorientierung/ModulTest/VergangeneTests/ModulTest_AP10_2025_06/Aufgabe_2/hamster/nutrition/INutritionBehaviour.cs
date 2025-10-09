namespace Hamster.Strategies;

public abstract class NutritionBehaviour
{
    protected readonly Random _random = new Random();

    public abstract void Execute(IHamsterMutator mutator, Plane plane);

    protected void EatSeedlingFromTile(IHamsterMutator mutator, Seedling seedling, Plane plane)
    {
        Eat(mutator);
        plane.HamsterIsEatingSeedlings(seedling); 
    }

    protected void StoreInMouthList(Hamster hamster, Seedling seedling, Plane plane)
    {
        hamster.Mouth.Add(seedling);
        plane.HamsterIsStoringSeedlings(seedling);
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
        mutator.SetFedState();
        mutator.SetFedVisual();
    }
}
