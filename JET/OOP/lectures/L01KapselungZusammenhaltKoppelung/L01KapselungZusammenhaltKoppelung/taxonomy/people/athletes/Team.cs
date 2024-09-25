using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Team<T> : ICompetitor<Team<T>> where T : ICompetitor<T>
{
    public string Name { get; set; }
    public SportClub Club { get; set; }
    public List<T> team { get; } = new List<T>();
    public Trainer Trainer { get; }
    public TransportationVehicle Transportation { get; }

    public Team(
        string name,
        Trainer trainer, 
        TransportationVehicle transportation, 
        T firstAthlete, params T[] athletes
    )
    {
        Name = name;    
        // ist das gut so?0
        Club = trainer.CurrentClub;
        Trainer = trainer;
        Transportation = transportation;

        team.Add(firstAthlete);

        foreach (var item in athletes)
        {
            team.Add(item);
        }
    }

    public Team<T> Compete(Team<T> opponent)
    {
        Console.WriteLine($"TeamEvent: {this.Name} is competing against {opponent.Name}");
        double result = new Random().NextDouble();

        if (result < 0.5)
        {
            return opponent;
        }
        else
        {
            return this;
        }
    }

    public override string ToString()
    {
        return Name;
    }
}
