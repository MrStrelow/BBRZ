using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

// TODO: use decorator pattern! decorate Athlete with beeing a fan.
//internal class TennisAthleteFan(PersonalInformation data, Authentication id, Shoes footGear, TennisRacket handGear) : TennisAthlete(data, id, footGear, handGear)
internal class SoccerAthleteFan : SoccerAthlete
{

    private string cheer = "<Athlete specific cheer>";
    private string boo = "<Athlete specific boo>";

    public CheeringTool CheeringTool { get; set; }

    public SoccerAthleteFan(
        PersonalInformation data,
        Authentication id,
        Shoes footGear
    ) : base(data, id, footGear)
    {
    }

    // Copy Constructor: in ef core die id kopieren, und es wird kein neues objekt angelegt.
    // TODO: fan athlete wird durch decorator ersetzt. kein copy constructor mehr nötig.
    public SoccerAthleteFan(SoccerAthlete athlete, CheeringTool cheeringTool) : base(athlete.Data, athlete.Id, athlete.FootGear)
    {
        CheeringTool = cheeringTool;
    }

    public string Cheer()
    {
        Console.WriteLine(cheer + $" - verwendet: {CheeringTool.UseMe()}");
        return cheer;
    }

    public string Boo()
    {
        Console.WriteLine(boo);
        return cheer;
    }

}
