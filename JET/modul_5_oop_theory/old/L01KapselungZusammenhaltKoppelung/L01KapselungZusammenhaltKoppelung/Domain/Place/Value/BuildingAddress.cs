using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;
internal class BuidldingAddress()
{
    public string Street { get; set; }
    public int Number { get; set; }
    public string District { get; set; }
    public (decimal longitude, decimal latitude) location;
    public Nationality Nationality { get; set; }
}
