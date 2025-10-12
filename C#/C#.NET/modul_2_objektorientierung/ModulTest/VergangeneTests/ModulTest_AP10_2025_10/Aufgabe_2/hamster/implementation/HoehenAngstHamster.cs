using Hamster.Strategies;
using Hamster.Visuals;

namespace Hamster;

public class HoehenAngstHamster : Hamster
{
    protected override NutritionBehaviour MyNutritionBehaviour { get; set; } = new HoehenAngstNutritionBehaviour();
    protected override IMovementStrategy MyMovementStragegy { get; set; } = new DoubleStepMovementStrategy();
    public override IVisuals HungryVisual { get; protected set; } = new HungryHoehenAngstHamsterVisuals();
    public override IVisuals FedVisual { get; protected set; } = new FedHoehenAngstHamsterVisuals();

    public bool TouchedTopWallOnce { get; set; } = false;

    public HoehenAngstHamster(Plane plane) : base(plane)
    {
    }

    public override void Move()
    {
        MyMovementStragegy = TouchedTopWallOnce ? new HoehenAngstMovementStrategy() : new OneStepMovementStrategy();
        base.Move(); // ruft die Move methode aus der Basis-Klasse Hamster auf. Wir sind gerade im SmokingHamster.
        // oder direkt aufrufen.
        // MyMovementStragegy.Execute(this, MyPlane);
    }
}
