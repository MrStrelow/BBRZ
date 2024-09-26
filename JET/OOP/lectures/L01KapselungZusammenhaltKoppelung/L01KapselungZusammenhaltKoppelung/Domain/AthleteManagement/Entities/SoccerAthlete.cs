using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class SoccerAthlete : Athlete, ICompetitor<SoccerAthlete>
{
    // warum hier FootGear und nicht in Athlete wenn beides in Soccer und Tennis ist? Doppelter Code?
    public Shoes FootGear {  get; set; }
    
    public SoccerAthlete(PersonalInformation data, Authentication id, Shoes footGear) : base(data, id)
    {
        FootGear = footGear;
    }

    // TODO: fan athlete wird durch decorator ersetzt. kein copy constructor mehr nötig.
    // Copy Constructor: in ef core die id kopieren, und es wird kein neues objekt angelegt.
    public SoccerAthlete(SoccerAthleteFan athlete) : base(athlete.Data, athlete.Id)
    {
        FootGear = athlete.FootGear;
    }

    

    public override string ToString()
    {
        return base.Data.LastName;
    }

    SoccerAthlete ICompetitor<SoccerAthlete>.Compete(SoccerAthlete opponent)
    {
        Console.WriteLine($"Soccer: Competing against {opponent}");
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
