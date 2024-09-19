using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class SockerAthlete : Athlete
{
    // warum hier FootGear und nicht in Athlete wenn beides in Socker und Tennis ist? Doppelter Code?
    public Shoes FootGear {  get; set; }
    public SockerAthlete(PersonalInformation data, Authentication id, Shoes footGear) : base(data, id)
    {
        FootGear = footGear;
    }
}
