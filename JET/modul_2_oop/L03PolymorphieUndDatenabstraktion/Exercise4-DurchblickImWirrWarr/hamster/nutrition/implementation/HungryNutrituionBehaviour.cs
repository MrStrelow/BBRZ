namespace Hamster.Strategies;

// SRP (Single Responsibility Principle): This class is solely responsible for the default nutrition logic.
// LSP (Liskov Substitution Principle): Instances of DefaultNutritionBehaviour can be used wherever an INutritionBehaviour is expected.
public class MyopicNutritionBehaviour : NutritionBehaviour
{
    // SRP: The PerformNutrition method encapsulates the logic for how a hamster eats or stores food.
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
        if (plane.TryGetSeedling(hamster.Position, out Seedling? seedling)) // Ensure Seedling is nullable if TryGetSeedling can return false without out
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
