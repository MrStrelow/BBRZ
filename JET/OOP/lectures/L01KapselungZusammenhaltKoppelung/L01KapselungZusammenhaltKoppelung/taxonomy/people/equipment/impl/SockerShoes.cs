using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class SockerShoes : Shoes
{
    public FootballShoeProperties FootballShoeProperties { get; set; }
}

enum FootballShoeProperties
{
    longSpike, shortSpike
}
