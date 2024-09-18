using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class SockerAthlete : Athlete
{
    public SockerAthlete(PersonalInformation data, Authentication id) : base(data, id)
    {
    }
}
