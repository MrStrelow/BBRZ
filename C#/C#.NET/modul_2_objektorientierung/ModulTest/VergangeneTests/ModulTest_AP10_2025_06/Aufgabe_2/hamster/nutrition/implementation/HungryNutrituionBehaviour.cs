namespace Hamster.Strategies;

public class MyopicNutritionBehaviour : NutritionBehaviour
{
    public override void Execute(IHamsterMutator mutator, Plane plane)
    {
        // Guard Clauses
        if (mutator?.MutatedHamster is null) throw new ArgumentNullException(nameof(mutator.MutatedHamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        // gewünschte Zustände
        var hamster = mutator.MutatedHamster;

        // bin ich hungrig?
        if (_random.NextDouble() < 0.6)
        {
            mutator.SetHungryState();
            mutator.SetHungryVisual();
        }

        // steh ich auf einen Seedling
        if (plane.TryGetSeedling(hamster.Position, out Seedling? seedling))
        {
            if (seedling is not null) // Double check, as out param might be default if false
            {
                if (hamster.IsHungry)
                {
                    EatSeedlingFromTile(mutator, seedling, plane);
                }
            }
            else
            {
                throw new NullReferenceException(nameof(seedling));
            }
        }
    }
}
