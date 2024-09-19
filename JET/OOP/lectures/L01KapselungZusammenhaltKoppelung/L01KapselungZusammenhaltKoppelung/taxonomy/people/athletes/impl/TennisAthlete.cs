using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class TennisAthlete : Athlete
{
    // Koppelung?
    public Shoes FootGear { get; set; }
    public TennisRacket handGear { get; set; }
    
    public TennisAthlete(PersonalInformation data, Authentication id, Shoes footGear, TennisRacket handGear) : base(data, id) 
    { 
    }

    public void competeAgainst(Athlete opponent)
    {
        Console.WriteLine($"Competing against {opponent}");
    }

}
