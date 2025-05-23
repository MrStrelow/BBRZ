using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hamster;

public class BigMouthHamster : Hamster
{
    public override string FedRepresentation { get; protected set; } = "🐹";

    public BigMouthHamster(Plane plane) : base(plane)
    {
    }

    public override void Move()
    {
        var random = new Random();
        int directionIndex = random.Next(Enum.GetValues<Direction>().Length);
        var direction = Enum.GetValues<Direction>()[directionIndex];

        PlaneObj.Position(this, direction);
    }
}
