using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Team
{
    public List<Athlete> team { get; } = new List<Athlete>();
    public Trainer Trainer { get; }
    public TransportationVehicle Transportation { get; }

    public Team(
        Trainer trainer, 
        TransportationVehicle transportation, 
        Athlete firstAthlete, params Athlete[] athletes
    )
    {
        Trainer = trainer;
        Transportation = transportation;

        team.Add(firstAthlete);

        foreach (var item in athletes)
        {
            team.Add(item);
        }
    }
}
