using Hamster.Strategies;
using System;
namespace Hamster;

public class BigMouthHamster : Hamster
{
    protected override NutritionBehaviour MyNutritionBehaviour { get; set; } = new MyopicNutritionBehaviour();
    protected override IMovementStrategy MyMovementStragegy { get; set; } = new OneStepMovementStrategy();
    public override IVisualRepresentation HungryRepresentation { get; protected set; }
    public override IVisualRepresentation FedRepresentation { get; protected set; }

    public BigMouthHamster(Plane plane, IRenderer renderer) : base(plane, renderer)
    {
        (IVisualRepresentation fed, IVisualRepresentation hangry)  representationTuple = renderer switch
        {
            HtmlRenderer => (
                new ImageRepresentation("resources/BigMouthHamster_fed.png"),
                new ImageRepresentation("resources/BigMouthHamster_hangry.png")
            ),

            ConsoleRenderer => (
                new UnicodeRepresentation("🐹"),
                new UnicodeRepresentation("😡")
            )
        };
    }
}
