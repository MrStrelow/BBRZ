namespace Hamster.Strategies;

// SRP (Single Responsibility Principle): This class is solely responsible for the default nutrition logic.
// LSP (Liskov Substitution Principle): Instances of DefaultNutritionBehaviour can be used wherever an INutritionBehaviour is expected.
public class ForesightedNutritionBehaviour : NutritionBehaviour
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
        if (_random.NextDouble() < 0.1)
        {
            mutator.SetHungryState(true);
        }

        // steh ich auf einen Seedling
        if (plane.TryGetSeedling(hamster.Position, out Seedling? seedling)) // Ensure Seedling is nullable if TryGetSeedling can return false without out
        {
            if (seedling != null) // Double check, as out param might be default if false
            {
                if (hamster.IsHungry)
                {
                    EatSeedlingFromTile(mutator, seedling, plane);
                }
                else
                {
                    PutInMouthList(hamster, seedling, plane);
                }
            }
        }
        else
        {
            if (hamster.IsHungry && hamster.Mouth.Any())
            {
                EatSeedlingFromMouth(mutator);
            }
        }
    }
}
