using Hamster.Strategies;
using Hamster.Visuals;
namespace Hamster;

public class BigLegHamster : Hamster
{
    protected override NutritionBehaviour MyNutritionBehaviour { get; set; } = new ForesightedNutritionBehaviour();
    protected override IMovementStrategy MyMovementStragegy { get; set; } = new DoubleStepMovementStrategy();
    public override IVisuals HungryVisual { get; protected set; } = new HungryBigLegHamsterVisuals(); 
    public override IVisuals FedVisual { get; protected set; } = new HungryBigLegHamsterVisuals(); 

    public BigLegHamster(Plane plane) : base(plane)
    {
    }
}
