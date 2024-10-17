using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class HumanNavi : Navigation
{
    public Human Navigator { get; }

    public HumanNavi(Human navigator)
    { 
        Navigator = navigator;
    }

    public override void findAndDisplayRoute(Place place)
    {
        Console.WriteLine($"Moving to {place} using {Navigator.Data.LastName}'s experience");
    }
}
