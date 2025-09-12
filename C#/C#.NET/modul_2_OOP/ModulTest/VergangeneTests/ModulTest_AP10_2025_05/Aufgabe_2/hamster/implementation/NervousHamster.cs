using Hamster.Strategies;
using Hamster.Visuals;

namespace Hamster;

public class NervousHamster : Hamster
{
    protected override NutritionBehaviour MyNutritionBehaviour { get; set; } = new NervousNutritionBehaviour();
    protected override IMovementStrategy MyMovementStragegy { get; set; } = new OneStepMovementStrategy();
    public override IVisuals HungryVisual { get; protected set; } = new HungryNervousHamsterVisuals();
    public override IVisuals FedVisual { get; protected set; } = new FedNervousHamsterVisuals();
    public bool HadEmptyMouthOnce { get; private set; }

    public NervousHamster(Plane plane) : base(plane)
    {
    }

    public override void Move()
    {
        MyMovementStragegy = !Mouth.Any() ? new NervousMovementStrategy() : new OneStepMovementStrategy();
        MyMovementStragegy.Execute(this, MyPlane);
    }
}
