using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Tandem : TransportationVehicle
{
    public Tandem(
        int capacity,
        Place currentLocation,
        (int hoehe, int breite, int laenge) dimension,
        Navigation navi
    ) : base(capacity, currentLocation, dimension, navi)
    { 
    }

    protected override decimal calculateCost(Place place)
    {
        return 0;
    }
}
