using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamster;

public class BigLegHamster : Hamster
{
    public override string FedRepresentation { get; protected set; } = "🐰";

    public BigLegHamster(Plane plane) : base(plane)
    {
        //FedRepresentation = "🐰";
    }

    public override void Move()
    {
        var random = new Random();
        int firstDirectionIndex = random.Next(Enum.GetValues<Direction>().Length);
        int secondDirectionIndex = random.Next(Enum.GetValues<Direction>().Length);

        var firstDirection = Enum.GetValues<Direction>()[firstDirectionIndex];
        var secondDirection = Enum.GetValues<Direction>()[secondDirectionIndex];

        var directions = new List<Direction>() { firstDirection, secondDirection };
        
        World.Position(this, directions);
    }
}
