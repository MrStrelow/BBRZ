using Hamster.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Hamster;

public class BigLegHamster : Hamster
{
    protected override NutritionBehaviour MyNutritionBehaviour { get; set; } = new ForesightedNutritionBehaviour();
    protected override IMovementStrategy MyMovementStragegy { get; set; } = new DoubleStepMovementStrategy();
    public override IVisualRepresentation HungryRepresentation { get; protected set; }
    public override IVisualRepresentation FedRepresentation { get; protected set; }

    public BigLegHamster(Plane plane, IRenderer renderer) : base(plane, renderer)
    {
        (IVisualRepresentation fed, IVisualRepresentation hangry) representationTuple = renderer switch
        {
            HtmlRenderer => (
                new ImageRepresentation("resources/BigLegHamster_fed.png"),
                new ImageRepresentation("resources/BigLegHamster_hangry.png")
            ),

            ConsoleRenderer => (
                new UnicodeRepresentation("🐰"),
                new UnicodeRepresentation("😡")
            ),
            _ => throw new NotSupportedException()
        };

        FedRepresentation = representationTuple.fed;
        HungryRepresentation = representationTuple.hangry;
    }
}
