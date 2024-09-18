using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Bus : TransportationVehicle
{
    public Bus(int capacity, Place currentLocation) : base(capacity, currentLocation)
    {
    }
    
    public override void moveTo(Place place)
    {
        base.moveTo(place);
    }
}
