using Hamster.Strategies;
using Hamster.Visuals;

namespace Hamster;

public class BigMouthHamster : Hamster
{
    protected override NutritionBehaviour MyNutritionBehaviour { get; set; } = new ForesightedNutritionBehaviour();
    protected override IMovementStrategy MyMovementStragegy { get; set; } = new OneStepMovementStrategy();
    public override IVisuals HungryVisual { get; protected set; } = new HungryBigMouthHamsterVisuals();
    public override IVisuals FedVisual { get; protected set; } = new HungryBigMouthHamsterVisuals();

    public BigMouthHamster(Plane plane) : base(plane)
    {
    }
}
