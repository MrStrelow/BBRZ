using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L01KapselungZusammenhaltKoppelung;

internal class TennisAthlete : Athlete, ICompetitor<TennisAthlete>
{
    // Koppelung?
    public Shoes FootGear { get; set; }
    public TennisRacket HandGear { get; set; }

    public TennisAthlete(PersonalInformation data, Authentication id, Shoes footGear, TennisRacket handGear) : base(data, id)
    {
    }


    // TODO: fan athlete wird durch decorator ersetzt. kein copy constructor mehr nötig.
    // Copy Constructor: in ef core die id kopieren, und es wird kein neues objekt angelegt.
    public TennisAthlete(TennisAthleteFan athlete) : base(athlete.Data, athlete.Id)
    {
        FootGear = athlete.FootGear;
        HandGear = athlete.HandGear;
    }
    

    public override string ToString()
    {
        return base.Data.LastName;
    }

    TennisAthlete ICompetitor<TennisAthlete>.Compete(TennisAthlete opponent)
    {
        Console.WriteLine($"Tennis: {this.Data.LastName} is competing against {opponent.Data.LastName}");
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
}
