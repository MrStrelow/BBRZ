using Hamster.Strategies;
using Hamster.Visuals;

namespace Hamster;

public class SmokingHamster : Hamster
{
    protected override NutritionBehaviour MyNutritionBehaviour { get; set; } = new SmokingNutritionBehaviour();
    protected override IMovementStrategy MyMovementStragegy { get; set; } = new OneStepMovementStrategy();
    public override IVisuals HungryVisual { get; protected set; } = new HungrySmokingHamsterVisuals();
    public override IVisuals FedVisual { get; protected set; } = new FedSmokingHamsterVisuals();
    public bool HadEmptyMouthOnce { get; private set; }

    public SmokingHamster(Plane plane) : base(plane)
    {
    }

    public override void Move()
    {
        MyMovementStragegy = !Mouth.Any() ? new SmokingMovementStrategy() : new OneStepMovementStrategy();
        MyMovementStragegy.Execute(this, MyPlane);
    }
}
