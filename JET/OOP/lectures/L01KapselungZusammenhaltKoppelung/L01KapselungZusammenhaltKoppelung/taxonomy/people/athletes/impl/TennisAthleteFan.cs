using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

// TODO: use decorator pattern! decorate Athlete with beeing a fan.
//internal class TennisAthleteFan(PersonalInformation data, Authentication id, Shoes footGear, TennisRacket handGear) : TennisAthlete(data, id, footGear, handGear)

internal class TennisAthleteFan : TennisAthlete
{
    
    private string cheer = "<Athlete specific cheer>";
    private string boo = "<Athlete specific boo>";

    public CheeringTool CheeringTool { get; set; }

    public TennisAthleteFan(
        PersonalInformation data, 
        Authentication id, 
        Shoes footGear, 
        TennisRacket handGear
    ) : base(data, id, footGear, handGear)
    {
    }

    public TennisAthleteFan(TennisAthlete athlete, CheeringTool cheeringTool) : base(athlete.Data, athlete.Id, athlete.FootGear, athlete.HandGear)
    {
        CheeringTool = cheeringTool;
    }

    public string Cheer()
    {
        Console.WriteLine(cheer);
        return cheer;
    }

    public string Boo()
    {
        Console.WriteLine(boo);
        return cheer;
    }

}
