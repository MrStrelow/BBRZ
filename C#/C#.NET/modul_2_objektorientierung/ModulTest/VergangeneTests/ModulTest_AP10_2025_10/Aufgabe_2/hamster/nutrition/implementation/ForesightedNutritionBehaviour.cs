using Hamster.Visuals.Representations;

namespace Hamster.Strategies;

public class ForesightedNutritionBehaviour : NutritionBehaviour
{
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
            mutator.SetHungryState();
            mutator.SetHungryVisual();
        }

        // steh ich auf einen Seedling
        if (plane.TryGetSeedling(hamster.Position, out Seedling? seedling))
        {
            if (seedling != null)
            {
                if (hamster.IsHungry)
                {
                    EatSeedlingFromTile(mutator, seedling, plane);
                }
                else
                {
                    StoreInMouthList(hamster, seedling, plane);
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
