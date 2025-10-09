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

    public bool BehaviourPermanentlyAltered { get; set; } = false;

    public SmokingHamster(Plane plane) : base(plane)
    {
    }

    public override void Move()
    {
        MyMovementStragegy = BehaviourPermanentlyAltered ? new SmokingMovementStrategy() : new OneStepMovementStrategy();
        base.Move(); // ruft die Move methode aus der Basis-Klasse Hamster auf. Wir sind gerade im SmokingHamster.
        // oder direkt aufrufen.
        // MyMovementStragegy.Execute(this, MyPlane);
    }
}
