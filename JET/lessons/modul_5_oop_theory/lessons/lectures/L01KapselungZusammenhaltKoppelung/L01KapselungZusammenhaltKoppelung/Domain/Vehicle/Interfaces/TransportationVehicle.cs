using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

abstract class TransportationVehicle
{
    public int Capacity { get; set; }
    public Place CurrentLocation { get; set; }
    public (int Hoehe, int Breite, int Laenge) Dimension { get; }
    public Navigation Navi { get; }

    public TransportationVehicle(
        int capacity, 
        Place currentLocation, 
        (int hoehe, int breite, int laenge) dimension, 
        Navigation navi
    )
    {
        Capacity = capacity;
        CurrentLocation = currentLocation;
        Dimension = dimension;
        Navi = navi;
    }

    public void moveTo(Place place)
    {
        Navi.findAndDisplayRoute(place);
        CurrentLocation = place;
        Console.WriteLine($"moving to {place}");
        Console.WriteLine($"This trip costs: {calculateCost(place)} €");
    }

    protected abstract decimal calculateCost(Place place);
}
