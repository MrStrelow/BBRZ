using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Fan : Human
{
    public CheeringTool cheeringTool { get; set; }

    public Fan(PersonalInformation data, Authentication id, CheeringTool toolsForCheering) : base(data, id)
    { 
    }
}
