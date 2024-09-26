using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class GpsNavi : Navigation
{ 
    public override void findAndDisplayRoute(Place place)
    {
        Console.WriteLine($"Moving to {place} using route with id: " + new Random().Next());
    }
}

