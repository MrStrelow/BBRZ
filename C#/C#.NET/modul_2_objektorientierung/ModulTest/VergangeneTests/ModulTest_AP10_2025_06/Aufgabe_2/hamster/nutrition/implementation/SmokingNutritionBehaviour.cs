using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamster.Strategies;

public class SmokingNutritionBehaviour : NutritionBehaviour
{
    private readonly Random _random = new Random();

    public override void Execute(IHamsterMutator mutator, Plane plane)
    {
        // Guard Clauses
        if (mutator?.MutatedHamster is null) throw new ArgumentNullException(nameof(mutator.MutatedHamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        // gewünschte Zustände
        var smokingHamster = (SmokingHamster) mutator.MutatedHamster;

        // bin ich hungrig?
        if (_random.NextDouble() < 0.80)
        {
            mutator.SetHungryState();
            mutator.SetHungryVisual();
        }

        if (plane.TryGetSeedling(smokingHamster.Position, out Seedling? seedling))
        {
            if (seedling is not null)
            {
                if (!smokingHamster.HadEmptyMouthOnce)
                {
                    if (smokingHamster.IsHungry)
                    {
                        // 50/50 chance
                        if (_random.NextDouble() < 0.5)
                        {
                            EatSeedlingFromTile(mutator, seedling, plane);
                        }
                        else
                        {
                            StoreInMouthList(smokingHamster, seedling, plane);
                        }
                    }
                    else
                    {
                        StoreInMouthList(smokingHamster, seedling, plane);
                    }

                }
            }
        }
        else
        {
            if (!smokingHamster.Mouth.Any() && smokingHamster.IsHungry)
                smokingHamster.HadEmptyMouthOnce = true;
            // kürzer - statt if und darin eine zuweisung eines boolean true.
            //smokingHamster.BehaviourPermanentlyAltered = !hamster.Mouth.Any();

            if (smokingHamster.IsHungry && smokingHamster.Mouth.Any())
            {
                EatSeedlingFromMouth(mutator);
            }
        }
    }
}
