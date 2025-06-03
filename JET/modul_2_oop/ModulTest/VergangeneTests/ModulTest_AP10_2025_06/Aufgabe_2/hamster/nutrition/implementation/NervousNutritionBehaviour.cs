using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamster.Strategies;

public class NervousNutritionBehaviour : NutritionBehaviour
{
    private bool _behaviourPermanentlyAltered = false;
    private readonly Random _random = new Random();

    public override void Execute(IHamsterMutator mutator, Plane plane)
    {
        // Guard Clauses -  defensive: but we could rely on compilers null checks and the resulting warnings.
        if (mutator?.MutatedHamster is null) throw new ArgumentNullException(nameof(mutator.MutatedHamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        // gewünschte Zustände
        var hamster = mutator.MutatedHamster;

        if (plane.TryGetSeedling(hamster.Position, out Seedling? seedling)) // Ensure Seedling is nullable if TryGetSeedling can return false without out
        {
            if (seedling is not null) // Double check, as out param might be default if false
            {
                if (_behaviourPermanentlyAltered)
                {
                    EatSeedlingFromTile(mutator, seedling, plane);
                }
                else
                {
                    // drehe ich durch?
                    _behaviourPermanentlyAltered = !hamster.Mouth.Any();

                    // bin ich hungrig?
                    if (_random.NextDouble() < 0.8)
                    {
                        mutator.SetHungryState();
                        mutator.SetHungryVisual();
                    }

                    if (hamster.IsHungry)
                    {
                        // 50/50 chance
                        if (_random.NextDouble() < 0.5)
                        {
                            EatSeedlingFromTile(mutator, seedling, plane);
                        }
                        else
                        {
                            PutInMouthList(hamster, seedling, plane);
                        }
                    }
                    else
                    {
                        PutInMouthList(hamster, seedling, plane);
                    }
                }
            }
        }
    }

    public void UpdateOnEmptyMouth(Hamster hamster)
    {
        _behaviourPermanentlyAltered = true;
    }
}
