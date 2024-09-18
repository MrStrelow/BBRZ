using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal abstract class TransportationVehicle
{
    public int Capacity { get; set; }
    public Place CurrentLocation { get; set; }
    public (int hoehe, int breite, int laenge) dimension { get; }

    public Navigation Navi { get; }

    public TransportationVehicle(int capacity, Place currentLocation, )
    {
        CurrentLocation = currentLocation;
        Capacity = capacity;
    }

    public virtual void moveTo(Place place)
    {
        Navi.findAndDisplayRoute(place);
        CurrentLocation = place;
        Console.WriteLine("moving to");
    }
}
