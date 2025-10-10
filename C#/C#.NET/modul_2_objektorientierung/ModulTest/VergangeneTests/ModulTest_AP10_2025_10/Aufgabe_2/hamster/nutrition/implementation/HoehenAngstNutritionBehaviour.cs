using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamster.Strategies;

public class HoehenAngstNutritionBehaviour : NutritionBehaviour
{
    private readonly Random _random = new Random();

    public override void Execute(IHamsterMutator mutator, Plane plane)
    {
        // Guard Clauses
        if (mutator?.MutatedHamster is null) throw new ArgumentNullException(nameof(mutator.MutatedHamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        // gewünschte Zustände
        var hoehenAngstHamster = (HoehenAngstHamster) mutator.MutatedHamster;

        // bin ich hungrig?
        if (_random.NextDouble() < 0.10)
        {
            mutator.SetHungryState();
            mutator.SetHungryVisual();
        }

        if (plane.TryGetSeedling(hoehenAngstHamster.Position, out Seedling? seedling))
        {
            if (seedling is not null)
            {
                if (!hoehenAngstHamster.TouchedTopWallOnce)
                {
                    if (hoehenAngstHamster.IsHungry)
                    {
                        EatSeedlingFromTile(mutator, seedling, plane);
                    }
                    else
                    {
                        StoreInMouthList(hoehenAngstHamster, seedling, plane);
                    }
                }
                else
                {
                    EmptyAllSeedlingsFromMouth(hoehenAngstHamster);
                }
            }
        }
        else
        {
            if (hoehenAngstHamster.IsHungry && hoehenAngstHamster.Mouth.Any())
            {
                EatSeedlingFromMouth(mutator);
            }
        }
    }

    
    protected void EmptyAllSeedlingsFromMouth(Hamster hamster)
    {
        // falls hier komplexere Logik wäre - eigene Methode
        hamster.Mouth.Clear();
    }
}
